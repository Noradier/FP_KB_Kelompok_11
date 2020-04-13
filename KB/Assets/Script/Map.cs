using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private int M, N, size;
    private int[,] graph;   // Graph, direpresentasi dalam bentuk adjacency matrix

    // Constructor untuk Map
    public Map(int M, int N)
    {
        this.M = M;
        this.N = N;
        size = M * N;
        initGraph(M, N);
    }

    // Inisiasi graph: adjacency matrix dibuat dan diisi dengan 0 untuk semua nilai.
    private void initGraph(int M, int N)
    {
        graph = new int[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                graph[i, j] = 0;
    }

    // Menambahkan edge pada graph
    public void addEdge(int i, int j)
    {
        graph[i, j] = 1;
        graph[j, i] = 1;
    }

    public void addEdge(int[,] arr)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                graph[i, j] = arr[i, j];
        }
    }

    public int getM()
    {
        return M;
    }

    public int getN()
    {
        return N;
    }

    public int getGraph(int i, int j)
    {
        return graph[i, j];
    }

}
