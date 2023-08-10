using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Sprites;

public class LevelSpawn : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    private GameObject Player1Character;
    private GameObject Player2Character;
    public Transform P1Spawn;
    public Transform P2Spawn;
    public GameObject Background;
    public Sprite NewBackground;
    public AudioSource MyPlayer;

    public int Scene = 0;

    public Sprite BG1;
    public Sprite BG2;
    public Sprite BG3;

    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip Music3;

    // Start is called before the first frame update
    void Start()
    {
        if (SaveScript.StageNumber == 1)
        {
            NewBackground = BG1;
            MyPlayer.clip = Music1;
        }
        if (SaveScript.StageNumber == 2)
        {
            NewBackground = BG2;
            MyPlayer.clip = Music2;
        }
        if (SaveScript.StageNumber == 3)
        {
            NewBackground = BG3;
            MyPlayer.clip = Music3;
        }

        Player1 = GameObject.Find(SaveScript.P1Select);
        Player1.gameObject.GetComponent<P1Load>().enabled = true;
        Player2 = GameObject.Find(SaveScript.P2Select);
        Player2.gameObject.GetComponent<P2Load>().enabled = true;
        Background.gameObject.GetComponent<SpriteRenderer>().sprite = NewBackground;
        StartCoroutine(SpawnPlayers());
    }

    IEnumerator SpawnPlayers()
    {
        yield return new WaitForSeconds(0.1f);
        Player1Character = SaveScript.P1Load;
        Player2Character = SaveScript.P2Load;
        Instantiate(Player1Character, P1Spawn.position, P1Spawn.rotation);
        Instantiate(Player2Character, P2Spawn.position, P2Spawn.rotation);
    }

    public void BackToCharacterSelect()
    {
        SceneManager.LoadScene(Scene);
    }
}
