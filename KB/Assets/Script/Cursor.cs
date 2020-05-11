using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private int choice;
    private Animator anim;
    private GameManager gameManager;

    void Start()
    {
        choice = 1;
        anim = GetComponent<Animator>();
        anim.SetFloat("moveX", 0.0f);
        anim.SetFloat("moveY", 0.0f);
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        input();
    }

    void input()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameManager.loadStage1();
            return;
        }

        Vector3 position = transform.position;

        if (Input.GetAxisRaw("Vertical") > 0.5f && choice > 1)
        {
            transform.position = new Vector3(position.x, position.y + 1.1f, position.z);
            choice--;
        }
        else if(Input.GetAxisRaw("Vertical") < -0.5f && choice < 2)
        {
            transform.position = new Vector3(position.x, position.y - 1.1f, position.z);
            choice++;
        }
    }
}
