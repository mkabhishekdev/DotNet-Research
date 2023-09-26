public class SingleNumber {
    public int SingleNumberCheck(int[] nums)
    {
        int result;
        for(int i =0 ;i < nums.Length; i++)
        {
            for(int j=i+1; j < nums.Length ; j++)
            {
                if(nums[i] == nums[j])
                {
                    break;
                }
            }
            
        }

        return 0;
    }
}


/*
Example 1:
Input: nums = [2,2,1]
Output: 1

Example 2:
Input: nums = [4,1,2,1,2]
Output: 4

*/