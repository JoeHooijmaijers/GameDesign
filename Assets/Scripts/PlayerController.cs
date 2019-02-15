using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;

    public float movementSpeed;
    public float jumpHeight;
    public float rotationSpeed;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        Vector3 targetDirection = new Vector3(h, 0f, v);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        transform.Translate(targetDirection);
        //transform.rotation = Quaternion.LookRotation(targetDirection);

        if (Input.GetKey("space"))
        {
            Jump();
        }
    }

    void Jump()
    {
        float distanceToGround = GetComponent<Collider>().bounds.extents.y;

        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.1f);

        if (IsGrounded)
        {
            rb.velocity += jumpHeight * Vector3.up;
        }
        
    }
 
}
