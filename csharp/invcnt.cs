using System;

public class Test
{

    public static void Main()
    {
        // read number of test cases followed by blank line
        int T = readInt();
        Console.ReadLine();

        for(int t=0; t<T; t++){
            // get length of test sequence
            int N = readInt();

            int[] arr = new int[N];

            for(int n=0; n<N; n++){
                arr[n] = readInt();
            }
            // read blank line
            Console.ReadLine();

            int[] temp = new int[N];
            Console.WriteLine(mergeSort(arr,temp,0,N-1));
        }
        
    }

    public static int readInt(){
        return int.Parse(Console.ReadLine());
    }

    public static long mergeSort(int[] arr, int[] temp, int left, int right){
        //perform mergeSort and return the number of inversions
        int mid;
        long count = 0;
        if (right > left){
            mid = (right+left)/2;
            //sort left
            count = mergeSort(arr,temp,left,mid);
            //sort right
            count += mergeSort(arr,temp,mid+1,right);
            //merge left and right
            count += merge(arr,temp,left,mid+1,right);
        }
        return count;
    }

    public static long merge(int[] arr, int[] temp, int left, int mid, int right){
        //merges two sorted arrays, counts the number of inversions
        int i,j,k;
        long count = 0;
        i = left;
        j = mid;
        k = left;

        //start at lowest element of both arrays
        while((i <= mid-1) && (j <= right)){
            //if left lowest smaller than right lowest
            if(arr[i] <= arr[j]){
                //put it in temp's next lowest spot
                //and move on
                temp[k] = arr[i];
                k++;
                i++;
            }
            //otherwise, right lowest is smaller
            else{
                temp[k] = arr[j];
                k++;
                j++;
                //there was an inversion so count
                //all the implied inversions because of sorting
                //(future left sides are bigger)
                count += (mid-i);
            }
        }

        //if the two sides were different sizes
        //we fill out the rest of the array
        //with whatever remains
        while(i <= mid-1){
            temp[k++] = arr[i++];
        }
        while(j <= right){
            temp[k++] = arr[j++];
        }

        //write temp back to arr
        for(i=left; i<=right; i++){
            arr[i] = temp[i];
        }

        return count;
    }

}
