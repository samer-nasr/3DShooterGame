using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator.Play("DoorOpen" , 0 , 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Door")
        {
            animator.Play("DoorOpen" , 0 , 0.0f);
        }
        
    }

}
