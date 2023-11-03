using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    public BoardManager boardScript;
    //private Text levelText;
    //private GameObject levelImage;

    public float levelStartDelay = 1f;
    public int level = 0;
    //public bool doingSetup;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        //doingSetup = true;
        //levelImage = GameObject.Find("Level Image");
        //levelText = GameObject.Find("Level Text").GetComponent<Text>();
        //levelText.text = "Level " + level;
        //levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
        boardScript.SetupScene(level);
    }

    private void HideLevelImage()
    {
        //levelImage.SetActive(false);
        //doingSetup = false;
    }

    /*public void GameOver()
    {
        //levelText.text = "You lose!";
        //levelImage.SetActive(true);
        enabled = false;
    }*/

    private void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.playerStats.TakeEsc() || PlayerStats.playerStats.CheckDeath())
        {
            level = 0;
            Destroy(this);
        }
    }
}
