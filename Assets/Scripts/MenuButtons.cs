using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnePlayerMode()
    {
        SaveScript.Player1Mode = true;
        SceneManager.LoadScene(1);
    }

    public void TwoPlayerMode()
    {
        SaveScript.Player1Mode = false;
        SceneManager.LoadScene(1);
    }

    public void ControlsMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(5);
    }

    public void Credits()
    {
        SceneManager.LoadScene(6);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
