using System;
using System.Collections.Generic;

public class Test
{
    // for memoization
    // need longs because the dollar value can grow out of int
    public static Dictionary<int,long> knownVals = new Dictionary<int,long>();

    public static void Main()
    {
        int n;
        string line;
        // unknown number of input lines
        while((line = Console.ReadLine()) != null && line != ""){
            int.TryParse(line, out n);
            Console.WriteLine(maxDollars(n));
        }
        
    }

    public static long maxDollars(int n){
        // check if we've already seen this coin value
        if (knownVals.ContainsKey(n)){
            return knownVals[n];
        }
        // otherwise, compute it recursively
        // and store it
        else{
            if (n==0){
                knownVals[n] = 0;
                return 0;
            }
            knownVals[n] = Math.Max(n, maxDollars(n/2) + maxDollars(n/3) + maxDollars(n/4));
            return knownVals[n];
        }
    }
}
