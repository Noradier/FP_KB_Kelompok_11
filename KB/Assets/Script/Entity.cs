using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected int x, y, index;
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
        levelMap.addEdge(0, 1);
        levelMap.addEdge(0, 18);
        levelMap.addEdge(1, 2);
        levelMap.addEdge(2, 3);
        levelMap.addEdge(2, 20);
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

}
