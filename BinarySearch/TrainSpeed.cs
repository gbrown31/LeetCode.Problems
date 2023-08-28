namespace BinarySearch;

public class TrainSpeed
{
    private double TimeLimit = 0;
    public int MinSpeedOnTime(int[] dist, double hour)
    {
        if (dist.Length > Math.Ceiling(hour))
        {
            return -1;
        }
        // for train distances dist, calculate if what speed the train must be going to 
        // traverse all the train stations by hour
        TimeLimit = hour;
        int left = 0,
            right = Convert.ToInt32(Math.Pow(10, 7));

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (checkIfAllTrainsMakeItOnTime(mid, dist))
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private bool checkIfAllTrainsMakeItOnTime(int speed, int[] dist)
    {
        if (speed == 0)
        {
            return false;
        }
        double totalTime = 0;
        for (int i = 0; i < dist.Length; i++)
        {
            totalTime = Math.Ceiling(totalTime);
            totalTime += dist[i] / (double) speed;
        }

        return totalTime <= TimeLimit;
    }
}