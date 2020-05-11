using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Map levelMap;
    private Level[] level;
    private Player player;
    private Enemy pocong;

    // Start is called before the first frame update
    void Start()
    {
        initAsset();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initAsset()
    {
        level = new Level[5];
        level[0] = new Level1();

        player = Resources.Load("Prefabs/Player_Placeholder", typeof(Player)) as Player;
        pocong = Resources.Load("Prefabs/Pocong_Placeholder", typeof(Enemy1)) as Enemy1;
    }

    public void changeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void loadStage1()
    {
        changeScene(2);

        if(player == null)
        {
            Debug.Log("Gagal");
            return;
        }
        Debug.Log("Jalan");
        Entity instance = Instantiate(player, new Vector3(0.0f, 9.5f, 0f), Quaternion.identity);
        instance.GetComponent<Entity>().setLevelMap(level[0].getMap());
        Debug.Log("Jalan");
    }
}
