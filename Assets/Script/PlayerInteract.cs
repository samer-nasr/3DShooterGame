
using System.Threading;

using UnityEngine;


public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    private PlayerHealth health;
    float time;
    float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().Cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        health = GetComponent<PlayerHealth>();
        time = 0f;
        timeDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin , ray.direction * distance);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, distance, mask))
        {
            Debug.Log(hit.transform.gameObject.tag);
            

            if (hit.collider.GetComponent<Interactable>()!=null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (Input.GetKey(KeyCode.E))
                {
                    interactable.BaseInteract();
                    Debug.Log(interactable.name);
                    Thread.Sleep(200);
                }
                else if (interactable.name == "Cubert" )
                {
                    time = time + 1f * Time.deltaTime;
                    if (time >= timeDelay)
                    {
                        time = 0f;
                        interactable.BaseInteract();
                        
                    }
                }
               
            }
            
        }
 
    }
}
