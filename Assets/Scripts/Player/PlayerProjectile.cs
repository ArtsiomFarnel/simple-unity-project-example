using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float Damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<EnemyReceiveDamage>() != null)
            {
                collision.GetComponent<EnemyReceiveDamage>().DealDamage(Damage);
                if (collision.GetComponent<EnemyReceiveDamage>().CheckDeath())
                {
                    PlayerStats.playerStats.AddPoints();
                }
            }
            if (collision.GetComponent<Wall>() != null)
            {
                collision.GetComponent<Wall>().DamageWall(Damage);
            }
            Destroy(gameObject);
        }
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
