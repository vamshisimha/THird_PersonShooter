using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer1 : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyMovement enemyMovement;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (this.name == "SightSphere")
            {
               // enemyMovement.isPlayerInSight= true;
              
            }
            
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (this.name == "SightSphere")
            {
               // enemyMovement.isPlayerInSight = true;

            }


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (this.name == "SightSphere")
            {
              //  enemyMovement.isPlayerInSight = false;

            }


        }

    }
}
