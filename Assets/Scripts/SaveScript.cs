using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SaveScript : MonoBehaviour
{
    public static float Player1Health = 1.0f;
    public static float Player2Health = 1.0f;
    public static float Player1Timer = 2.0f;
    public static float Player2Timer = 2.0f;
    public static bool TimeOut = false;
    public static bool Player1Mode = false;
    public static int P1WinCounter = 0;
    public static int P2WinCounter = 0;
    public static int RoundCounter = 0;
    public static string P1Select;
    public static string P2Select;
    public static GameObject P1Load;
    public static GameObject P2Load;
    public static int StageNumber = 1;
    public static float Difficulty = 1.0f;

    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;
    public AudioMixer VoiceMixer;
    public static float MusicVol = 0;
    public static float SFXVol = 0;
    public static float VoiceVol = 2;

    // Start is called before the first frame update
    void Start()
    {
        Player1Health = 1.0f;
        Player2Health = 1.0f;
        MusicMixer.SetFloat("MusicLevel", MusicVol);
        SFXMixer.SetFloat("SFXLevel", SFXVol);
        VoiceMixer.SetFloat("VoiceLevel", VoiceVol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
