using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    public string Tag = "BGM";
    public string DestroyScene = "Main Menu";

    private void Awake()
    {
        GameObject[] Obj = GameObject.FindGameObjectsWithTag(Tag);
        if (Obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == DestroyScene)
        {
            // Stops playing music in level 1 scene
            Destroy(gameObject);
        }
    }
}
