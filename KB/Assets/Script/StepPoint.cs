using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPoint : MonoBehaviour
{
    private Level level;

    public void setLevel(Level level)
    {
        this.level = level;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        level.decreasePoint();
        Destroy(gameObject);
    }
}
