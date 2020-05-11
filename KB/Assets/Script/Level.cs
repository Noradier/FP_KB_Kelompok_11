using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    // Kelas abstrak yang digunakan untuk membangun level.

    protected Entity player, pocong;    // Entity yang akan dimuat dalam level.
    protected Map map;                  // Level memiliki class Map yang dapat digunakan sebagai koordinat bagi semua GameObject

    public virtual void Start()
    {
        player = Resources.Load("Prefabs/Player_Placeholder", typeof(Entity)) as Entity;
        pocong = Resources.Load("Prefabs/Pocong_Placeholder", typeof(Entity)) as Entity;
    }

    public static void changeCameraPosition(float x, float y)
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        float z = camera.transform.position.z;

        if(camera != null)
            camera.transform.position = new Vector3(x, y, z);
    }

    // Kumpulan fungsi utilitas untuk membangun/mendesain level.

    // Membuat map MxN
    protected void createMap(int M, int N)
    {
        map = new Map(M, N);
    }

    // Menghapus distance x height petak dalam bentuk persegi dalam map
    protected void delete(int bottomLeft, int distance, int height)
    {
        int M = map.getM();

        for (int i = 0; i < height; i++)
            for (int j = 0; j < distance; j++)
                map.deleteVertex(bottomLeft + j + i * M);
    }

    // Fungsi Spawn GameObject player dan enemy

    protected void spawnPlayer(float x, float y)
    {
        if (player == null)
            return;
        Entity instance = Instantiate(player, new Vector3(x, y, 0.0f), Quaternion.identity);
        instance.setLevelMap(map);
    }

    protected void spawnPocong(float x, float y)
    {
        if (pocong == null)
            return;
        Entity instance = Instantiate(pocong, new Vector3(x, y, 0.0f), Quaternion.identity);
        instance.setLevelMap(map);
    }
}
