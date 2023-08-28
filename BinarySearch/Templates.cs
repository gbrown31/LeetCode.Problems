namespace BinarySearch;

public class Templates
{
    // target 7
    // 1,4,6,8,10
    // left = 0, right = 4, mid = 2 (6)
        // mid < target, left = mid+1 (3), right = 4
    // mid = (4-3)/2 = 0 + left (3) = 3 (8)
        // mid > target, right = 3 - 1 = 2
    // right is now les than left
    // return -1
    public int FindTarget(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        // to find a target we want to search every index of the array
        // left can be equal to right
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                // do something
                return mid;
            }

            if (arr[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        List<int> list = new();

        (string name, int age) something = ("gary", 38);

        

        // target is not in arr
        return -1;
    }

    public int FindTargetOrLeftInsertion(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                // do something
                return mid;
            }

            if (arr[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        // target is not in arr, but left is at the insertion point
        return left;
    }

    public int DuplicateTargetsLeftInsertion(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] >= target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
    public int DuplicateTargetsRightInsertion(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] > target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}