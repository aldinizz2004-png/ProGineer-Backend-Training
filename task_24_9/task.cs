using System;

class Node
{
    private int data;
    private string stringData;
    private Node next;
    private Node prev;


    public Node(int data)
    {
        this.data = data;
        this.stringData = null;
        this.next = null;
        this.prev = null;
    }


    public Node(string stringData)
    {
        this.stringData = stringData;
        this.data = 0;
        this.next = null;
        this.prev = null;
    }


    public int getData()
    {
        return data;
    }


    public void setData(int data)
    {
        this.data = data;
    }


    public string getStringData()
    {
        return stringData;
    }


    public void setStringData(string stringData)
    {
        if (string.IsNullOrEmpty(stringData))
        {
            Console.WriteLine("String cannot be null or empty.");
            return;
        }

        this.stringData = stringData;
    }


    public Node getNext()
    {
        return next;
    }


    public void setNext(Node next)
    {
        this.next = next;
    }


    public Node getPrev()
    {
        return prev;
    }


    public void setPrev(Node prev)
    {
        this.prev = prev;
    }


    ~Node()
    {
        Console.WriteLine("Node destroyed");
    }
}



class DoublyLinkedList
{
    private Node head;
    private Node tail;


    public DoublyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }


    public void AddToEnd(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.setNext(newNode);
            newNode.setPrev(tail);
            tail = newNode;
        }
    }


    public void AddToEnd(string stringData)
    {
        if (string.IsNullOrEmpty(stringData))
        {
            Console.WriteLine("String cannot be null or empty.");
            return;
        }

        Node newNode = new Node(stringData);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.setNext(newNode);
            newNode.setPrev(tail);
            tail = newNode;
        }
    }


    public int RemoveLast()
    {
        if (tail == null)
        {
            Console.WriteLine("List is empty. Cannot remove last element.");
            return -1;
        }

        int value = tail.getData();

        if (tail == head)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail = tail.getPrev();
            tail.setNext(null);
        }

        return value;
    }

    public string RemoveLastString()
    {
        if (tail == null)
        {
            Console.WriteLine("List is empty. Cannot remove last element.");
            return null;
        }

        string value = tail.getStringData();

        if (tail == head)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail = tail.getPrev();
            tail.setNext(null);
        }

        return value;
    }

    public int GetLast()
    {
        if (tail == null)
        {
            Console.WriteLine("List is empty. Cannot get last element.");
            return -1;
        }

        return tail.getData();
    }

    public string GetLastString()
    {
        if (tail == null)
        {
            Console.WriteLine("List is empty. Cannot get last element.");
            return null;
        }

        return tail.getStringData();
    }


    public bool IsEmpty()
    {
        return head == null;
    }


    ~DoublyLinkedList()
    {
        Console.WriteLine("DoublyLinkedList destroyed");
    }
}

class MyStack
{
    private DoublyLinkedList list;


    public MyStack()
    {
        list = new DoublyLinkedList();
    }


    public void Push(int data)
    {
        list.AddToEnd(data);
    }


    public void Push(string stringData)
    {
        if (string.IsNullOrEmpty(stringData))
        {
            Console.WriteLine("String cannot be null or empty.");
            return;
        }

        list.AddToEnd(stringData);
    }

    public int Pop()
    {
        return list.RemoveLast();
    }


    public string PopString()
    {
        return list.RemoveLastString();
    }


    public int Peek()
    {
        return list.GetLast();
    }

    public string PeekString()
    {
        return list.GetLastString();
    }


    public bool IsEmpty()
    {
        return list.IsEmpty();
    }


    ~MyStack()
    {
        Console.WriteLine("MyStack destroyed");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Integer Stack:");

        MyStack intStack = new MyStack();

        intStack.Push(10);
        intStack.Push(20);
        intStack.Push(30);

        Console.WriteLine("Top element: " + intStack.Peek());
        Console.WriteLine("Popped element: " + intStack.Pop());
        Console.WriteLine("Top element after pop: " + intStack.Peek());
        Console.WriteLine("Is stack empty? " + intStack.IsEmpty());


        Console.WriteLine();


        Console.WriteLine("String Stack:");

        MyStack stringStack = new MyStack();

        stringStack.Push("Izz");
        stringStack.Push("Ahmad");
        stringStack.Push("Ali");

        Console.WriteLine("Top element: " + stringStack.PeekString());
        Console.WriteLine("Popped element: " + stringStack.PopString());
        Console.WriteLine("Top element after pop: " + stringStack.PeekString());
        Console.WriteLine("Is stack empty? " + stringStack.IsEmpty());

        Console.WriteLine();
        Console.WriteLine("Testing empty string:");
        stringStack.Push("");
        Console.WriteLine();


        Console.WriteLine("Testing null string:");

        stringStack.Push(null);
    }
}