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
        spawnPlayer(0);
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
