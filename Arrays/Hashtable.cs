namespace Arrays;

public class Hashtable
{
    private object[] hashArray { get; set; }

    public Hashtable()
    {
        hashArray = new object[100];
    }
    public void Insert(int key, int data)
    {
        int hashIndex = getHashCode(key);

        if (hashArray.Length < hashIndex)
        {
            resizeHashArray(Convert.ToInt32(hashArray.Length * 1.5));
        }

        if (hashArray[hashIndex] != null)
        {
            int[] temp = (int[]) hashArray[hashIndex];
            temp[temp.Length] = data;
            hashArray[hashIndex] = temp;
        }
        else
        {
            hashArray[hashIndex] = new int[] {data};
        }
    }

    public int Get(int key)
    {
        int hashIndex = getHashCode(key);
        if (hashIndex < hashArray.Length)
        {
            int[] temp = (int[]) hashArray[hashIndex];
            return temp[0];
        }
        else return -1;
    }

    private void resizeHashArray(int hashArrayLength)
    {
        object[] newHashArray = new object[hashArrayLength];
        for (int i = 0; i < hashArray.Length; i++)
        {
            if (hashArray[i] != null)
            {
                int hashIndex = getHashCode(i);
                newHashArray[hashIndex] = hashArray[i];
            }   
        }

        hashArray = newHashArray;
    }

    private int getHashCode(int key)
    {
        return key % 20;
    }
}