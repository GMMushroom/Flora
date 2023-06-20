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
    public TextMeshProUGUI TimerText;
    public float LevelTime = 99;

    // Start is called before the first frame update
    void Start()
    {
        
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
