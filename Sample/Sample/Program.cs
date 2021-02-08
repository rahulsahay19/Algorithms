using System;
using System.Collections.Generic;
using Sample.Arrays;

namespace Sample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Solution solution = new Solution();
            // var result = solution.addBinary("1010110111001101101000", "1000011011000000111100110");
            // Console.WriteLine(result);
            // UInt64 result = (ulong) (long.Parse(A) | long.Parse(B));
            // return result.ToString();
            //  BitManipulation obj = new BitManipulation();
            // // var result = obj.CheckIthBit(1, 12);
            //  var count = obj.CountSetBits(15);
            //  Console.WriteLine("Total set bits:-{0}", count);
            ArrayProblems obj = new ArrayProblems();
            int[,] sample = new int[4, 4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };
            List<List<int>> sample1 = new List<List<int>>();
            sample1.Add(new List<int> {1, 2, 3, 4});
            sample1.Add(new List<int> {5, 6, 7, 8});
            sample1.Add(new List<int> {9, 10, 11, 12});
            sample1.Add(new List<int> {13, 14, 15, 16}); 

          
          //  obj.PrintDiagnoally(sample);
          obj.PrintAntiDiagnoally(sample1);
            // int[,] sample =  [[ 3,1 ],[4,2 ]];//{2, 5, 6, 8, 6, 1, 2, 4, 6};
            // List<List<int>> sample = new List<List<int>>
            // {
            //     new List<int> {1,2}, new List<int> {3,4}
            // };
            //  obj.rotate(sample);
            // var result = obj.plusOne(sample.ToList());
            // foreach (var i in result)
            // {
            //     Console.WriteLine(i);    
            // }

            //    var result = obj.ArrayPairSum(sample.ToList(), 7);
            //  obj.calcList();
            //Console.WriteLine();
            Console.ReadLine();
        }
    }
}


// class Solution {
//     public int singleNumber(List<int> A) {
//         int result = 0;
//         int x, sum;
//         int[] arr = A.ToArray();
//         for(int i =0; i<int.MaxValue; i++)
//         {
//             sum = 0;
//             x = (1 << i);
//             for(int j=0;j<arr.Length;j++)
//             {
//                 if((arr[j] & x) != 0)
//                 {
//                     sum++;
//                 }
//                 if(sum % 3 != 0) {
//                     result |= x;
//                     
//                 }
//             }
//         }
//         return result;
//     }
// }


// public class Solution
// {
//     public string addBinary(string A, string B)
//     {
//         int.MaxValue
//             
//         //  a = "100"
//
//         //  b = "11" , a+b = 111
//         UInt64 result = (ulong) (long.Parse(A) | long.Parse(B));
//         return result.ToString();
//     }
// }
//     class Solution
//     {
//         public int singleNumber(List<int> A)
//         {
//             var firstElement = A.First();
//             foreach (var i in A)
//             {
//                 firstElement = firstElement ^ i;
//             }
//
//             return firstElement;
//         }
//         
//         public int singleNumber(List<int> A)
//         {
//             var firstElement = 0;
//             foreach (var i in A)
//             {
//                 firstElement = firstElement ^ i;
//             }
//
//             return firstElement;
//         }
//     }
// }
//
// public class Solution {
//     // DO NOT MODIFY THE LIST
//     public int singleNumber(final List<Integer> A) {
//         int num = 0;
// 	    
//         for (int val : A) {
//             num ^= val;
//         }
// 	    
//         return num;
// 	    
//     }
// }
//

// }