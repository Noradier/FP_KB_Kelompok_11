using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected Player player;
    protected Pathfinding pathfinding;

    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
        pathfinding = new Pathfinding(levelMap);
        positionCorrection();
        isMoving = false;
    }
}
