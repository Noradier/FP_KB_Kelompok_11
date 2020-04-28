using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private int M, N, size;
    private int[,] graph;   // Graph, direpresentasi dalam bentuk adjacency matrix

    // Constructor untuk Map
    public Map(int M, int N)
    {
        this.M = M;
        this.N = N;
        size = M * N;
        initGraph();
    }

    // Inisiasi graph: adjacency matrix dibuat dan diisi dengan 0 untuk semua nilai.
    private void initGraph()
    {
        graph = new int[size, size];

        for(int i=0; i<size; i++)
        {
            if(i < M)
            {
                if(i%M == 0)
                {
                    addEdge(i, i + 1);
                    addEdge(i, i + M);
                }
                else if((i+1)%M == 0)
                {
                    addEdge(i, i - 1);
                    addEdge(i, i + M);
                }
                else
                {
                    addEdge(i, i + 1);
                    addEdge(i, i - 1);
                    addEdge(i, i + M);
                }
            }
            else if(i + M > size - 1)
            {
                if (i % M == 0)
                {
                    addEdge(i, i + 1);
                    addEdge(i, i - M);
                }
                else if ((i + 1) % M == 0)
                {
                    addEdge(i, i - 1);
                    addEdge(i, i - M);
                }
                else
                {
                    addEdge(i, i + 1);
                    addEdge(i, i - 1);
                    addEdge(i, i - M);
                }
            }
            else
            {
                if (i % M == 0)
                {
                    addEdge(i, i + 1);
                    addEdge(i, i + M);
                    addEdge(i, i - M);
                }
                else if ((i + 1) % M == 0)
                {
                    addEdge(i, i - 1);
                    addEdge(i, i + M);
                    addEdge(i, i - M);
                }
                else
                {
                    addEdge(i, i + 1);
                    addEdge(i, i - 1);
                    addEdge(i, i + M);
                    addEdge(i, i - M);
                }
            }
        }
    }

    // Menambahkan edge pada graph.
    private void addEdge(int i, int j)
    {
        graph[i, j] = 1;
    }

    // Menghapus vertex i sehingga tidak ada vertex yang bisa memasuki vertex i.
    public void deleteVertex(int i)
    {
        if (i < M)
        {
            if (i % M == 0)
            {
                deleteEdge(i, i + 1);
                deleteEdge(i, i + M);
            }
            else if ((i + 1) % M == 0)
            {
                deleteEdge(i, i - 1);
                deleteEdge(i, i + M);
            }
            else
            {
                deleteEdge(i, i + 1);
                deleteEdge(i, i - 1);
                deleteEdge(i, i + M);
            }
        }
        else if (i + M > size - 1)
        {
            if (i % M == 0)
            {
                deleteEdge(i, i + 1);
                deleteEdge(i, i - M);
            }
            else if ((i + 1) % M == 0)
            {
                deleteEdge(i, i - 1);
                deleteEdge(i, i - M);
            }
            else
            {
                deleteEdge(i, i + 1);
                deleteEdge(i, i - 1);
                deleteEdge(i, i - M);
            }
        }
        else
        {
            if (i % M == 0)
            {
                deleteEdge(i, i + 1);
                deleteEdge(i, i + M);
                deleteEdge(i, i - M);
            }
            else if ((i + 1) % M == 0)
            {
                deleteEdge(i, i - 1);
                deleteEdge(i, i + M);
                deleteEdge(i, i - M);
            }
            else
            {
                deleteEdge(i, i + 1);
                deleteEdge(i, i - 1);
                deleteEdge(i, i + M);
                deleteEdge(i, i - M);
            }
        }
    }

    // Menghapus edge pada graph.
    private void deleteEdge(int i, int j)
    {
        graph[i, j] = 0;
        graph[j, i] = 0;
    }

    // Kumpulan getter dan setter.

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
