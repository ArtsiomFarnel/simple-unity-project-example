using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public float SpawnRate;

    private float x, y;
    private Vector3 SpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        x = Random.Range(-1, 1);
        y = Random.Range(-1, 1);
        SpawnPos.x += x;
        SpawnPos.y += y;
        Instantiate(Enemies[0], SpawnPos, Quaternion.identity);
        yield return new WaitForSeconds(SpawnRate);
        StartCoroutine(SpawnEnemy());
    }
}
