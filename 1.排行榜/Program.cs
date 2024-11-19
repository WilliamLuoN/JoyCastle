using System;
using System.Collections.Generic;

public class LeaderboardSystem
{
    static List<int> HeapGetTop(int[] array, int n)
    {
        MinHeap minHeap = new MinHeap(n);
        for (int i = 0; i < n; i++)
        {
            minHeap.Insert(array[i]);
        }

        for (int i = n; i < array.Length; i++)
        {
            if (array[i] >  minHeap.Peek())
            {
                minHeap.ReplaceRoot(array[i]);
            }
        }

        List<int> result = new List<int>();
        while (minHeap.Size > 0)
        {
            result.Add(minHeap.ExtractMin());
        }
        result.Sort((a, b) => b.CompareTo(a)); // 降序排序
        return result;
    }
    public static List<int> GetTopScores(int[] scores, int m)
    {
        // 在这⾥实现你的代码
        List<int> result;
        if (scores.Length == 0||m<=0) 
        {
            return null;
        }
        if (scores.Length <= m) 
        {
            result = new List<int>(scores);
            result.Sort((a,b)=>b.CompareTo(a));
            return result;
        }
        result = HeapGetTop(scores, m);

        return result;
    }


}

class MinHeap
{
    private int[] heap;
    public int Size { get; private set; }
    private int capacity;

    public MinHeap(int capacity)
    {
        this.capacity = capacity;
        this.Size = 0;
        this.heap = new int[capacity];
    }

    private int Parent(int i) { return (i - 1) / 2; }
    private int Left(int i) { return 2 * i + 1; }
    private int Right(int i) { return 2 * i + 2; }

    public void Insert(int key)
    {
        Size++;
        int i = Size - 1;
        heap[i] = key;

        while (i != 0 && heap[Parent(i)] > heap[i])
        {
            Swap(ref heap[i], ref heap[Parent(i)]);
            i = Parent(i);
        }
    }

    public int ExtractMin()
    {
        if (Size <= 0)
            return int.MaxValue;
        if (Size == 1)
        {
            Size--;
            return heap[0];
        }

        int root = heap[0];
        heap[0] = heap[Size - 1];
        Size--;
        MinHeapify(0);

        return root;
    }

    public int Peek()
    {
        return heap[0];
    }

    public void ReplaceRoot(int key)
    {
        heap[0] = key;
        MinHeapify(0);
    }

    private void MinHeapify(int i)
    {
        int l = Left(i);
        int r = Right(i);
        int smallest = i;

        if (l < Size && heap[l] < heap[smallest])
            smallest = l;
        if (r < Size && heap[r] < heap[smallest])
            smallest = r;
        if (smallest != i)
        {
            Swap(ref heap[i], ref heap[smallest]);
            MinHeapify(smallest);
        }
    }

    private void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
}

// 单元测试
public class LeaderboardSystemTests
{
    static public void TestGetTopScores()
    {
        // 在这⾥编写测试⽤例
        int[] array = { 33, 22, 55, 11, 77, 66, 22 };
        List<int> result= LeaderboardSystem.GetTopScores(array,5);
        if (result != null)
        {
            foreach (int num in result)
            {
                Console.Write(num);
            }
            Console.WriteLine();
        }
        else 
        {
            Console.WriteLine("NULL");
        }

        result = LeaderboardSystem.GetTopScores(array, 10);
        if (result != null)
        {
            foreach (int num in result)
            {
                Console.Write(num);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("NULL");
        }
        result = LeaderboardSystem.GetTopScores(array, -1);
        if (result != null)
        {
            foreach (int num in result)
            {
                Console.Write(num);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("NULL");
        }

        int[] array1 = { };
        result = LeaderboardSystem.GetTopScores(array1, 5);
        if (result != null)
        {
            foreach (int num in result)
            {
                Console.Write(num);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("NULL");
        }
    }

    static void Main() 
    {
        TestGetTopScores();
    }
}


