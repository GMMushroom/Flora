using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class P2CharacterSelect : MonoBehaviour
{
    public int MaxIcons = 8;
    public int IconsPerRow = 4;
    public int MaxRows = 2;

    public GameObject RayP2;
    public GameObject BriannaP2;
    public GameObject GilfordP2;

    public GameObject RayP2Text;
    public GameObject BriannaP2Text;
    public GameObject GilfordP2Text;

    public TextMeshProUGUI Player2Name;

    public string CharacterSelectionP2;

    private int IconNumber = 1;
    private int RowNumber = 1;
    private float PauseTime = 0.2f;
    private bool TimeCountdown = false;
    private bool ChangeCharacter = false;
    private AudioSource MyPlayer;
    public AudioClip RayAnnounce;
    public AudioClip BriannaAnnounce;
    public AudioClip GilfordAnnounce;

    public int Scene = 2;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCharacter = true;
        Player2Name.gameObject.SetActive(true);
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
                RayP2.gameObject.SetActive(true);
                RayP2Text.gameObject.SetActive(true);
                Player2Name.text = "Ray";
                CharacterSelectionP2 = "RayP2";
                ChangeCharacter = false;
            }
            if (IconNumber == 2)
            {
                SwitchOff();
                BriannaP2.gameObject.SetActive(true);
                BriannaP2Text.gameObject.SetActive(true);
                Player2Name.text = "Brianna";
                CharacterSelectionP2 = "BriannaP2";
                ChangeCharacter = false;
            }
            if (IconNumber == 3)
            {
                SwitchOff();
                GilfordP2.gameObject.SetActive(true);
                GilfordP2Text.gameObject.SetActive(true);
                Player2Name.text = "Gilford";
                CharacterSelectionP2 = "GilfordP2";
                ChangeCharacter = false;
            }
        }

        if(Input.GetButtonDown("Fire1P2"))
        {
            SaveScript.P2Select = CharacterSelectionP2;
            if (IconNumber == 1)
            {
                MyPlayer.clip = RayAnnounce;
                MyPlayer.Play();
                SceneManager.LoadScene(Scene);
            }
            if (IconNumber == 2)
            {
                MyPlayer.clip = BriannaAnnounce;
                MyPlayer.Play();
                SceneManager.LoadScene(Scene);
            }
            if (IconNumber == 3)
            {
                MyPlayer.clip = GilfordAnnounce;
                MyPlayer.Play();
                SceneManager.LoadScene(Scene);
            }
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

        if (Input.GetAxis("HorizontalP2") > 0)
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
        if (Input.GetAxis("HorizontalP2") < 0)
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
        if (Input.GetAxis("VerticalP2") < 0)
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
        if (Input.GetAxis("VerticalP2") > 0)
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
        RayP2.gameObject.SetActive(false);
        RayP2Text.gameObject.SetActive(false);
        BriannaP2.gameObject.SetActive(false);
        BriannaP2Text.gameObject.SetActive(false);
        GilfordP2.gameObject.SetActive(false);
        GilfordP2Text.gameObject.SetActive(false);
    }
}
