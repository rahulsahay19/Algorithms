using System;

namespace Sample.bit
{
    public class BitManipulation
    {
       public bool CheckIthBit(int i, int n)
        {
            //a = 12 , 00001100
            int f = 1;
            f = f << i;
            int res = n & f; // this will make as res =8. 
            //This way, we can convert decimal to base 2.
            string binary = Convert.ToString(res, 2);
            if (res == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       //Time complexity:- log(n) as each time, we are dividing by 2. 
       public int CountSetBits(int n)
       {
           int count = 0;
           while (n > 0)
           {
               if ((n & 1) > 0)
               {
                   count++;
               }

               n = n >> 1;
           }

           string binaryCount = Convert.ToString(count, 2);
           
           //return count;
           return count;
       }
       
       //leetcode: Problem 191:- Number of 1 Bits
       public int HammingWeight(uint n)
       {
           int count = 0;
           while (n > 0)
           {
               if ((n & 1) > 0)
               {
                   count++;
               }

               n = n >> 1;
           }

           return count;
       }
    }
}