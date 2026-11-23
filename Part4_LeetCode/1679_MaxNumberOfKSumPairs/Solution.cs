using System;

public class Solution
{
    public int MaxOperations(int[] nums, int k)
    {
        Sort the array at first
        Array.Sort(nums);


        int counter = 0;
        int left = 0;
        int right = nums.Length - 1;


        while (leftright)
        {
            if (nums[left] + nums[right] == k)
            {
                counter++;
                left++;
                right--;

            }
            else if (nums[left] + nums[right]  k)
            {
                right--;
            }
            else if (nums[left] + nums[right]  k)
            {
                left++;
            }
        }

        return counter;

    }
}