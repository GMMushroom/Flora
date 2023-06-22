using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    public GameObject BGMPLAYER;

    // Start is called before the first frame update
    void Start()
    {
        BGMPLAYER = GameObject.Find("MUSIC");
        if (BGMPLAYER == null)
        {
            BGMPLAYER = this.gameObject;
            BGMPLAYER.name = "MUSIC";
            DontDestroyOnLoad(BGMPLAYER);
        }
        else
        {
            if (this.gameObject.name != "MUSIC")
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
