using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public GameObject StageBG1;
    public GameObject StageBG2;
    public GameObject StageBG3;
    public int MaxStages = 3;
    private int CurrentStage = 1;
    private float PauseTime = 0.2f;
    private bool LevelSelect = false;
    private bool TimeCountdown = false;

    // Start is called before the first frame update
    void Start()
    {
        StageBG1.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeCountdown == true)
        {
            if (PauseTime > 0.1f)
            {
                PauseTime -= 0.2f * Time.deltaTime;
            }
            if (PauseTime <= 0.1f)
            {
                PauseTime = 0.2f;
                TimeCountdown = false;
            }
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (PauseTime == 0.2f)
            {
                if (CurrentStage < MaxStages)
                {
                    CurrentStage++;
                    LevelSelect = true;
                    TimeCountdown = true;
                }
                else if (CurrentStage == MaxStages)
                {
                    CurrentStage = 1;
                    LevelSelect = true;
                    TimeCountdown = true;
                }
            }
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            if (PauseTime == 0.2f)
            {
                if (CurrentStage >= 1)
                {
                    CurrentStage--;
                    LevelSelect = true;
                    TimeCountdown = true;
                }

                else if (CurrentStage == 1)
                {
                    CurrentStage = 3;
                    LevelSelect = true;
                    TimeCountdown = true;
                }
            }
        }

        if (LevelSelect == true)
        {
            if (CurrentStage == 1)
            {
                SwitchOff();
                StageBG1.gameObject.SetActive(true);
                LevelSelect = false;
            }
            if (CurrentStage == 2)
            {
                SwitchOff();
                StageBG2.gameObject.SetActive(true);
                LevelSelect = false;
            }
            if (CurrentStage == 3)
            {
                SwitchOff();
                StageBG3.gameObject.SetActive(true);
                LevelSelect = false;
            }
        }

        if(Input.GetButtonDown("Fire1"))
        {
            SaveScript.StageNumber = CurrentStage;
            SceneManager.LoadScene(3);
        }
    }

    void SwitchOff()
    {
        StageBG1.gameObject.SetActive(false);
        StageBG2.gameObject.SetActive(false);
        StageBG3.gameObject.SetActive(false);
    }
}
