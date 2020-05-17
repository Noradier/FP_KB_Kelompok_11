using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Level
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        createMap(36, 20);
        shapeMap();
        point = 20;
        spawnPlayer(0);
        spawnPocong(154);
        spawnPocong(161);
        spawnPocong(174);
        spawnPocong(272);
        spawnPocong(304);
        spawnPocong(385);
        spawnPocong(399);
        spawnPocong(417);
        spawnPocong(449);
        spawnPocong(641);
        spawnPocong(692);
        spawnSuster(35);
        spawnSuster(684);
        spawnSuster(719);
        spawnStepPoint(2, this);
        spawnStepPoint(6, this);
        spawnStepPoint(11, this);
        spawnStepPoint(15, this);
        spawnStepPoint(98, this);
        spawnStepPoint(103, this);
        spawnStepPoint(130, this);
        spawnStepPoint(148, this);
        spawnStepPoint(156, this);
        spawnStepPoint(188, this);
        spawnStepPoint(207, this);
        spawnStepPoint(212, this);
        spawnStepPoint(368, this);
        spawnStepPoint(387, this);
        spawnStepPoint(392, this);
        spawnStepPoint(544, this);
        spawnStepPoint(551, this);
        spawnStepPoint(555, this);
        spawnStepPoint(571, this);
        spawnStepPoint(639, this);
    }

    private void shapeMap()
    {
        delete(21, 3, 3);
        delete(25, 2, 2);
        delete(31, 2, 2);
        delete(37, 3, 3);
        delete(41, 3, 3);
        delete(46, 3, 3);
        delete(50, 3, 3);
        delete(54, 2, 2);
        delete(64, 2, 2);
        delete(70, 1, 4);
        delete(134, 2, 2);
        delete(139, 2, 2);
        delete(165, 4, 4);
        delete(180, 2, 2);
        delete(183, 3, 3);
        delete(191, 3, 3);
        delete(195, 2, 3);
        delete(198, 2, 2);
        delete(223, 2, 3);
        delete(242, 2, 3);
        delete(247, 2, 3);
        delete(305, 4, 4);
        delete(325, 2, 2);
        delete(328, 2, 2);
        delete(335, 2, 2);
        delete(338, 2, 2);
        delete(346, 2, 2);
        delete(403, 3, 3);
        delete(422, 3, 3);
        delete(427, 3, 3);
        delete(433, 2, 3);
        delete(436, 2, 3);
        delete(443, 2, 3);
        delete(446, 3, 3);
        delete(453, 4, 4);
        delete(486, 2, 2);
        delete(538, 2, 2);
        delete(547, 2, 3);
        delete(566, 2, 2);
        delete(577, 1, 3);
        delete(579, 3, 3);
        delete(586, 3, 3);
        delete(590, 3, 3);
        delete(606, 3, 3);
        delete(630, 2, 2);
        delete(633, 2, 3);
        delete(636, 2, 2);
        delete(675, 2, 2);
        delete(681, 2, 2);
    }

    public override void decreasePoint()
    {
        base.decreasePoint();
        if (point < 1)
            GameManager.changeScene(6);
    }
}
