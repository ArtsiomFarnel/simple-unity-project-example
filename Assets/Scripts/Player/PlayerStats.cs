using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject Player;
    public GameObject Panel;
    public Text text;
    public Text HealthText;
    public Slider HealthSlider;

    public float Health;
    public float MaxHealth;

    public int points;
    public int items;
    public int gameIsWin;

    //private string fileName = "Save";
    public Text ItemsValue;

    public AudioClip healSound;
    public AudioClip gameOverSound;
    public AudioClip damageSound;

    void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        //DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        SetHealthUI();
    }
    
    // Update is called once per frame
    void Update()
    {
        TakeEsc();
    }

    public bool TakeEsc()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            //text.text = "";
            //Panel.SetActive(true);
            return true;
        }
        else return false;
    }

    public void HealCharacter(float heal)
    {
        Health += heal;
        SoundManager.instance.PlaySingle(healSound);
        CheckOverheal();
        SetHealthUI();
    }

    public void DealDamage(float Damage)
    {
        Health -= Damage;
        SoundManager.instance.PlaySingle(damageSound);
        CheckDeath();
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        HealthSlider.value = CalculateHealthPercentage();
        HealthText.text = Mathf.Ceil(Health).ToString() + "/" + Mathf.Ceil(MaxHealth).ToString();
    }

    private void CheckOverheal()
    {
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public bool CheckDeath()
    {
        if (Health <= 0)
        {
            Health = 0;
            SoundManager.instance.PlaySingle(gameOverSound);
            SoundManager.instance.musicSource.Stop();
            Destroy(Player);
            text.text = "YOU LOSE!";
            Panel.SetActive(true);
            return true;
        }
        else return false;
    }

    private float CalculateHealthPercentage()
    {
        return (Health / MaxHealth);
    }

    public void AddItems(ItemPickup ip)
    {
        if (ip.CurrentObject == ItemPickup.PickupObjects.ITEM)
        {
            items += ip.PickupQuantity;
            ItemsValue.text = "Alcohol: " + items.ToString();
        }
        else if (ip.CurrentObject == ItemPickup.PickupObjects.POINT)
        {
            points += ip.PickupQuantity;
        }
    }

    public void AddPoints()
    {
        points++;
        Debug.Log(PlayerPrefs.GetInt("Score: "));
        if (points == gameIsWin)
        {
            text.text = "YOU WIN!";
            Panel.SetActive(true);
        }
    }
    public void SaveRecord(int score)
    {
        print("Save");
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Save.txt", true);
        sw.WriteLine(score);
        sw.Close();
    }

    public int GetRecord()
    {
        print("Load");
        StreamReader sr = new StreamReader(Application.dataPath + "/Save.txt");
        return Convert.ToInt32(sr.ReadToEnd());
    }
}
