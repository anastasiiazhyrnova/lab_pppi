using System.Reflection;
using System.Text;

class Country
{
    public string country;
    private double population;
    protected string symbol;
    internal int square;
    private protected string[] climate;

    public Country() { country = "Ірландія";}
    public Country(string country_obj, double population_obj, string symbol_obj) 
    {
        country = country_obj;
        population = population_obj;
        symbol = symbol_obj;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"\nКраїна: {country}  Населення: {population}млн Символ: {symbol}");
    }

    public string Сountry { get; set; }
    
    public void ShowClimate(string[] climate)
    {
        Console.WriteLine("Клімат в країні:");
        for (var i = 0; i < climate.Length; i++)
        {
            Console.WriteLine($"-{climate[i]} \t");
        }
    }
    public static string PrintClass()
    {
        string s = "It's class Country!!!";
        return s;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8; 
        var country = new Country();
        string[] climate = {"Клімат у Ірландії помірний", "Переважають південно-західні вітри Північно-Атлантичної течії" };
        country.ShowClimate(climate);


        Type type_of_obj = typeof(Country);
        Console.WriteLine(type_of_obj);
        string countryName = country.Сountry;
        Console.WriteLine(countryName); 


        MethodInfo[] method = type_of_obj.GetMethods();
        Console.WriteLine("Methods:");
        foreach (var item in method)
        {
            Console.WriteLine(item.ToString());
        }
        TypeInfo typeInfo = type_of_obj.GetTypeInfo();
        Console.WriteLine($"Is it an abstract class? - {typeInfo.IsAbstract}");
        Console.WriteLine($"Is it an interface? - {typeInfo.IsInterface}");


        MemberInfo[] members = type_of_obj.GetMembers();
        Console.WriteLine("Сlass members:");
        foreach (MemberInfo member in members)
        {
            Console.WriteLine( member.Name + "Type: " + member.MemberType);
        }


        Country country2 = new Country("США", 331.9, "орлан");
        country2.PrintInfo();
        var name_country = type_of_obj.GetField("country", BindingFlags.Instance | BindingFlags.NonPublic);
        var value = name_country?.GetValue(country2);

        string method_name = "PrintClass";
        MethodInfo methodInfo = type_of_obj.GetMethod(method_name);

        if (methodInfo != null)
        {
            object result = methodInfo.Invoke(null, new object[] { }); 
            Console.WriteLine("Результат виклику методу: " + result);
        }
        else
        {
            Console.WriteLine("Помилка! Метод не знайдено");
        }
    }
}
