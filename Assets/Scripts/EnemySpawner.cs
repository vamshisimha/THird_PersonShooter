using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float repeatTime = 3.0f;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 2f, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > 10.0f)
        {
            repeatTime--;
            time = 0;
        }
    }

    private void SpawnEnemies()
    {
        transform.position = new Vector3(Random.Range(24,-36), Random.Range(0,0), Random.Range(-16,-4));
        GameObject enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
        //Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.down;
    }
}
