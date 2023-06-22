using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarScript : MonoBehaviour
{
    public Image Player1Yellow;
    public Image Player2Yellow;
    public Image Player1Red;
    public Image Player2Red;
    public Image P1Win1;
    public Image P1Win2;
    public Image P2Win1;
    public Image P2Win2;
    public TextMeshProUGUI TimerText;
    public float LevelTime = 99;
    public GameObject WinCon;

    // Start is called before the first frame update
    void Start()
    {
        SaveScript.RoundCounter++;
        SaveScript.TimeOut = true;
        if (SaveScript.P1WinCounter == 1)
        {
            P1Win1.gameObject.SetActive(true);
        }
        if (SaveScript.P1WinCounter == 2)
        {
            P1Win1.gameObject.SetActive(true);
            P1Win2.gameObject.SetActive(true);
        }
        if (SaveScript.P2WinCounter == 1)
        {
            P2Win1.gameObject.SetActive(true);
        }
        if (SaveScript.P2WinCounter == 2)
        {
            P2Win1.gameObject.SetActive(true);
            P2Win2.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelTime > 0)
        {
            LevelTime -= 1 * Time.deltaTime;
        }
        if (LevelTime <= 0.9)
        {
            SaveScript.TimeOut = true;
            WinCon.gameObject.SetActive(true);
            WinCon.GetComponent<WinLose>().enabled = true;
        }

        TimerText.text = Mathf.Round(LevelTime).ToString();

        Player1Yellow.fillAmount = SaveScript.Player1Health;
        Player2Yellow.fillAmount = SaveScript.Player2Health;

        if(SaveScript.Player2Timer > 0)
        {
            SaveScript.Player2Timer -= 1.0f * Time.deltaTime;
        }
        if (SaveScript.Player1Timer > 0)
        {
            SaveScript.Player1Timer -= 1.0f * Time.deltaTime;
        }

        if (SaveScript.Player2Timer <= 0)
        {
            if(Player2Red.fillAmount > SaveScript.Player2Health)
            {
                Player2Red.fillAmount -= 0.003f;
            }
        }
        if (SaveScript.Player1Timer <= 0)
        {
            if (Player1Red.fillAmount > SaveScript.Player1Health)
            {
                Player1Red.fillAmount -= 0.003f;
            }
        }
    }
}
