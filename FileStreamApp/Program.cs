// See https://aka.ms/new-console-template for more information

using System;
using TestApp.TestPrograms;

int[] nums = new[] {0};
var s = new Solution();
var res = s.MaxProduct(nums);
Console.WriteLine(res);

Console.ReadLine();

public class Solution {
    public int MaxProduct(int[] nums)
    {
        int n = nums.Length;
        long max = nums[0];
        bool hasZero = false;
        for (int i = 0; i < nums.Length; i++)
        {
            int l = i;
            while (l < n && nums[l] == 0 ) l++;
            if (l == n)
                break;
            int r = l;
            while (r < n && nums[r] != 0) r++;
            if (r < n)
                hasZero = true;

            long curMax = SearchMax(nums, l, r - 1);
            if (curMax > max)
                max = curMax;

            i = r;
        }

        if (max < 0 && hasZero)
            return 0;
        
        return (int)max;
    }

    long SearchMax(int[] nums, int l, int r)
    {
        if (l == r)
            return nums[l];
        int negCount = 0;
        for(int i = l; i<=r; i++)
            if (nums[i] < 0)
                negCount++;
        if (negCount % 2 == 0)
            return Mult(nums, l, r);

        int lNeg = l;
        while (nums[lNeg] > 0) lNeg++;
        int rNeg = r;
        while (nums[rNeg] > 0) rNeg--;

        
        long lMax = nums[lNeg];
        if (lNeg != r)
        {
            lMax = Mult(nums, lNeg + 1, r);
        }
        long rMax = nums[rNeg];
        if (rNeg != l)
        {
            rMax = Mult(nums, l, rNeg-1);
        }
        
        return long.Max(lMax, rMax);
    }

    long Mult(int[] nums, int l, int r)
    {
        long res = 1;
        for (int i = l; i <= r; i++)
        {
            res *= nums[i];
        }

        return res;
    }
}