using System;

public class Test
{
    public static void Main()
    {
        string input = Console.ReadLine();
        int number;
        int.TryParse(input, out number);
        while (number != 42){
            Console.WriteLine(number);
            input = Console.ReadLine();
            int.TryParse(input, out number);
        }
    }
}
