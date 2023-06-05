using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    public GameObject Player1Character;
    public GameObject Player2Character;
    public Transform P1Spawn;
    public Transform P2Spawn;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player1Character, P1Spawn.position, P1Spawn.rotation);
        Instantiate(Player2Character, P2Spawn.position, P2Spawn.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
