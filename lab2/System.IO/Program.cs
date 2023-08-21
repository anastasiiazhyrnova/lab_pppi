using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string file_path = "lab1.txt";
        string text = "Laboratory work 1!";
        File.WriteAllText(file_path, text);

        string read_text = File.ReadAllText(file_path);
        Console.WriteLine("Text of the file: " + read_text);

        FileInfo file_info = new FileInfo(file_path);
        if (file_info.Exists)
        {
            File.Move(file_path, @"C:\lab1\lab_new.txt");
        }

        string dir_path = "my_lab_directory";
        Directory.CreateDirectory(dir_path);
        Console.WriteLine("Directory created!");

        string my_dir_path = @"C:\lab1";
        string[] files_dir = Directory.GetFiles(my_dir_path);
        Console.WriteLine("Files in directory:");
        foreach (string file in files_dir)
        {
            Console.WriteLine(file);
        }
    }
}
