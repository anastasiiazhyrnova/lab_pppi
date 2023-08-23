using WebAPI_Labs.Services.MessageService;
using WebAPI_Labs.Services.TopicService;
using WebAPI_Labs.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// для збереження даних між запитами у списках використовувати Singleton
builder.Services.AddSingleton<IMessageService, MessageService>();
builder.Services.AddSingleton<ITopicService, TopicService>();
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
