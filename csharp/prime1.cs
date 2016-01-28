using System;
using System.Collections;

public class Prime1
{
    static BitArray is_prime = new BitArray(1000000001);
    static BitArray is_checked = new BitArray(1000000001);

    public static void Main()
    {
        int num_cases;
        int.TryParse(Console.ReadLine(), out num_cases);
        for (int i=0; i < num_cases; i++){
            string[] pair = Console.ReadLine().Split(' ');
            int a,b;
            int.TryParse(pair[0], out a);
            int.TryParse(pair[1], out b);
            print_primes(a,b);
        }
    }

    public static void print_primes(int a, int b){
        for (int p = a; p <= b; p++){
            if (!is_checked[p]){
                check_prime(p);
            }
            if (is_prime[p]) {
                Console.WriteLine(p);
            }
        }
    }

    public static void check_prime(int p){
        is_checked[p] = true;
        if (p == 1){
            is_prime[p] = false;
            return;
        }
        for(int n=2; n <= Math.Sqrt(p); n++){
            if (p%n == 0){
                is_prime[p] = false;
                return;
            }
        }
        is_prime[p] = true;
    }
}
