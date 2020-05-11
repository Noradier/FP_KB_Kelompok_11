using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level
{
    // Kelas abstrak yang digunakan untuk membangun level.

    protected Map map;    // Level memiliki class Map yang dapat digunakan sebagai koordinat bagi semua GameObject

    protected abstract void createLevel();

    protected void delete_2x2(int bottomLeft)
    {
        int M = map.getM();

        map.deleteVertex(bottomLeft);
        map.deleteVertex(bottomLeft + 1);
        map.deleteVertex(bottomLeft + M);
        map.deleteVertex(bottomLeft + M + 1);
    }

    protected void delete_3x3(int bottomLeft)
    {
        int M = map.getM();

        map.deleteVertex(bottomLeft);
        map.deleteVertex(bottomLeft + 1);
        map.deleteVertex(bottomLeft + 2);
        map.deleteVertex(bottomLeft + M);
        map.deleteVertex(bottomLeft + M + 1);
        map.deleteVertex(bottomLeft + M + 2);
        map.deleteVertex(bottomLeft + 2 * M);
        map.deleteVertex(bottomLeft + 2 * M + 1);
        map.deleteVertex(bottomLeft + 2 * M + 2);
    }

    public Map getMap()
    {
        return map;
    }
}
