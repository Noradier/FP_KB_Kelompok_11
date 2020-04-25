using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    List<Node> open;

    public Pathfinding()
    {
        open = new List<Node>();
    }

    public void astar()
    {

    }

    public void addNode(Node node)
    {
        open.Add(node);
        NodeComparer nodeComparer = new NodeComparer();
        open.Sort(nodeComparer);
        toString();
    }

    public class NodeComparer : IComparer<Node>
    {
        public int Compare(Node a, Node b)
        {
            if(a == null)
            {
                // Jika a dan b null, maka mereka equal.
                if (b == null)
                    return 0;

                // Jika a null dan b not null, b lebih besar.
                return -1;
            }
            else
            {
                // Jika a not null dan b null, a lebih besar.
                if (b == null)
                    return 1;

                // Jika kedua Node tidak memiliki FCost yang sama, FCost yang lebih tinggi dialah yang lebih besar.
                int retval = a.getFCost().CompareTo(b.getFCost());
                if (retval != 0)
                    return retval;
                else
                    // Jika kedua node memiliki FCost yang sama, GCost yang lebih tinggi dialah yang lebih besar.
                    return a.getGCost().CompareTo(b.getGCost());
            }
        }
    }

    public void toString()
    {
        string message = "";
        foreach(Node node in open)
        {
            message = message + "[" + node.getFCost() + ", " + node.getGCost() + ", " + node.getIndex() + "]";
        }
        Debug.Log(message);
    }
}