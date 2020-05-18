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
        point = 8;
        spawnPlayer(162);
        spawnPocong(14);
        spawnPocong(98);
        spawnPocong(176);
        spawnStepPoint(16, this);
        spawnStepPoint(23, this);
        spawnStepPoint(55, this);
        spawnStepPoint(70, this);
        spawnStepPoint(110, this);
        spawnStepPoint(117, this);
        spawnStepPoint(121, this);
        spawnStepPoint(124, this);
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

    public override void decreasePoint()
    {
        base.decreasePoint();
        if (point < 1)
            GameManager.changeScene(2);
    }
}
