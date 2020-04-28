using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    // Digunakan sebagai objek node dalam list yang digunakan oleh fungsi A* class Pathfinding.

    private int index, parent, fCost, gCost;
    
    // Constructor untuk start node.
    public Node(int index, int gCost, int hCost)
    {
        this.index = index;
        parent = -1;
        this.gCost = gCost;
        fCost = gCost + hCost;
    }

    // Constructor umum untuk node selain start node.
    public Node(int index, int parent, int gCost, int hCost)
    {
        this.index = index;
        this.parent = parent;
        this.gCost = gCost;
        fCost = gCost + hCost;
    }

    // Kumpulan getter dan setter.

    public int getIndex()
    {
        return index;
    }

    public int getParent()
    {
        return parent;
    }

    public int getFCost()
    {
        return fCost;
    }

    public int getGCost()
    {
        return gCost;
    }

    public void setFCost(int gCost, int hCost)
    {
        this.gCost = gCost;
        fCost = gCost + hCost;
    }

    public void setParent(int parent)
    {
        this.parent = parent;
    }
}
