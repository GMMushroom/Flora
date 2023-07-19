using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseMenu : MonoBehaviour
{
    public int Scene = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(Scene);
    }
}
