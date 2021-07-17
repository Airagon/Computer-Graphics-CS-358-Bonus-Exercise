using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody rb;

    public float ballSpeed = 13.0f;
    public float jumpPower = 4f;
    public int timesAllowedToJump = 2;
    private int timesJumped = 0;

    public LayerMask groundMask;
    public float groundCheckDistance = 0.53f;

    private AudioSource audioData;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
    }
    void Update(){
        isGrounded();
        if (Input.GetKeyDown(KeyCode.Space)) 
        Jump();
    }

    // Runs before physics calculations
    void FixedUpdate (){
        // Movement
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");
       Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
       rb.AddForce(movement * ballSpeed);
    }

    void Jump(){
        if(timesJumped < timesAllowedToJump){
            audioData.Play(0);
            rb.velocity += new Vector3(0, jumpPower, 0);
            timesJumped++;
        }
    }

    bool isGrounded(){
        bool check = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance ,groundMask);
        if (check) timesJumped = 0;
        //Debug.Log(check);
        return check;
    }
}
