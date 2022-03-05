using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    public int starthealth;
    public int currenthealth;
    public ParticleSystem deathParticles
        ;


    private void Awake()
    {
        currenthealth = starthealth;
    }
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        if(currenthealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="bullet")
        {
            TakeDamage(10);
        }
    }
    private void Die()
    {
        
        gameObject.SetActive(false);
        Instantiate(deathParticles, transform.position, Quaternion.identity);
    }
   
}
