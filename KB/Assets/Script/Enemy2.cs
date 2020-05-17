using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isMoving)
            move();
        else
            enemyInput();
    }

    private void enemyInput()
    {
        int nextPath = pathfinding.astar(index, player.getIndex());
        int M = levelMap.getM();

        float moveSpeed = 1.35f;
        float moveTime = 1.0f / moveSpeed;

        if ((index + 1) == nextPath)
        {
            initMovement(moveTime, new Vector2(moveSpeed, 0.0f));
            movePos = new Vector2(1.0f, 0.0f);
        }
        else if ((index - 1) == nextPath)
        {
            initMovement(moveTime, new Vector2(-moveSpeed, 0.0f));
            movePos = new Vector2(-1.0f, 0.0f);
        }
        else if ((index + M) == nextPath)
        {
            initMovement(moveTime, new Vector2(0.0f, moveSpeed));
            movePos = new Vector2(0.0f, 1.0f);
        }
        else if ((index - M) == nextPath)
        {
            initMovement(moveTime, new Vector2(0.0f, -moveSpeed));
            movePos = new Vector2(0.0f, -1.0f);
        }
        else
        {
            initMovement(0.5f, new Vector2(0.0f, 0.0f));
        }

    }
}
