namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    private bool _isDescending;
    public DoublyLinkedList()
    {
        _head = null; // This line can be removed
        _tail = null; // This line can be removed
        _isDescending = false;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            _isDescending = false;
            return;
        }
        newNode.Next = _head;
        _head.Prev = newNode;
        _head = newNode;
    }
    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            _isDescending = false;
            return;
        }

        var current = _head;

        // Buscar posición según el orden actual
        if (!_isDescending)
        {
            while (current != null && current.Data!.CompareTo(data) < 0)
                current = current.Next;
        }
        else
        {
            while (current != null && current.Data!.CompareTo(data) > 0)
                current = current.Next;
        }

        if (current == _head) // Al inicio
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
        else if (current == null) // Al final
        {
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
        else // En el medio
        {
            newNode.Next = current;
            newNode.Prev = current.Prev;
            current.Prev!.Next = newNode;
            current.Prev = newNode;
        }
    }
    public void InsertAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        _tail.Next = newNode;
        newNode.Prev = _tail;
        _tail = newNode;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data)) // Found
            {
                if (current.Prev == null) // Beginning 
                {
                    current.Next!.Prev = null;
                    _head = _head!.Next;
                    return;
                }
                if (current.Next == null) // End 
                {
                    current.Prev!.Next = null;
                    _tail = _tail!.Prev;
                    return;
                }
                // Middle
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
                return;
            }
            current = current.Next;
        }
    }

    public override string ToString()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Next;
        }
        return $"{output} null";
    }

    public string ToStringReverse()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Prev;
        }
        return $"{output} null";
    }
}
