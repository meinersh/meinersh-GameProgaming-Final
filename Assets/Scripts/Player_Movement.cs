//This is for player inputs and movements

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float moveX;
    private float moveZ;

    // Start is called before the first frame update
    void Start()
    {
        //Gets it's own rigidbody2D component.
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the input for movement from Unity's input system
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    //updates based on realtime.
    private void FixedUpdate()
    {
        //Only runs if there is input in one direction at least.
        if(moveX > 0.1f || moveX < -0.1f || moveZ> 0.1f || moveZ < -0.1f)
        {
            //Applies force to player object in direction of the input.
            rb.AddForce(new Vector3 (moveX * 1, 0, moveZ * 1), ForceMode.Impulse);
        }
    }
}
