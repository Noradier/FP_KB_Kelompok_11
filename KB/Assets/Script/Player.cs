using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private bool[] screenPosition;

    public override void Start()
    {
        base.Start();
        positionCorrection();
        movePos = new Vector2(0.0f, -1.0f);
        screenPosition = new bool[4];
        setScreenPosition(0);
        isMoving = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isMoving)
            move();
        else
            playerInput();
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
                movePos = new Vector2(1.0f, 0.0f);
                isMoving = true;
            }
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5f && index > 0)
        {
            if(levelMap.getGraph(index, index - 1) == 1)
            {
                initMovement(0.5f, new Vector2(-2.0f, 0.0f));
                movePos = new Vector2(-1.0f, 0.0f);
                isMoving = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f && index < M * (N - 1))
        {
            if (levelMap.getGraph(index, index + M) == 1)
            {
                initMovement(0.5f, new Vector2(0.0f, 2.0f));
                movePos = new Vector2(0.0f, 1.0f);
                isMoving = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") < -0.5f && index > M - 1)
        {
            if (levelMap.getGraph(index, index - M) == 1)
            {
                initMovement(0.5f, new Vector2(0.0f, -2.0f));
                movePos = new Vector2(0.0f, -1.0f);
                isMoving = true;
            }
        }

        anim.SetFloat("moveX", movePos.x);
        anim.SetFloat("moveY", movePos.y);
    }

    protected override void move()
    {
        base.move();

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector2 cameraPos = camera.transform.position;

        if (x < 18 && y < 10 && !screenPosition[0])
        {
            Level.changeCameraPosition(9.0f, 5.0f);
            setScreenPosition(0);
        }
        else if (x > 17 && y < 10 && !screenPosition[1])
        {
            Level.changeCameraPosition(27.0f, 5.0f);
            setScreenPosition(1);
        }
        else if (x < 18 && y > 9 && !screenPosition[2])
        {
            Level.changeCameraPosition(9.0f, 15.0f);
            setScreenPosition(2);
        }
        else if (x > 17 && y > 9 && !screenPosition[3])
        {
            Level.changeCameraPosition(27.0f, 15.0f);
            setScreenPosition(3);
        }
    }

    private void setScreenPosition(int position)
    {
        for(int i=0; i<4; i++)
        {
            if (i == position)
                screenPosition[i] = true;
            else
                screenPosition[i] = false;
        }
    }
}
