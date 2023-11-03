using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum PickupObjects {POINT, ITEM};
    public PickupObjects CurrentObject;
    public int PickupQuantity;

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
        if (other.tag == "Player")
        {
            PlayerStats.playerStats.AddItems(this);
            PlayerStats.playerStats.HealCharacter(5);
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
