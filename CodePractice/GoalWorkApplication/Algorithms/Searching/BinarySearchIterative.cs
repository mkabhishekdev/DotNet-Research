public class BinarySearchIterative
{

    public int CheckForElement(int[] input, int size, int key)
    {
        int low=1, high=size;

        while(low<=high)
        {
            int mid=(low+high)/2;
            if(key == input[mid])
            {
                return key;
            }
            if(key > input[mid])
            {
                low = mid+1;
            }
            else
            {
                high=mid-1;
            }
        }

        return 0;
    }

}