using System.Threading;
using System.Threading.Tasks;

void MyThread1() => Console.WriteLine("My Thread1");

void MyThread2()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Thread 2 num - " + i);
    }
}

void MyThread3()
{
    Console.WriteLine("Thread 3 started");
    Thread.Sleep(2000);
    Console.WriteLine("Thread 3 ended");
}

async Task MethodPrintAsync()
{
    Console.WriteLine("Start method - Print"); 
    await Task.Run(() => MyThread1());              
    Console.WriteLine("Finish method - Print");
}

async Task Method2Async()
{
    Console.WriteLine("Async Method 2 started");
    Task task1 = Task.Delay(3000);
    Task task2 = Task.Delay(1000);
    await Task.WhenAll(task1, task2);
    Console.WriteLine("Async Method 2 ended");
}

async Task Method3Async()
{
    Task[] tasks = new Task[3];
    for (var i = 0; i < tasks.Length; i++)
    {
        tasks[i] = new Task(() =>
        {
            Thread.Sleep(2500); 
            Console.WriteLine($"Task{i} finished");
        });
        tasks[i].Start();  
    }
    Console.WriteLine("Finish method - Async Method 3");
    await Task.WhenAll(tasks); 
}

void Main()
{
    Thread myThread1 = new Thread(MyThread1);
    Thread myThread2 = new Thread(new ThreadStart(MyThread2));
    Thread myThread3 = new Thread(MyThread3);

    myThread2.Priority = ThreadPriority.Highest;
    myThread1.Start();  
    myThread2.Start(); 
    myThread3.Start();

    MethodPrintAsync().Wait();   
    Method2Async().Wait();
    Method3Async().Wait();
}

Main();
