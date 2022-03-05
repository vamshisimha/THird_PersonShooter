using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
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
           // if (this.name == "SightSphere")
            {
               //W enemyMovement.isPlayerInAttack= true;
              
            }
            
            
        }
    }


}
