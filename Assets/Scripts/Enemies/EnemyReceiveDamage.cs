using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReceiveDamage : MonoBehaviour
{
    public GameObject HealthBar;
    public Slider HealthBarSlider;

    public float Health;
    public float MaxHealth;

    public GameObject LootDrop;

    public AudioClip dead;
    public AudioClip damageSound;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealCharacter(float heal)
    {
        Health += heal;
        CheckOverheal();
        HealthBarSlider.value = CalculateHealthPercentage();
    }

    public void DealDamage(float Damage)
    {
        HealthBar.SetActive(true);
        HealthBarSlider.value = CalculateHealthPercentage();
        Health -= Damage;
        SoundManager.instance.PlaySingle(damageSound);
        CheckDeath();
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
            SoundManager.instance.PlaySingle(dead);
            Destroy(gameObject);
            Destroy(HealthBarSlider);
            Instantiate(LootDrop, transform.position, Quaternion.identity);
            return true;
        }
        else return false;
    }

    private float CalculateHealthPercentage()
    {
        return (Health / MaxHealth);
    }
}
