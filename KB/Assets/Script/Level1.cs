using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    public override void Start()
    {
        base.Start();
        createMap(18, 10);
        shapeMap();
        spawnPlayer(0.5f, 9.5f);
        spawnPocong(14.5f, 0.5f);
        spawnPocong(8.5f, 5.5f);
        spawnPocong(14.5f, 9.5f);
    }

    private void shapeMap()
    {
        delete(8, 2, 2);
        delete(19, 2, 2);
        delete(30, 2, 2);
        delete(33, 2, 2);
        delete(72, 2, 2);
        delete(85, 2, 2);
        delete(88, 2, 2);
        delete(113, 2, 2);
        delete(138, 2, 2);
        delete(141, 2, 2);
        delete(40, 3, 3);
        delete(63, 3, 3);
        delete(127, 3, 3);
        delete(134, 3, 3);
    }
}
