using System;

public class Test
{

    public static void Main()
    {
        string s;
        string[] nums = new string[27];
        for(int i=0; i<27; i++){
            nums[i] = ""+i;
        }

        // unknown number of input lines
        // 0 terminated
        while(true){
            s = Console.ReadLine();
            if (s=="0"){
                break;
            }
            Console.WriteLine(waysToDecode(s));
        }
        
    }

    public static long waysToDecode(string s){
        // inductively compute the number of ways to decode s
        // by moving along from left to right
        // tracking whether numbers can be grouped in pairs
        // at each position

        // the number of ways to get to the current position
        // depends on the ways to get to the previous 2 positions
        // and whether groupings are possible

        // to store the number of ways
        // to decode the first n+1 digits
        int[] ways = new int[s.Length];
        // to store whether the position can be paired
        // with the next: 1 (no), 2 (yes)
        int[] state = new int[s.Length];
        
        for (int n=0; n<s.Length; n++){
            // base case
            if (n == 0){
                // first digit is always able to decode
                ways[n] = 1;

                // get digit so we can set states
                int a = (int)(s[n] - '0');
                if (a < 3){
                    // could start 2 digit number
                    state[n] = 2;
                }
                else{
                    // cannot start 2 digit number;
                    state[n] = 1;
                }
            }
            // inductive steps
            if (n > 0){
                // get previous and current digit
                int a = (int)(s[n-1] - '0');
                int b = (int)(s[n] - '0');
                
                // if current digit is 0, it must be paired back
                if (b == 0){
                    if (n > 1){
                        // handle cases like 110
                        ways[n-1] = ways[n-2];
                        ways[n] = ways[n-2];
                    }
                    else{
                        ways[n] = ways[n-1];
                    }
                    // cannot be grouped forward
                    state[n] = 1;
                }
                else{
                    // can view b alone since b > 0
                    ways[n] = ways[n-1];
                    // check if there's also 
                    // a valid grouping backward
                    if (state[n-1] == 2 && a*10 + b < 27){
                        if (n-2 < 0){
                            ways[n] += 1;
                        }
                        else{
                            ways[n] += ways[n-2];
                        }
                    }
                    // set state
                    if (b < 3){
                        state[n] = 2;
                    }
                    else{
                        state[n] = 1;
                    }
                }
            }
        }

        return ways[s.Length-1];
    }
}
