using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    public Slider Music;
    public Slider SFX;
    public Slider Voice;
    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;
    public AudioMixer VoiceMixer;

    // Start is called before the first frame update
    void Start()
    {
        Music.value = SaveScript.MusicVol;
        SFX.value = SaveScript.SFXVol;
        Voice.value = SaveScript.VoiceVol;
        MusicMixer.SetFloat("MusicLevel", SaveScript.MusicVol);
        SFXMixer.SetFloat("SFXLevel", SaveScript.SFXVol);
        VoiceMixer.SetFloat("VoiceLevel", SaveScript.VoiceVol);
    }

    public void DifficultyEasy()
    {
        SaveScript.Difficulty = 3.0f;
    }

    public void DifficultyMedium()
    {
        SaveScript.Difficulty = 1.0f;
    }

    public void DifficultyHard()
    {
        SaveScript.Difficulty = 0.5f;
    }

    public void MusicVolume()
    {
        MusicMixer.SetFloat("MusicLevel", Music.value);
        SaveScript.MusicVol = Music.value;
    }

    public void SFXVolume()
    {
        SFXMixer.SetFloat("SFXLevel", SFX.value);
        SaveScript.SFXVol = SFX.value;
    }

    public void VoiceVolume()
    {
        VoiceMixer.SetFloat("VoiceLevel", Voice.value);
        SaveScript.VoiceVol = Voice.value;
    }
}
