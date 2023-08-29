using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    public Animator animator;

    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        Debug.Log("Interact with "+gameObject.name);
        //animator.Play("DoorOpen", 0, 0.0f);
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen" , doorOpen);
    }
}
