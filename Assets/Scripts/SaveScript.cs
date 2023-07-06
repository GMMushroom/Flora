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
    public static bool Player1Mode = true;
    public static int P1WinCounter = 0;
    public static int P2WinCounter = 0;
    public static int RoundCounter = 0;
    public static string P1Select;
    public static string P2Select;
    public static GameObject P1Load;
    public static GameObject P2Load;

    // Start is called before the first frame update
    void Start()
    {
        //P1Select = "RayP1";
        //P2Select = "RayP2";
        Player1Health = 1.0f;
        Player2Health = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
