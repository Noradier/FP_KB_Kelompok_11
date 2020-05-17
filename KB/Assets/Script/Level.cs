using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Level : MonoBehaviour
{
    // Kelas abstrak yang digunakan untuk membangun level.

    protected Entity player, pocong, suster;    // Entity yang akan dimuat dalam level.
    protected StepPoint stepPoint;
    protected Map map;                  // Level memiliki class Map yang dapat digunakan sebagai koordinat bagi semua GameObject
    [SerializeField] protected int point, M;

    public virtual void Start()
    {
        player = Resources.Load("Prefabs/Player", typeof(Entity)) as Entity;
        pocong = Resources.Load("Prefabs/Pocong", typeof(Entity)) as Entity;
        suster = Resources.Load("Prefabs/Suster", typeof(Entity)) as Entity;
        stepPoint = Resources.Load("Prefabs/Step_Point", typeof(StepPoint)) as StepPoint;
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
        this.M = M;
    }

    // Menghapus distance x height petak dalam bentuk persegi dalam map
    protected void delete(int bottomLeft, int distance, int height)
    {
        for (int i = 0; i < height; i++)
            for (int j = 0; j < distance; j++)
                map.deleteVertex(bottomLeft + j + i * M);
    }

    // Fungsi Spawn GameObject player dan enemy

    protected void spawnPlayer(int index)
    {
        float x = (index % M) + 0.5f,
              y = (index / M) + 0.5f;

        Entity instance = Instantiate(player, new Vector3(x, y, 0.0f), Quaternion.identity);
        instance.setLevelMap(map);
    }

    protected void spawnPocong(int index)
    {
        float x = (index % M) + 0.5f,
              y = (index / M) + 0.5f;

        Entity instance = Instantiate(pocong, new Vector3(x, y, 0.0f), Quaternion.identity);
        instance.setLevelMap(map);
    }

    protected void spawnSuster(int index)
    {
        float x = (index % M) + 0.5f,
              y = (index / M) + 0.5f;

        Entity instance = Instantiate(suster, new Vector3(x, y, 0.0f), Quaternion.identity);
        instance.setLevelMap(map);
    }

    protected void spawnStepPoint(int index, Level level)
    {
        float x = (index % M) + 0.5f,
              y = (index / M) + 0.5f;

        StepPoint instance = Instantiate(stepPoint, new Vector3(x, y, 0.0f), Quaternion.identity);
        instance.setLevel(level);
    }

    // Fungsi untuk mengecek bila semua tempat tujuan telah dikunjungi
    public virtual void decreasePoint()
    {
        point--;
    }
}
