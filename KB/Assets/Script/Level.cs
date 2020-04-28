using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level
{
    // Kelas abstrak yang digunakan untuk membangun level.

    protected Map map;    // Level memiliki class Map yang dapat digunakan sebagai koordinat bagi semua GameObject

    public Map getMap()
    {
        return map;
    }
}
