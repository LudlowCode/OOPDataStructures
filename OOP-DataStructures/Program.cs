using System.Drawing;

public class BinarySearchTreeNode
{
    private BinarySearchTreeNode? left;
    private BinarySearchTreeNode? right;
    private int data;

    public BinarySearchTreeNode(int aData)
    {
        data = aData;
        left = null;
        right = null;
    }
    public void add(int aData)
    {
        //If data is less, add it to left subtree..
        if (aData < data)
        {
            left?.add(aData);
            //..or make it the left child if left pointer is null.
            left ??= new BinarySearchTreeNode(aData);
        }
        else //same for right..
        {
            right?.add(aData);
            right ??= new BinarySearchTreeNode(aData);
        }
    }

    public void inOrderTraversal()
    {
        left?.inOrderTraversal();
        Console.WriteLine(data);
        right?.inOrderTraversal();
    }
    public void preOrderTraversal()
    {
        Console.WriteLine(data);
        left?.preOrderTraversal();
        right?.preOrderTraversal();
    }
    public void postOrderTraversal()
    {
        left?.postOrderTraversal();
        right?.postOrderTraversal();
        Console.WriteLine(data);
    }
}

public class IntStack
{
    int maxSize;
    int [] data;
    int topItemPointer;

    public IntStack(int size)
    {
        maxSize = size;
        data = new int[maxSize];
        topItemPointer = -1;
    }

    public bool Push(int numToAdd)
    {
        if (topItemPointer == maxSize - 1)
        {
            return false;
        }
        else
        {
            topItemPointer++;
            data[topItemPointer] = numToAdd;
            return true;
        }
    }
    public int? Pop() 
    {
        if (topItemPointer == -1)
        {
            return null;
        }
        else
        {
            topItemPointer--;
            return data[topItemPointer+1];
        }
    }
}
public class Program
{
    //Main runs automatically when the Program is run

    static void Main(string[] args)
    {
        TestBST();
        TestStack();
    }

    private static void TestStack()
    {
        int stackSize = 5;
        IntStack myInts = new IntStack(stackSize);
        for (int i = 0; i < stackSize; i++)
        {
            myInts.Push((int)Math.Round((double)new Random().Next()));
        }
        for (int i = 0; i < stackSize; i++){
            Console.WriteLine(myInts.Pop());
        }
    }

    private static void TestBST()
    {
        BinarySearchTreeNode bst = new BinarySearchTreeNode(10);
        bst.add(3);
        bst.add(2);
        bst.add(31);
        bst.add(35);
        bst.add(30);
        bst.inOrderTraversal();
        Console.WriteLine("");
        bst.preOrderTraversal();
        Console.WriteLine();
        bst.postOrderTraversal();
    }
}