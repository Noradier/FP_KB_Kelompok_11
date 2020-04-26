using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private int index, parent, fCost, gCost;
    
    public Node(int index, int gCost, int hCost)
    {
        this.index = index;
        parent = -1;
        this.gCost = gCost;
        fCost = gCost + hCost;
    }

    public Node(int index, int parent, int gCost, int hCost)
    {
        this.index = index;
        this.parent = parent;
        this.gCost = gCost;
        fCost = gCost + hCost;
    }

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
