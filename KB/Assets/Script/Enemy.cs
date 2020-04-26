using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private Player player;
    private Pathfinding pathfinding;
    private int g, h;

    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
        pathfinding = new Pathfinding(levelMap);
        positionCorrection();
        g = 0; h = 0;
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
        int val = Random.Range(0, 4);
        int M = levelMap.getM();
        int N = levelMap.getN();
        g += 10;
        h = 14 * Random.Range(1, 5);

        switch (val)
        {
            case 0:
                initMovement(0.5f, new Vector2(0.0f, 0.0f));
                break;
            case 1:
                if (index < (M * N) - 1 && levelMap.getGraph(index, index + 1) == 1)
                    initMovement(0.5f, new Vector2(2.0f, 0.0f));
                else
                    initMovement(0.5f, new Vector2(0.0f, 0.0f));
                break;
            case 2:
                if (index > 0 && levelMap.getGraph(index, index - 1) == 1)
                    initMovement(0.5f, new Vector2(-2.0f, 0.0f));
                else
                    initMovement(0.5f, new Vector2(0.0f, 0.0f));
                break;
            case 3:
                if (index < M * (N - 1) && levelMap.getGraph(index, index + M) == 1)
                    initMovement(0.5f, new Vector2(0.0f, 2.0f));
                else
                    initMovement(0.5f, new Vector2(0.0f, 0.0f));
                break;
            case 4:
                if (index > M - 1 && levelMap.getGraph(index, index - M) == 1)
                    initMovement(0.5f, new Vector2(0.0f, -2.0f));
                else
                    initMovement(0.5f, new Vector2(0.0f, 0.0f));
                break;
        }
        isMoving = true;
        //pathfinding.addNode(new Node(index, g, h));
        pathfinding.astar(index, player.getIndex());
    }
}
