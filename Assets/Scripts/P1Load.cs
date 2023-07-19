using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class P1Load : MonoBehaviour
{
    public GameObject P1Icon;
    public GameObject P1Character;
    public string P1Name = "P1";
    public TextMeshProUGUI P1Text;
    public GameObject WinScreen;
    public float WaitTime = 1.0f;
    private bool Win = false;

    // Start is called before the first frame update
    void Start()
    {
        P1Icon.gameObject.SetActive(true);
        P1Text.text = P1Name;
        SaveScript.P1Load = P1Character;
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.P1WinCounter > 1)
        {
            if (Win == false)
            {
                Win = true;
                StartCoroutine(SetWin());
            }
        }
        if (SaveScript.P2WinCounter > 1)
        {
            if (Win == false)
            {
                Win = true;
                StartCoroutine(IconOff());
            }
        }
    }

    IEnumerator SetWin()
    {
        yield return new WaitForSeconds(WaitTime);
        WinScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator IconOff()
    {
        yield return new WaitForSeconds(WaitTime);
        P1Icon.gameObject.SetActive(false);
    }
}
