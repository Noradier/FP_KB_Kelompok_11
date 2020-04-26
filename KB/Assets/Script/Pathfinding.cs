using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private List<Node> open;
    private Map levelMap;

    public Pathfinding()
    {
        open = new List<Node>();
        open.Add(new Node(0, 100, 100));
    }

    public Pathfinding(Map levelMap)
    {
        this.levelMap = levelMap;
    }

    public void astar(int start, int goal)
    {
        List<Node> openList = new List<Node>();
        List<Node> closeList = new List<Node>();
        openList.Add(new Node(start, 0, 0));

        int gCost = 0;

        while(openList.Count > 0)
        {
            Node current = openList[0];
            openList.Remove(current);
            closeList.Add(current);
            gCost += 10;

            int from, M, N;
            from = current.getIndex();
            if (from == goal)
                break;
            M = levelMap.getM();
            N = levelMap.getN();

            
            
            if (from < (M * N) - 1)
                checkPath(openList, closeList, current, from, from + 1, goal);
            
            if (from > 0)
                checkPath(openList, closeList, current, from, from - 1, goal);

            if (from < M * (N - 1))
                checkPath(openList, closeList, current, from, from + M, goal);

            if (from > M - 1)
                checkPath(openList, closeList, current, from, from - M, goal);
        }
        string message = "";
        foreach (Node node in closeList)
        {
            message = message + "[" + node.getFCost() + ", " + node.getGCost() + ", " + node.getIndex() + "]";
        }
        Debug.Log(message);
    }

    private void checkPath(List<Node> openList, List<Node> closeList, Node current, int from, int to, int goal)
    {
        Node checkClose = closeList.Find(x => x.getIndex() == to);
        if (levelMap.getGraph(from, to) == 0 || checkClose != null)
            return;

        int gCost = current.getGCost() + 10;
        int hCost = calcH(to, goal);
        Node newPath = new Node(to, from, gCost, hCost),
             oldPath = openList.Find(x => x.getIndex() == to);

        if(oldPath == null)
        {
            openList.Add(new Node(to, from, gCost, hCost));
            openList.Sort(new NodeComparer());
        }
        else if((gCost + hCost) < oldPath.getFCost())
        {
            int index = openList.FindIndex(x => x.getIndex() == to);
            openList[index].setFCost(gCost, hCost);
            openList[index].setParent(from);
            openList.Sort(new NodeComparer());
        }

        return;
    }

    private int calcH(int start, int goal)
    {
        int M = levelMap.getM(),
            x = Mathf.Abs((start % M) - (goal % M)),
            y = Mathf.Abs((start / M) - (goal / M));

        return x + y;
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
        Node ex = open.Find(x => x.getIndex() == 30);
        if(ex != null)
        {
            Debug.Log(message + " Found!");
        }
        else
        {
            int index = open.FindIndex(x => x.getIndex() == 0);
            open[index].setFCost(0, 0);
            Node current = open[index];
            //open.Remove(current);
            Debug.Log(message + " Not Found! Remove " + "[" + current.getFCost() + ", " + current.getGCost() + ", " + current.getIndex() + "] " + open.Count);
        }
    }
}