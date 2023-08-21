using System.IO;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

Console.Write("Choose the desired function: \n 1 - сounting words \n 2 - mathematical operation \n");
string? menu = Console.ReadLine();
Console.WriteLine($"You've chosen - {menu}");

if (menu == "1")
{
    CalcWords();
}
else if (menu == "2")
{
    MathOperation();
}
else
    Console.WriteLine($"You are mistaken!");


void CalcWords()
{
    string path = "C:/lab1/text1.txt";

    try
    {
        var text = File.ReadAllText(path);
        Console.Write("How many words must be printed?\n");
        string? qty_words = Console.ReadLine();
        List<string> list_words = text.Split(' ').ToList();
        for (int i = 0; i < Int32.Parse(qty_words); i++)
        {
            Console.Write(list_words[i] + " ");
        }
    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}


void MathOperation()
{
    Console.Write("Введите первое число:");
    double a = Convert.ToDouble(Console.ReadLine());

    Console.Write("Write the operation: + - * / \n");
    char operation = Convert.ToChar(Console.ReadLine());

    Console.Write("Введите второе число:");
    double b = Convert.ToDouble(Console.ReadLine());

    double result;
    switch (operation)
    {
        case '+':
            result = a+b;
            Console.WriteLine($"Answer: {result}");
            break;
        case '-':
            result = a - b;
            Console.WriteLine($"Answer: {result}"); 
            break;
        case '*':
            result = a * b;
            Console.WriteLine($"Answer: {result}"); 
            break;
        case '/':
            result = a / b;
            Console.WriteLine($"Answer: {result}");
            break;
        default: 
            Console.WriteLine("Error!");
            break;
    }
}
