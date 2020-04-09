using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected int x, y;
    protected Animator anim;

    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCoordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
        transform.position = new Vector3(x + 0.5f, y + 0.5f, transform.position.z);
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }

}
