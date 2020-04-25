using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected int x, y, index;
    [SerializeField] protected float time;
    [SerializeField] protected bool isMoving;
    [SerializeField] protected Vector2 moveCoordinate;
    protected Map levelMap;
    // protected Animator anim;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // anim = GetComponent<Animator>();
        setMap();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    private void setMap()
    {
        levelMap = new Map(18, 10);
        levelMap.deleteVertex(19);
    }

    public void setCoordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
        index = x + y * levelMap.getM();
        transform.position = new Vector3(x + 0.5f, y + 0.5f, transform.position.z);
    }

    public void setLevelMap(Map levelMap)
    {
        this.levelMap = levelMap;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }

    // Inisialisasi pergerakan objek.
    protected void initMovement(float time, Vector2 moveCoordinate)
    {
        this.time = time;
        this.moveCoordinate = moveCoordinate;
        isMoving = true;
    }

    // Fungsi pergerakan objek.
    protected void move()
    {
        float deltaTime = Time.deltaTime;
        transform.Translate(new Vector3(moveCoordinate.x * deltaTime, moveCoordinate.y * deltaTime, 0f));
        time -= deltaTime;
        if (time < 0.0f)
        {
            positionCorrection();
            isMoving = false;
        }
    }

    // Koreksi digit akhir posisi objek dan update index objek.
    protected void positionCorrection()
    {
        int x, y;
        x = (int)transform.position.x;
        y = (int)transform.position.y;

        setCoordinate(x, y);
    }
}
