using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class BackToMenu : MonoBehaviour
{
    public void Back()
    {
        string path = Application.dataPath + "/Save.txt";
        if (File.Exists(path))
        {
            StreamWriter Writer = new StreamWriter(path, false);
            Writer.WriteLine("");
            Writer.Close();
        }
        SceneManager.LoadScene(0);
    }

    public void Records()
    {
        Client cl = gameObject.AddComponent<Client>();
        cl.SendData();
        
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
