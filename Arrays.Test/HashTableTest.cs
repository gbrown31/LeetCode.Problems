namespace Arrays.Test;

public class HashTableTest
{
    [Fact]
    public void CheckHashtable()
    {
        Hashtable hashtable = new Hashtable();

        hashtable.Insert(1, 10);
        Assert.Equal(10, hashtable.Get(1));

        hashtable.Insert(2, 20);
        Assert.Equal(10, hashtable.Get(1));
        Assert.Equal(20, hashtable.Get(2));
    }
    
}