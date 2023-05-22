using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image Player1Yellow;
    public Image Player2Yellow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player1Yellow.fillAmount = SaveScript.Player1Health;
        Player2Yellow.fillAmount = SaveScript.Player2Health;
    }
}
