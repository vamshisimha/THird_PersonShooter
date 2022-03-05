using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public Animator animator;
    public EnemyStates states;
    public GameObject spheres;
   // public bool isPlayerInSight = false;
   // public  bool isPlayerInAttack = false;

    public float sightDistance, attackDistance;
    public LayerMask mask;

    public List<Transform> wayPoints;
    int currentPoint = 0;
    public enum EnemyStates
    {
        WALK,
        ATTACK, 
        CHASE

    };
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        
        states = EnemyStates.WALK;
        
       // 
    }

    // Update is called once per frame
    void Update()
    {
        TransitionRules();
        switch (states)
        {
            case EnemyStates.WALK:
                //animator.SetBool("walking", true);
                PatrolAction();
                Debug.Log(" walking");
                // access the blend parameter 
                break;

            case EnemyStates.ATTACK:
                // animator.SetBool("attack", true);
                Debug.Log("attack");
                break;
            case EnemyStates.CHASE:
                agent.SetDestination(player.transform.position);
                Debug.Log("Chasing");
                break;
        }

    }

    void TransitionRules()
    {



        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);

        Ray ray = new Ray(spheres.transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(spheres.transform.position, spheres.transform.forward.normalized * 30, Color.green);

        var results = Physics.SphereCastAll(spheres.transform.position, 50, spheres.transform.forward);

        foreach(var e in results)
        {
            Debug.Log(e.collider.name);
            agent.SetDestination(e.point);
           
        }

        //if (Physics.Raycast(spheres.transform.position, transform.forward, out hit, 1000))
        //{
        //    //Debug.Log(hit);
        //    if (hit.collider.CompareTag("Player"))
        //    {

        //        //float dist_s = Vector3.Distance(transform.position, player.transform.position);

        //        //isPlayerInSight = hit.distance <= 20;
        //        if (hit.distance <= sightDistance)
        //        {
        //            states = EnemyStates.CHASE;
        //        }

        //        if (hit.distance <= attackDistance)
        //        {
        //            states = EnemyStates.ATTACK;
        //        }

        //        if (hit.distance >= attackDistance && hit.distance <= sightDistance)
        //        {
        //            states = EnemyStates.CHASE;
        //        }
        //        else
        //        {
        //            states = EnemyStates.WALK;

        //        }
        //        // Patrol state
        //        Debug.Log("found player");
        //        //Debug.DrawRay(spheres.transform.position, hit.transform.position - spheres.transform.position, Color.red, 1000);



        //    }


        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            states = EnemyStates.ATTACK;

    }

    void PatrolAction()
    {
        // How far away are we from the target?
        
        float distance = (wayPoints[currentPoint].position - transform.position).magnitude;

        // If we are closer to our target than our minimum distance...
        if (distance <= agent.stoppingDistance)
        {
            // Update to the next target
            currentPoint = currentPoint + 1;

            // If we've gone past the end of our list...
            // (if our current point index is equal or bigger than
            // the length of our list)

           //if(agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending) 
            if (currentPoint >= wayPoints.Count)
            {
                // ...loop back to the start by setting 
                // the current point index to 0
                currentPoint = 0;
            }

           
        }
        Debug.Log(currentPoint);
        // Now, move in the direction of our target

       
        agent.SetDestination(wayPoints[currentPoint].position);


    }
}
