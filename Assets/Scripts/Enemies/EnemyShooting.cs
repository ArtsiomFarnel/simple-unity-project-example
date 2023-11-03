using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject Projectile;
    //public Transform Player;
    public GameObject Player;
    public float ProjectileForce;
    public float MinDamage;
    public float MaxDamage;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootPlayer());
        Player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (Player != null)
        {
            GameObject spell = Instantiate(Projectile, transform.position, Quaternion.identity);
            Debug.Log(Player.transform.position);
            Vector2 myPos = transform.position;
            Vector2 targetPos = Player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * ProjectileForce;
            spell.GetComponent<EnemyProjectile>().Damage = Random.Range(MinDamage, MaxDamage);
            StartCoroutine(ShootPlayer());
        }
    }
}
