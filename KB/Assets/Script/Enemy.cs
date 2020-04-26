using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private Player player;
    private Pathfinding pathfinding;

    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
        pathfinding = new Pathfinding(levelMap);
        positionCorrection();
        isMoving = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isMoving)
        {
            move();
        }
        else
        {
            enemyInput();
        }
    }

    private void enemyInput()
    {
        int nextPath = pathfinding.astar(index, player.getIndex());
        int M = levelMap.getM();
        
        if((index + 1) == nextPath)
            initMovement(0.5f, new Vector2(2.0f, 0.0f));
        else if((index - 1) == nextPath)
            initMovement(0.5f, new Vector2(-2.0f, 0.0f));
        else if((index + M) == nextPath)
            initMovement(0.5f, new Vector2(0.0f, 2.0f));
        else if((index - M) == nextPath)
            initMovement(0.5f, new Vector2(0.0f, -2.0f));
        else
            initMovement(0.5f, new Vector2(0.0f, 0.0f));

        isMoving = true;
    }
}
