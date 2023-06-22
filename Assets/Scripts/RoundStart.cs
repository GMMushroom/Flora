using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStart : MonoBehaviour
{
    public GameObject Round1Text;
    public GameObject Round2Text;
    public GameObject Round3Text;
    public GameObject FightText;
    public AudioSource MyPlayer;
    public AudioSource BGMPlayer;
    public AudioClip FightAudio;
    public AudioClip Round1Audio;
    public AudioClip Round2Audio;
    public AudioClip Round3Audio;
    public float PauseTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Round1Text.gameObject.SetActive(false);
        Round2Text.gameObject.SetActive(false);
        Round3Text.gameObject.SetActive(false);
        FightText.gameObject.SetActive(false);
        StartCoroutine(RoundSet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RoundSet()
    {
        yield return new WaitForSeconds(0.2f);
        if (SaveScript.RoundCounter == 1)
        {
            yield return new WaitForSeconds(0.4f);
            Round1Text.gameObject.SetActive(true);
            MyPlayer.clip = Round1Audio;
            MyPlayer.Play();
            yield return new WaitForSeconds(PauseTime);
            Round1Text.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            FightText.gameObject.SetActive(true);
            MyPlayer.clip = FightAudio;
            MyPlayer.Play();
            yield return new WaitForSeconds(PauseTime);
            FightText.gameObject.SetActive(false);
            BGMPlayer.Play();
            SaveScript.TimeOut = false;
            this.gameObject.SetActive(false);
        }
        if (SaveScript.RoundCounter == 2)
        {
            yield return new WaitForSeconds(0.4f);
            Round2Text.gameObject.SetActive(true);
            MyPlayer.clip = Round2Audio;
            MyPlayer.Play();
            yield return new WaitForSeconds(PauseTime);
            Round2Text.gameObject.SetActive(false);
            StartCoroutine(Fight());
        }
        if (SaveScript.RoundCounter == 3)
        {
            yield return new WaitForSeconds(0.4f);
            Round3Text.gameObject.SetActive(true);
            MyPlayer.clip = Round3Audio;
            MyPlayer.Play();
            yield return new WaitForSeconds(PauseTime);
            Round3Text.gameObject.SetActive(false);
            StartCoroutine(Fight());
        }
    }

    IEnumerator Fight()
    {
        yield return new WaitForSeconds(0.1f);
        FightText.gameObject.SetActive(true);
        MyPlayer.clip = FightAudio;
        MyPlayer.Play();
        yield return new WaitForSeconds(PauseTime);
        FightText.gameObject.SetActive(false);
        SaveScript.TimeOut = false;
        this.gameObject.SetActive(false);
    }
}
