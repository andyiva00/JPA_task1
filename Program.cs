using System;
using System.Threading.Tasks;

public class JPA_task1
{
    private static int Factorial(int x)
    {
        if (x == 0)
            return 1;
        else
            return x * Factorial(x - 1);
    }
    public static void Main(string[] args)
    {
        int m, n;

        if (args.Length == 2)
        {
            m = Convert.ToInt32(args[0]);
            n = Convert.ToInt32(args[1]);
        }
        else
        {
            Console.Write("Enter 'm': ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter 'n': ");
            n = Convert.ToInt32(Console.ReadLine());
        }

        int[] arguments = { m - 1, n - 1, m + n - 2 };
        List<Task<int>> tasks = new List<Task<int>>();

        foreach (var argument in arguments)
            tasks.Add(Task.Run(() => { return Factorial(argument); }));
 
        Task.WaitAll(tasks.ToArray());

        Console.WriteLine(tasks[2].Result / tasks[1].Result / tasks[0].Result);
    }
}