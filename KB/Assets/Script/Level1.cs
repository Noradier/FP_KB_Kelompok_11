using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    public Level1()
    {
        map = new Map(18, 10);
        createLevel();
    }

    protected override void createLevel()
    {
        delete_2x2(8);
        delete_2x2(19);
        delete_2x2(30);
        delete_2x2(33);
        delete_2x2(72);
        delete_2x2(85);
        delete_2x2(88);
        delete_2x2(113);
        delete_2x2(138);
        delete_2x2(141);

        delete_3x3(40);
        delete_3x3(63);
        delete_3x3(127);
        delete_3x3(134);
    }
}
