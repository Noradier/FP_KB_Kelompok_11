using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
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

    // Input dasar enemy.
    private void enemyInput()
    {
        int dist = pathfinding.calcH(index, player.getIndex());
        if (dist < 5)
            chasePlayer();
        else
            randomMovement();

        isMoving = true;

        anim.SetFloat("moveX", movePos.x);
        anim.SetFloat("moveY", movePos.y);
    }

    protected override void move()
    {
        base.move();
        if(moveCoordinate.x == 0.0f && moveCoordinate.y == 0.0f)
        {
            int dist = pathfinding.calcH(index, player.getIndex());
            if (dist < 6)
                chasePlayer();
        }
    }

    private void randomMovement()
    {
        int choice = Random.Range(0, 4);

        int M = levelMap.getM(),
            N = levelMap.getN();

        float moveSpeed = Random.Range(0.5f, 2.0f);
        float moveTime = 1.0f / moveSpeed;

        switch (choice)
        {
            case 1:
                if (index < (M * N) - 1)
                {
                    if (levelMap.getGraph(index, index + 1) == 1)
                    {
                        initMovement(moveTime, new Vector2(moveSpeed, 0.0f));
                        movePos = new Vector2(1.0f, 0.0f);
                        return;
                    }
                }
                break;
            case 2:
                if (index > 0)
                {
                    if (levelMap.getGraph(index, index - 1) == 1)
                    {
                        initMovement(moveTime, new Vector2(-moveSpeed, 0.0f));
                        movePos = new Vector2(-1.0f, 0.0f);
                        return;
                    }
                }
                break;
            case 3:
                if (index < M * (N - 1))
                {
                    if(levelMap.getGraph(index, index + M) == 1)
                    {
                        initMovement(moveTime, new Vector2(0.0f, moveSpeed));
                        movePos = new Vector2(0.0f, 1.0f);
                        return;
                    }
                }
                break;
            case 4:
                if (index < M - 1)
                {
                    if(levelMap.getGraph(index, index - M) == 1)
                    {
                        initMovement(moveTime, new Vector2(0.0f, -moveSpeed));
                        movePos = new Vector2(0.0f, -1.0f);
                        return;
                    }
                }
                break;
        }

        initMovement(0.5f, new Vector2(0.0f, 0.0f));
    }

    private void chasePlayer()
    {
        int nextPath = pathfinding.astar(index, player.getIndex());
        int M = levelMap.getM();

        float moveSpeed = 1.8f;
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
