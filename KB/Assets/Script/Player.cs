using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float time;
    [SerializeField] private bool isMoving;
    [SerializeField] private Vector2 moveCoordinate;

    public override void Start()
    {
        base.Start();
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
            playerInput();
        }
    }

    private void playerInput()
    {
        int M = levelMap.getM();
        int N = levelMap.getN();
        if (Input.GetAxisRaw("Horizontal") > 0.5f && index < (M * N) - 1)
        {
            if(levelMap.getGraph(index, index + 1) == 1)
            {
                initMovement(0.5f, new Vector2(2.0f, 0.0f));
                isMoving = true;
            }
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5f && index > 0)
        {
            if(levelMap.getGraph(index, index - 1) == 1)
            {
                initMovement(0.5f, new Vector2(-2.0f, 0.0f));
                isMoving = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f && index < M * (N - 1))
        {
            if (levelMap.getGraph(index, index + M) == 1)
            {
                initMovement(0.5f, new Vector2(0.0f, 2.0f));
                isMoving = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") < -0.5f && index > M - 1)
        {
            if (levelMap.getGraph(index, index - M) == 1)
            {
                initMovement(0.5f, new Vector2(0.0f, -2.0f));
                isMoving = true;
            }
        }
    }

    private void initMovement(float time, Vector2 moveCoordinate)
    {
        this.time = time;
        this.moveCoordinate = moveCoordinate;
        isMoving = true;
    }

    private void move()
    {
        float deltaTime = Time.deltaTime;
        transform.Translate(new Vector3(moveCoordinate.x * deltaTime, moveCoordinate.y * deltaTime, 0f));
        time -= deltaTime;
        if(time < 0.0f)
        {
            positionCorrection();
            isMoving = false;
        }
    }

    private void positionCorrection()
    {
        int x, y;
        x = (int)transform.position.x;
        y = (int)transform.position.y;

        setCoordinate(x, y);
    }
}
