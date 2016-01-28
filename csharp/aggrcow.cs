using System;

public class Test
{
    public static void Main()
    {
        int t = getNumTrials();
        for (int trial=0; trial < t; trial++){
            Console.WriteLine(findMinDiff());
        }
    }

    public static int getNumTrials(){
        int t;
        int.TryParse(Console.ReadLine(), out t);
        return t;
    }

    public static int findMinDiff(){
        //get N, C, stalls
        ProblemStruct info = getProblemInfo();
        
        //sort so we can binary search
        Array.Sort(info.stalls);

        return binarySearch(info);
    }

    public struct ProblemStruct{
        public int N;
        public int C;
        public int[] stalls;
    }

    public static ProblemStruct getProblemInfo(){
        ProblemStruct info = new ProblemStruct();
        string[] s = Console.ReadLine().Split(' ');
        int.TryParse(s[0], out info.N);
        int.TryParse(s[1], out info.C);
        info.stalls = new int[info.N];
        for (int i=0; i<info.N; i++){
            int.TryParse(Console.ReadLine(), out info.stalls[i]);
        }
        return info;
    }

    public static int binarySearch(ProblemStruct info){
        //we will search for the biggest min diff possible
        //for info.C cows placed in info.N many stalls
        //spaced according to info.stalls

        //assumes info.stalls is sorted

        //initial bounds
        int min_diff = 0;
        int max_diff = info.stalls[info.N-1] - info.stalls[0];

        //the loop will preserve min_diff <= max_diff
        //min_diff will always be a solution
        //each step either increases min_diff to a solution
        //or reduces max_diff below a nonsolution
        while(min_diff != max_diff){
            //compute halfway test point
            int halfway = getHalfwayPoint(min_diff, max_diff);
            
            //update based on whether we fit all cows
            if (testCowFit(info, halfway)){
                //all cows fit with diff halfway
                //answer is at least halfway
                //since we might be able to find a larger diff
                min_diff = halfway;
            }
            else{
                //not all cows fit with diff halfway
                //answer is less than halfway
                //since we must find a smaller diff
                max_diff = halfway-1;
            }
        }
        return min_diff;
    }

    public static bool testCowFit(ProblemStruct info, int testDiff){
        //greedy test the testDiff point
        //by seeing how many cows we can add
        //at least that far apart

        //we assume the first cow is at stall[0]
        //since otherwise, the solution could be
        //improved by moving the first cow there
        int i=0;
        int count = 1;

        //we repeatedly look for a next stall
        //which is at least testDiff away
        int j=1;

        while (j < info.N){
            if (info.stalls[j] - info.stalls[i] >= testDiff){
                //if we can fit another cow
                //place one here, and continue
                i = j;
                count++;
                j = i+1;
            }
            else{
                j++;
            }
        }

        if (count >= info.C) {
            return true;
        }
        else{
            return false;
        }
    }

    public static int getHalfwayPoint(int a, int b){
        // returns the maximum
        // of a+1 or halfway point (rounded down) of [a,b]
        int halfway = a + ((b - a)/2);
        return Math.Max(a+1, halfway);
    }
}
