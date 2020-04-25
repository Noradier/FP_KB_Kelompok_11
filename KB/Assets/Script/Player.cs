using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public override void Start()
    {
        base.Start();
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
            playerInput();
        }
    }

    // Input player, gerak atas bawah kiri kanan.
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
}
