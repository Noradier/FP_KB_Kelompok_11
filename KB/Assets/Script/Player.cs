using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private float time;
    private bool isMoving;
    private Vector2 moveCoordinate;

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            move();
            time -= Time.deltaTime;
            if (!(time > 0f))
                isMoving = false;
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
    }

}
