using System.Collections;
using UnityEngine;
using TMPro;

public class P2Load : MonoBehaviour
{
    public GameObject P2Icon;
    public GameObject P2Character;
    public GameObject AICharacter;
    public string P2Name = "P2";
    public TextMeshProUGUI P2Text;
    public GameObject WinScreen;
    public float WaitTime = 1.0f;
    private bool Win = false;

    // Start is called before the first frame update
    void Start()
    {
        P2Icon.gameObject.SetActive(true);
        P2Text.text = P2Name;
        if (SaveScript.Player1Mode == false)
        {
            SaveScript.P2Load = P2Character;
        }
        if (SaveScript.Player1Mode == true)
        {
            SaveScript.P2Load = AICharacter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.P2WinCounter > 1)
        {
            if (Win == false)
            {
                Win = true;
                StartCoroutine(SetWin());
            }
        }
        if (SaveScript.P1WinCounter > 1)
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
        P2Icon.gameObject.SetActive(false);
    }
}
