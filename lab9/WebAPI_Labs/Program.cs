using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI_Labs.Services.AuthService;
using WebAPI_Labs.Services.ContentService.V1;
using WebAPI_Labs.Services.ContentService.V2;
using WebAPI_Labs.Services.ContentService.V3;
using WebAPI_Labs.Services.MessageService;
using WebAPI_Labs.Services.PasswordService;
using WebAPI_Labs.Services.TopicService;
using WebAPI_Labs.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMessageService, MessageService>();
builder.Services.AddSingleton<ITopicService, TopicService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IPasswordService, PasswordService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

builder.Services.AddScoped<INumberService, NumberService>();
builder.Services.AddScoped<IStringService, StringService>();
builder.Services.AddScoped<IExcelService, ExcelService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Secret"]!)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LabAPI v1.0", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "LabAPI v2.0", Version = "v2" });
    c.SwaggerDoc("v3", new OpenApiInfo { Title = "LabAPI v3.0", Version = "v3" });

    c.AddSecurityDefinition(
        "token",
        new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer",
            In = ParameterLocation.Header,
            Name = HeaderNames.Authorization
        }
    );
    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "token"
                    },
                },
                Array.Empty<string>()
            }
        }
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "LabAPI V1.0");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "LabAPI V2.0");
        options.SwaggerEndpoint("/swagger/v3/swagger.json", "LabAPI V3.0");

        options.RoutePrefix = "swagger";
        options.DocumentTitle = "LabAPI";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
