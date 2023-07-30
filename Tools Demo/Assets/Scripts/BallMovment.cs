using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BallMovment : MonoBehaviour

{
    Rigidbody Rigidbody;
    [SerializeField]private float upForce = 0.5f;
    [SerializeField] private float moveSpeed = 5f;

    // Start is called before the first frame update
    private void Awake()
    {
        Rigidbody= GetComponent<Rigidbody>();
        NewInputAction inputActions= new NewInputAction();
        inputActions.Move.Enable();
        inputActions.Move.Jump.performed+=Jump;
        inputActions.Move.Movement.performed += Movement;


    }

    public void Movement(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 moveDirection= context.ReadValue<Vector2>();
        Rigidbody.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y) * moveSpeed, ForceMode.Force);
    }

    // Update is called once per frame
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
             Debug.Log("Jump:"+context.phase);
             Rigidbody.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }
    }
}
