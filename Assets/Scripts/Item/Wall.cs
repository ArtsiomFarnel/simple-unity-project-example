using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite dmgSprite;
    public Sprite destrSprite;
    public float hp;
    private Wall wall;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(float loss)
    {
        spriteRenderer.sprite = dmgSprite;
        hp -= loss;
        print(hp);
        if (hp <= 0)
        {
            spriteRenderer.sprite = destrSprite;
            GetComponent<BoxCollider2D>().enabled = false;
            //gameObject.SetActive(false);
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
