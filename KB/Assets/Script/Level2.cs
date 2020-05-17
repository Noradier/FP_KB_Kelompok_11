using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    public override void Start()
    {
        base.Start();
        createMap(18, 20);
        shapeMap();        
        point = 17;
        spawnPlayer(0);
        spawnPocong(13);
        spawnPocong(82);
        spawnPocong(111);
        spawnPocong(204);
        spawnPocong(208);
        spawnPocong(214);
        spawnPocong(324);
        spawnPocong(354);
        spawnSuster(70);
        spawnSuster(298);
        spawnSuster(342);
        spawnStepPoint(2, this);
        spawnStepPoint(6, this);
        spawnStepPoint(10, this);
        spawnStepPoint(32, this);
        spawnStepPoint(77, this);
        spawnStepPoint(81, this);
        spawnStepPoint(128, this);
        spawnStepPoint(140, this);
        spawnStepPoint(152, this);
        spawnStepPoint(181, this);
        spawnStepPoint(224, this);
        spawnStepPoint(230, this);
        spawnStepPoint(238, this);
        spawnStepPoint(290, this);
        spawnStepPoint(297, this);
        spawnStepPoint(301, this);
        spawnStepPoint(310, this);
    }

    private void shapeMap()
    {
        delete(16, 2, 2);
        delete(19, 3, 3);
        delete(23, 3, 3);
        delete(27, 3, 3);
        delete(49, 2, 2);
        delete(91, 2, 2);
        delete(94, 3, 3);
        delete(98, 3, 3);
        delete(102, 2, 2);
        delete(105, 2, 3);
        delete(145, 2, 2);
        delete(157, 3, 3);
        delete(166, 2, 2);
        delete(169, 3, 3);
        delete(173, 1, 7);
        delete(199, 2, 2);
        delete(220, 2, 1);
        delete(241, 3, 3);
        delete(247, 3, 3);
        delete(252, 2, 2);
        delete(255, 3, 3);
        delete(304, 1, 3);
        delete(307, 2, 2);
        delete(313, 2, 2);
        delete(316, 2, 2);
        delete(319, 2, 2);
        delete(328, 2, 2);
    }

    public override void decreasePoint()
    {
        base.decreasePoint();
        if (point < 1)
            GameManager.changeScene(4);
    }
}
