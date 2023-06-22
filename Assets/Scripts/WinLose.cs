using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject P1WinText;
    public GameObject P2WinText;
    public AudioSource MyPlayer;
    public AudioClip YouLoseAudio;
    public AudioClip P1WinAudio;
    public AudioClip P2WinAudio;
    public float PauseTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        SaveScript.TimeOut = false;
        WinText.gameObject.SetActive(false);
        LoseText.gameObject.SetActive(false);
        P1WinText.gameObject.SetActive(false);
        P2WinText.gameObject.SetActive(false);
        StartCoroutine(P1WinSet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator P1WinSet()
    {
        yield return new WaitForSeconds(0.1f);
        if (SaveScript.Player1Health > SaveScript.Player2Health)
        {
            if (SaveScript.Player1Mode == true)
            {
                WinText.gameObject.SetActive(true);
                MyPlayer.Play();
                SaveScript.P1WinCounter++;
            }
            else if (SaveScript.Player1Mode == false)
            {
                P1WinText.gameObject.SetActive(true);
                MyPlayer.clip = P1WinAudio;
                MyPlayer.Play();
                SaveScript.P1WinCounter++;
            }
        }
        else if (SaveScript.Player2Health > SaveScript.Player1Health)
        {
            if (SaveScript.Player1Mode == true)
            {
                LoseText.gameObject.SetActive(true);
                MyPlayer.clip = YouLoseAudio;
                MyPlayer.Play();
                SaveScript.P2WinCounter++;
            }
            else if (SaveScript.Player1Mode == false)
            {
                P2WinText.gameObject.SetActive(true);
                MyPlayer.clip = P2WinAudio;
                MyPlayer.Play();
                SaveScript.P2WinCounter++;
            }
        }
        yield return new WaitForSeconds(PauseTime);
        SceneManager.LoadScene(0);
    }
}
