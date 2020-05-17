using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public static void changeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public static void closeGame()
    {
        Application.Quit();
    }
}
