public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2
        if (value == Data)
        {
            return true;
        }

        if (value < Data && Left is not null)
        {
            return Left.Contains(value);
        }
        else if (Right is not null) {
            return Right.Contains(value);
        }
        return false;
    }

    public int GetHeight()
    {
        // Problem 4
        if (Left is null && Right is null)
        {
            return 1;
        }

        int heightLeft = 0;
        int heightRight = 0;

        if (Left is not null)
        {
            heightLeft = Left.GetHeight();
        }
        if (Right is not null)
        {
            heightRight = Right.GetHeight();
        }

        if (heightLeft > heightRight)
        {
            return heightLeft + 1;
        }
        else
        {
            return heightRight + 1;
        }
    }
}