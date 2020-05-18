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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        GameManager.changeScene(4);
    }
}
