using System;

public class Test
{

    public static void Main()
    {
        int N = readInt();
        int[] A = readA();
        int M = readInt();

        // get partial sums
        // so we can compute subseries
        // using differences
        //int[] S = partialSums(A);

        for(int t=0; t<M; t++){
            ProblemStruct bounds = getBounds();
            Console.WriteLine(query(A,bounds));
        }
        
    }

    public static int readInt(){
        return int.Parse(Console.ReadLine());
    }

    public static int[] readA(){
        string[] s = Console.ReadLine().Split(' ');
        int[] A = new int[s.Length];
        for (int i=0; i<s.Length; i++){
            int.TryParse(s[i], out A[i]);
        }
        return A;
    }

    public static int[] partialSums(int[] A){
        for(int i=1; i<A.Length; i++){
            A[i] += A[i-1];
        }
        return A;
    }

    public struct ProblemStruct{
        public int x;
        public int y;
    }

    public static ProblemStruct getBounds(){
        // input is given 1 indexed
        // so we will shift it
        ProblemStruct bounds = new ProblemStruct();
        string[] s = Console.ReadLine().Split(' ');
        bounds.x = int.Parse(s[0]) - 1;
        bounds.y = int.Parse(s[1]) - 1;
        return bounds;
    }

    public static int query(int[] A, ProblemStruct bounds){
        int currentSum = 0;
        int maxSum = 0;

        for (int i = bounds.x; i <= bounds.y; i++){
            currentSum = Math.Max(0, currentSum + A[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

}
