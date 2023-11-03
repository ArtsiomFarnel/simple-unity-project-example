using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public static Interface playerInterface;
    void Awake()
    {
        if (playerInterface != null)
        {
            Destroy(playerInterface);
        }
        else
        {
            playerInterface = this;
        }
        //DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
