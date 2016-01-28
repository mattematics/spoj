using System;
using System.Text;

public class Test
{

    public static void Main()
    {
        // get number of tests from input
        int t;
        int.TryParse(Console.ReadLine(), out t);

        // perform each test
        for (int i=0; i<t; i++){
            // read number from input
            // we need to convert it to an array
            // of single digits
            string n = Console.ReadLine();
            int length = n.Length;
            // we make a copy, since one will be
            // modified and compared to the other
            StringBuilder m = new StringBuilder(n);

            // turn m into a palindrome by mirroring
            // the first half of the number
            m = mirror(m);

            // while m <= n we need to increase m
            // but we want to increase m while preserving
            // that it is a palindrome
            // so, e.g. we want to increase like
            // 1221 --> 1331 --> ... --> 2002
            // 121 --> 131 --> ... --> 202
            while (!greater(m,n)) {
                // a,b are the digit positions in m
                // where we will modify m
                int a,b;
                // they start at the center place(s)
                if (length%2 == 0){
                    a = length/2 - 1;
                    b = a + 1;
                }
                else{
                    a = b = length/2;
                }
                // increase to the next larges palindrome
                // by modifying m at a,b
                m = next_palindrome(m, a, b);
            }

            // write out the entire integer
            for (int j=0; j<m.Length; j++){
                Console.Write(m[j]);
            }
            Console.Write("\n");
        }
    }

    public static StringBuilder mirror(StringBuilder m){
        // returns a palindrome created from m
        // by replacing the 2nd half of m by
        // the reverse of the 1st half
        int length = m.Length;
        for (int i=0; i < length/2; i++){
            m[length-1-i] = m[i];
        }
        return m;
    }

    public static bool greater(StringBuilder m, string n){
        // comparison operator for our digit arrays
        // returns true if m > n
        // false otherwise

        if (m.Length != n.Length) {
            return m.Length > n.Length;
        }
        for (int i=0; i < n.Length; i++){
            if (m[i] != n[i]){
                return (int)m[i] > (int)n[i];
            }
        }
        return false;
    }

    public static StringBuilder next_palindrome(StringBuilder m, int a, int b){
        // find the next largest palindrome after m
        // by increasing at positions a and b
        int length = m.Length;

        // if we've carried past the left side
        // e.g. when doing 99 + 1
        if (a < 0){
            // increase the length of our array
            // so we can return [1,0,...,0,1]
            m = new StringBuilder('1' + m.ToString());
            m[length] = '1';
            return m;
        }
        else if (m[a] < '9'){
            // increase the digit
            // no carrying needed
            m[a] = m[b] = (char)((int)m[a] + 1);
            return m;
        }
        else{
            // carrying needed, set to 0
            // and increase the next digits
            m[a] = m[b] = '0';
            return next_palindrome(m, a-1, b+1);
        }
    }

}
