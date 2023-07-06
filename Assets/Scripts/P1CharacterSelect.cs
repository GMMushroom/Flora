using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class P1CharacterSelect : MonoBehaviour
{
    public int MaxIcons = 8;
    public int IconsPerRow = 4;
    public int MaxRows = 2;

    public GameObject RayP1;
    public GameObject BriannaP1;
    public GameObject GilfordP1;

    public GameObject RayP1Text;
    public GameObject BriannaP1Text;
    public GameObject GilfordP1Text;

    public TextMeshProUGUI Player1Name;

    public string CharacterSelectionP1;

    private int IconNumber = 1;
    private int RowNumber = 1;
    private float PauseTime = 0.2f;
    private bool TimeCountdown = false;
    private bool ChangeCharacter = false;
    private AudioSource MyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCharacter = true;
        Player1Name.gameObject.SetActive(true);
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeCharacter == true)
        {
            if (IconNumber == 1)
            {
                SwitchOff();
                RayP1.gameObject.SetActive(true);
                RayP1Text.gameObject.SetActive(true);
                Player1Name.text = "Ray";
                CharacterSelectionP1 = "RayP1";
                ChangeCharacter = false;
            }
            if (IconNumber == 2)
            {
                SwitchOff();
                BriannaP1.gameObject.SetActive(true);
                BriannaP1Text.gameObject.SetActive(true);
                Player1Name.text = "Brianna";
                CharacterSelectionP1 = "BriannaP1";
                ChangeCharacter = false;
            }
            if (IconNumber == 3)
            {
                SwitchOff();
                GilfordP1.gameObject.SetActive(true);
                GilfordP1Text.gameObject.SetActive(true);
                Player1Name.text = "Gilford";
                CharacterSelectionP1 = "GilfordP1";
                ChangeCharacter = false;
            }
        }

        if(Input.GetButtonDown("Fire1"))
        {
            SaveScript.P1Select = CharacterSelectionP1;
            MyPlayer.Play();
            NextPlayer();
        }

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
            if(PauseTime == 0.2f)
            {
                if(IconNumber < IconsPerRow * RowNumber)
                {
                    IconNumber++;
                    ChangeCharacter = true;
                    TimeCountdown = true;
                }
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (PauseTime == 0.2f)
            {
                if (IconNumber > IconsPerRow * (RowNumber - 1) + 1)
                {
                    IconNumber--;
                    ChangeCharacter = true;
                    TimeCountdown = true;
                }
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            if (PauseTime == 0.2f)
            {
                if (RowNumber < MaxRows)
                {
                    IconNumber += IconsPerRow;
                    RowNumber++;
                    ChangeCharacter = true;
                    TimeCountdown = true;
                }
            }
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            if (PauseTime == 0.2f)
            {
                if (RowNumber > 1)
                {
                    IconNumber -= IconsPerRow;
                    RowNumber--;
                    ChangeCharacter = true;
                    TimeCountdown = true;
                }
            }
        }
    }

    void SwitchOff()
    {
        RayP1.gameObject.SetActive(false);
        RayP1Text.gameObject.SetActive(false);
        BriannaP1.gameObject.SetActive(false);
        BriannaP1Text.gameObject.SetActive(false);
        GilfordP1.gameObject.SetActive(false);
        GilfordP1Text.gameObject.SetActive(false);
    }

    void NextPlayer()
    {
        if(SaveScript.Player1Mode == true)
        {
            this.gameObject.GetComponent<CPUCharacterSelect>().enabled = true;
            this.gameObject.GetComponent<P1CharacterSelect>().enabled = false;
        }
        if (SaveScript.Player1Mode == false)
        {
            this.gameObject.GetComponent<P2CharacterSelect>().enabled = true;
            this.gameObject.GetComponent<P1CharacterSelect>().enabled = false;
        }
    }
}
