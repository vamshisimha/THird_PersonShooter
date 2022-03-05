using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    public float playerspeed;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        animator.SetFloat("Speed", movement.magnitude);



       /* characterController.Move(movement * playerspeed * Time.deltaTime);
        if(movement.magnitude>0)
        {
            Quaternion direction = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime * turnSpeed);
        }*/
       if(vertical!=0)
        {
            characterController.SimpleMove(transform.forward*playerspeed*vertical);
            Quaternion direction = Quaternion.LookRotation(-movement);
         //   transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime * turnSpeed);
        }
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
       //if(horizontal!=0)
       // {
       //     characterController.SimpleMove(movement * playerspeed);
       // }
    }
}
