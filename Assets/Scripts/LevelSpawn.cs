using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawn : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    private GameObject Player1Character;
    private GameObject Player2Character;
    public Transform P1Spawn;
    public Transform P2Spawn;

    public int Scene = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find(SaveScript.P1Select);
        Player1.gameObject.GetComponent<P1Load>().enabled = true;
        Player2 = GameObject.Find(SaveScript.P2Select);
        Player2.gameObject.GetComponent<P2Load>().enabled = true;
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
