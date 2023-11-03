using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPanel;
    public AudioClip button;
    public void StartGame()
    {
        SoundManager.instance.PlaySingle(button);
        string path = Application.dataPath + "/Save.txt";
        if (File.Exists(path))
        {
            StreamWriter Writer = new StreamWriter(path, false);
            Writer.WriteLine("");
            Writer.Close();
        }
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        SoundManager.instance.PlaySingle(button);
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SoundManager.instance.PlaySingle(button);
        SettingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        SoundManager.instance.PlaySingle(button);
        Debug.Log("Quitting");
        Application.Quit();
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
