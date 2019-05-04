using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour {

    public int speedM = 10;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float jumpForce = 100.0f;

    private float keyboardX = 0.0f;
    private float keyboardZ = 0.0f;
    private float mouseX = 0.0f;
    private float mouseY = 0.0f;
    private float distToGround = 0.0f;
    private NavMeshAgent agent;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -40.0F, 0);
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }
	
	// Update is called once per frame
	void Update () {
        keyboardX = Input.GetAxis("Horizontal") * Time.deltaTime * speedM;
        keyboardZ = Input.GetAxis("Vertical") * Time.deltaTime * speedM;

        mouseX += speedH * Input.GetAxis("Mouse X");
        mouseY -= speedV * Input.GetAxis("Mouse Y");

        rb.transform.Translate (keyboardX, 0, keyboardZ);
        rb.transform.eulerAngles = new Vector3(mouseY, mouseX, 0.0f);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("Jump");
            //agent.isStopped = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //agent.isStopped = false;
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 1.1f);
    }
}
