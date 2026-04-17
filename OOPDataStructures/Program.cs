using System.Drawing;
using System.Security.Cryptography;

public class BinarySearchTreeNode
{
    private BinarySearchTreeNode? left; //? means can be null AKA nullable
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
        //If data is less, add it to left subtree or make a new left child        
        if (aData < data)
            if (left == null)
                left = new BinarySearchTreeNode(aData);
            else
                left.add(aData);
           
        else //same for right..
            if (right == null)
                right = new BinarySearchTreeNode(aData);
            else
                right.add(aData);
    }

    public void inOrderTraversal()
    {
        left?.inOrderTraversal(); //(in C# ?. means only call the method if left is not null)
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
    public int Pop() 
    {
        if (topItemPointer == -1)
        {
            throw new Exception("Stack is empty");
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