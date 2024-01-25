using System;

public class DynamicArray<T>
{
    private T[] array;
    private int size; 
    private int capacity;

    public DynamicArray(int initialCapacity)
    {
        if (initialCapacity < 0)
        {
            throw new Exception("Capacity of the Array cannot be negative");
        }

        array = new T[initialCapacity];
        size = 0; 
        capacity = initialCapacity;
    }

    public int Count
    {
        get { return size; }
    }

    public void Add(int index, T item)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        if (size >= capacity)
        {
            ResizeArray(index + 1);
        }

        for (int i = size; i > index; i--)
        {
            array[i] = array[i-1];
        }

        array[index] = item;
        size = Math.Max(size, index+1);
    }

    private void ResizeArray()
    {
        capacity *= 2;
        T[] newArray = new T[capacity];
        Array.Copy(array, newArray, Count);
        array =  newArray;
    }
    
    public T this[int index]
    {
        get { 
        if ( index > size)
        {
            throw new Exception("Index accessed is not present in the Array");
        }
        return array[index]; }
    }

}

public class Program
{
    static void Main()
    {
        DynamicArray<int> numbers = new DynamicArray<int>(2);
        numbers.Add(0, 100);
        numbers.Add(1, 200);
        numbers.Add(2, 300);
        numbers.Add(3, 400);
        int value = numbers[2];
        System.Console.WriteLine($"Total Number Of Items in Array:{numbers.Count} ,Value:{value} at index:2");

        DynamicArray<string> stringItems = new DynamicArray<string>(2);
        stringItems.Add(0, "100");
        stringItems.Add(1, "200");
        stringItems.Add(2, "300");
        stringItems.Add(3, "400");
        string itemValue = stringItems[3];
        System.Console.WriteLine($"Total Number Of Items in Array:{stringItems.Count} , Value:{itemValue} at index:3");
        Console.ReadKey();
    }
}
