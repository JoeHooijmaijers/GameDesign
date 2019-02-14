using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public float jumpHeight;
    public float rotationSpeed;


	// Use this for initialization
	void Start () {
	
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
    }
 
}
