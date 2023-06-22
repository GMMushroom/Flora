using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        Player1Health = 1.0f;
        Player2Health = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
