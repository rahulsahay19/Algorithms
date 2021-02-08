using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sample.Arrays
{
    public class ArrayProblems
    {
        public List<string> FizzBuzz(int A)
        {
            //divisible by 3 -> fizz
            //divisible by 5 -> buzz
            //divisible by both -> fizzbuzz
            var result = new List<string>();
            for (int i = 1; i <= A; i++)
            {
                //no divisible by 3 and 5
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else

                    result.Add(i.ToString());
            }

            return result;
        }

        //Given an array of integers A, update every element with multiplication of previous and next elements with following exceptions.
        //a) First element is replaced by multiplication of first and second.
        //b) Last element is replaced by multiplication of last and second last.
        // Input 1:
        // A = [1, 2, 3, 4, 5]
        // Output 1:
        // [2, 3, 8, 15, 20]
        //
        // Input 2:
        // A = [5, 17, 100, 11]
        // Output 2:
        // [85, 500, 187, 1100]
        //always dry run and check for <= in loop
        public List<int> MultiplyPreAndNext(List<int> A)
        {
            var arr = A.ToArray();
            int[] res = new int[A.Count];
            //Handled corner case, if A-> [0]
            if (arr.Length > 1)
            {
                //First element
                res[0] = arr[0] * arr[1];
                //Last element
                res[arr.Length - 1] = arr[arr.Length - 1] * arr[arr.Length - 2];
                //Loop from 2nd element to 2nd last
                for (int i = 1; i <= arr.Length - 2; i++)
                {
                    res[i] = arr[i - 1] * arr[i + 1];
                }

                return res.ToList();
            }
            else
            {
                res[0] = 0;
            }

            return res.ToList();
        }

        //Given Array is [1, 2, 3].
        //The returned Array should be [1, 2, 4] as 123 + 1 = 124.
        public List<double> plusOne(List<double> A)
        {
            var arr = A.ToArray();
            double[] res = new Double[arr.Length];
            string interMediateString = String.Empty;
            //   Int64 maxLength = Convert.ToInt64(interMediateString);
            // if(maxLength < Int32.MaxValue){
            //Handled corner case, if A-> [0]
            if (arr.Length > 1)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    interMediateString += arr[i].ToString();
                }

                double maxLength = Convert.ToDouble(interMediateString);

                //  if (maxLength < Int32.MaxValue)
                //{
                double newNumber = Convert.ToDouble(interMediateString) + 1;
                //TODO: Need to use more raw approach rather than this
                var charArr = newNumber.ToString().ToCharArray();
                res = Array.ConvertAll(charArr, c => (double) Char.GetNumericValue(c));
                return res.ToList();
                //}
            }
            else
            {
                res[0] = 0;
            }

            return res.ToList();
        }

        public List<int> plusOne(List<int> A)
        {
            var arr = A.ToArray();
            int size;
            int carry = 1;
            int num = 0;

            size = A.Count();
            for (int i = size - 1; i >= 0; i--)
            {
                num = A[i];
                num += carry;
                carry = 0;

                if (num == 10)
                {
                    num = 0;
                    carry = 1;
                }

                A[i] = num;
            }

            List<int> res = new List<int>();
            if (carry == 1)
            {
                res.Add(1);
            }

            foreach (var item in A)
            {
                if (item == 0 && res.Count == 0)
                {
                    continue;
                }

                res.Add(item);
            }

            return res;
        }

        //Rotate an array by k element
        public void Rotate(int[] nums, int k)
        {
            //An array length can be less than k or equal to k
            k = k % nums.Length;
            ReverseArray(nums, 0, nums.Length - 1);
            ReverseArray(nums, 0, k - 1);
            ReverseArray(nums, k, nums.Length - 1);
        }

        private void ReverseArray(int[] nums, int start, int end)
        {
            //Two pointers approach
            while (start < end)
            {
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        //Rotate and return a matrix
        //Need to check on C# for this
        public List<List<int>> RotateAndReturnMatrix(List<int> A, List<int> B)
        {
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < B.Count; i++)
            {
                List<int> row = new List<int>();
                int k = B[i] % A.Count;
                // row.AddRange(ReverseArray1(A.ToArray(),0, k-1));
                //    row.AddRange(ReverseArray1(A.ToArray(),k, A.Count-1));
                row.AddRange(A.GetRange(k, A.Count));
                row.AddRange(A.GetRange(0, k));
                result.Add(row);
            }

            return result;
        }

        //Primal Power
        //Given an array of intergers, just return the count of prime nos from it.
        public int PrimalPower(List<int> A)
        {
            //scan array
            //check for prime no
            var resArr = A.ToArray();
            int count = 0;
            foreach (var item in A)
            {
                //checkPrime
                //if yes, then increase the coun and return
                if (CheckPrimeNumber(item) == true)
                {
                    count++;
                }
            }

            return count;
        }

        private bool CheckPrimeNumber(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        //Given an array A and a integer B. A pair(i,j) in the array is a good pair if i!=j and (A[i]+A[j]==B).
        //Check if any good pair exist or not.
        // A = [1,2,3,4]
        //B = 7
        //Output 1 since (3+4) = 7, hence 1 else 0
        public int ArrayPairSum(List<int> A, int B)
        {
            int i = 0;
            bool flag = false;
            while (i < A.Count)
            {
                for (int j = 1; j < A.Count; j++) //with 1
                {
                    if (i != j)
                    {
                        if (A[i] + A[j] == B)
                        {
                            flag = true;
                            break;
                        }
                    }
                }

                i++;
            }

            if (flag)
                return 1;
            return 0;
        }

        //Time to equality
        //Given an integer array A of size N. In one second you can increase the value of one element by 1
        //Find the minimum time in seconds to make all elements of the array equal
        //A = [2, 4, 1, 3, 2]
        //O/p = 8
        public int TimeToEquality(List<int> A)
        {
            int max = A[0];

            int count = 0;
            //Check higest number in array
            //then compare each element with this, find the different and increase the counter
            max = MaxInArray(A, max);

            count = CalculateDiffernce(A, max, count);
            return count;
        }

        private static int CalculateDiffernce(List<int> A, int max, int count)
        {
            foreach (var item in A)
            {
                int incr = 0;
                if (item < max)
                {
                    incr = max - item;
                    count += incr;
                }
            }

            return count;
        }

        private static int MaxInArray(List<int> A, int max)
        {
            foreach (var item in A)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        //Multi dimensional arrays
        public int MaxNoOfOnes(int[,] arr)
        {
            int row = 0, i, j;

            for (i = 0, j = arr.Length - 1; i < arr.Length; i++)
            {
                // find left most position of 1 in 
                // a row find 1st zero in a row 
                while (arr[i, j] == 1 && j >= 0)
                {
                    row = i;
                    j--;
                }
            }

            return row;
        }

        public void RotateMatrix(int[][] A)
        {
            int n = A.Length;
            //loop through rows
            for (int i = 0; i < n; i++)
            {
                //loop through columns
                for (int j = i; j < n; j++)
                {
                    //Transpose
                    int temp = A[i][j];
                    A[i][j] = A[j][i];
                    A[j][i] = temp;
                }
            }

            //swap using two pointers
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = A[i][j];
                    A[i][j] = A[i][n - 1 - j];
                    A[i][n - 1 - j] = temp;
                }
            }
        }

        //print Diagnoally
        //m*n matrix, m = rows, n = cols
        public void PrintDiagnoally(int[,] a)
        {
            int m = a.GetLength(0); //row count
            int n = a.GetLength(1); //col count
            for (int k = 0; k <= m - 1; k++)
            {
                int i = k;
                int j = 0;
                while (i >= 0)
                {
                    Console.WriteLine(a[i, j]);
                    i = i - 1;
                    j = j + 1;
                }
            }

            for (int k = 1; k <= n - 1; k++)
            {
                int i = m - 1;
                int j = k;
                while (j <= n - 1)
                {
                    Console.WriteLine(a[i, j]);
                    i = i - 1;
                    j = j + 1;
                }
            }
        }
        //TODO Need to check this approach
        // public void antiDiagonal(int[,] A)
        // {
        //     int N = A.Length;
        //
        //     // For each column start row is 0
        //     for (int col = 0; col < N; col++) {
        //         int startcol = col, startrow = 0;
        //
        //         while (startcol >= 0 && startrow < N) {
        //             Console.Write(A[startrow, startcol] + " ");
        //             startcol--;
        //             startrow++;
        //         }
        //         Console.WriteLine();
        //     }
        //
        //     // For each row start column is N-1
        //     for (int row = 1; row < N; row++) {
        //         int startrow = row, startcol = N - 1;
        //
        //         while (startrow < N && startcol >= 0) {
        //             Console.Write(A[startrow, startcol] + " ");
        //             startcol--;
        //             startrow++;
        //         }
        //         Console.WriteLine();
        //     }
        // }

        //print anti Diagnoally
        //m*n matrix, m = rows, n = cols
        public void PrintAntiDiagnoally(List<List<int>> A)
        {
            int n = A.Count;
            int noOfDiagnoals = 2 * n - 1;

            //Create a nested list with total no of diagnoals
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < noOfDiagnoals; i++)
            {
                result.Add(new List<int>());
            }

            //Push each element in the result list
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i + j].Add(A[i][j]);
                }
            }

            //print the diagonals
            //length of row
            for (int i = 0; i < result.Count; i++)
            {
                //Length of column
                for (int j = 0; j < result[i].Count; j++)
                {
                    Console.Write(result[i][j] + " ");
                  
                }
                Console.WriteLine();
            }
        }
    
    //solve 2d programs using java 
    //then solve using C# locally
    //then solve problems discussed using leet code.
    //Java Implementation Rotate the array by 90 degree
    // public class Solution {
    //     public void solve(int[][] A) {
    //         int n = A.length;
    //         //loop through rows
    //         for(int i =0; i<n;i++){
    //             //loop through columns
    //             for(int j=i;j<n;j++){
    //                 //Transpose
    //                 int temp = A[i][j];
    //                 A[i][j] =  A[j][i];
    //                 A[j][i] = temp;
    //             }
    //     
    //         }
    //         //swap using two pointers
    //         for(int i =0; i<n;i++){
    //             for(int j=0;j<n/2;j++){
    //                 int temp = A[i][j];
    //                 A[i][j] =  A[i][n-1-j];
    //                 A[i][n-1-j] = temp;
    //             }
    //         }
    //     }
    // }

    //Java implementation
    // public ArrayList<ArrayList<Integer>> solve(ArrayList<Integer> A, ArrayList<Integer> B) {
    //     ArrayList<ArrayList<Integer>> result = new ArrayList<>();
    //     for (int i = 0; i < B.size(); i ++) {
    //         ArrayList<Integer> row = new ArrayList<>();
    //         int pivot = B.get(i) % A.size();
    //         row.addAll(A.subList(pivot, A.size()));
    //         row.addAll(A.subList(0, pivot));
    //         result.add(row);
    //     }
    //     return result;
    // }


    // Problem Description
    //
    // Given a matrix of integers A of size N x M and an integer B.
    //     In the given matrix every row and column is sorted in increasing order. Find and return the position of B in the matrix
    // the given form:
    // If A[i][j] = B then return (i * 1009 + j)
    // If B is not present return -1.
    //
    // Note 1: Rows are numbered from top to bottom and columns are numbered from left to right.
    //     Note 2: If there are multiple B in A then return the smallest value of i*1009 +j such that A[i][j]=B.
    //
    //
    //     Problem Constraints
    // 1 <= N, M <= 1000
    // -100000 <= A[i] <= 100000
    // -100000 <= B <= 100000
    //
    //
    // Input Format
    // The first argument given is the integer matrix A.
    //     The second argument given is the integer B.
    //
    //
    //     Output Format
    // Return the position of B and if it is not present in A return -1 instead.
    //
    // Example Input
    // A = [ [1, 2, 3]
    // [4, 5, 6]
    // [7, 8, 9] ]
    // B = 2
    //
    //
    // Example Output
    // 1011
    //
    //
    // Example Explanation
    // A[1][2]= 2
    // 1*1009 + 2 =1011
    //https://stackoverflow.com/questions/34165994/get-index-of-value-in-a-nested-list
    public int matrixCalc(List<List<int>> A, int B)
    {
    int res = 0;
    int n = A.Count;
    int m = A[0].Count;

    int u = 0, v = -1;
        while (u<n && v >= 0)
    {
        if (A[u][v] == B) return (u + 1) * 1009 + (v + 1);
        else if (A[u][v] > B) v--;
        else u++;
    }

    return -1;
}
//Example
//[
// [1, 2],
// [3, 4]
// ]

//Output
// [
// [3, 1],
// [4, 2]
// ]
//Rotate the 2D array by 90D
public void rotate(List<List<int>> a)
{
    var resultArr = a.ToArray();

    //First transpose and then reverse
    // var result = a
    //     .SelectMany(inner => inner.Select((item, index) => new { item, index }))
    //     .GroupBy(i => i.index, i => i.item)
    //     .Select(g => g.ToList())
    //     .ToList();
    List<List<int>> rotated = Enumerable.Range(0, a.Max(list => list.Count))
        .Select(i => a.Select(list => list.ElementAtOrDefault(i)).ToList())
        .ToList();
    Console.WriteLine("first, {0}, {1}", rotated[0][0], rotated[0][1]);
    for (int i = 0, j = 0; i < rotated[i].Count - 1; i++, j++)
    {
        Console.WriteLine(rotated[i][j]);
    }

    // foreach (var list in rotated)
    // {
    //     //
    //     foreach (var item in list)
    //     {
    //         Console.WriteLine(item);
    //         
    //     }
    // }
    //   Console.WriteLine(result);
}

//Anti Diagonal https://www.geeksforgeeks.org/return-an-array-of-anti-diagonals-of-given-nn-square-matrix/

//List<List<int>>
public void calcList()
{
    List<List<int>> myTable = new List<List<int>>
    {
        new List<int> {1, 2, 3}, new List<int> {4, 5, 6, 7}, new List<int> {8, 9, 10}
    };
    Console.WriteLine($"Nested list print:-{myTable[0][1]}");
    foreach (var list in myTable)
    {
        // Console.WriteLine(list); // will print System.Collections.Generic.List`1[System.Int32] -->3 times
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}

//Print OddEven sequence 
//A = [1, 2, 2, 5, 6]
//Maximum length odd even subsequence is [1, 2, 5, 6]
//Note: An array B is a subsequence of an array A if B can be obtained from A by deletion of several (possibly, zero or all) elements.
//TODO:-This will be done by dynamic programming
//Link:- https://www.youtube.com/watch?v=r2I7KIqHTPU
public int PrintOddEvenSequence(List<int> A)
{
    //check first number is odd or not
    //then check next number for even and then odd
    //then push the same in result array and form the sequence
    return 1;
}

//https://www.geeksforgeeks.org/longest-increasing-odd-even-subsequence/
// public int OddEvenSubSequence(List<int> A)
// {
//     //iterate over A
//     //divide by 2, then even else odd
//     //count the length and then return
//     int count = 0;
//     List<int> result = new List<int>();
//     for (int i = 1; i <=A.Count; i++)
//     {
//         if (i == 1)
//         {
//             result.Add(i);
//             count++;
//         }
//         else if (i % 2 == 0)
//         {
//             result.Add(i);
//             count++;
//         }
//     }
// }
}
}