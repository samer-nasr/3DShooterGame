using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.PlayerActions playerActions;
    private PlayerMotor motor;
    private PlayerLook look;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.Player;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        playerActions.Jump.performed += ctx => motor.Jump();
        //playerActions.DoorAccess.performed += ctx => motor.accessMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(playerActions.Move.ReadValue<Vector2>());

    }

    private void LateUpdate()
    {
        look.ProcessLook(playerActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}
