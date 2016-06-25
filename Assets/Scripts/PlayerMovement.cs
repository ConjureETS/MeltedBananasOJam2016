using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0f;
    public float turn = 0f;
    public GameObject camera;
    public Rigidbody characterRigidBody;
    //private Rigidbody rb;


	
	// Update is called once per frame
	void Update () {
        Vector3 fowardVector = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z);
        if (Input.GetAxis("Vertical")>0)
        {

            characterRigidBody.velocity = ( fowardVector * speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical")<0)
        {
            characterRigidBody.velocity = (-fowardVector * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal")<0)
        {
            characterRigidBody.velocity = (Vector3.Cross(-transform.up, fowardVector) * speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            characterRigidBody.velocity = (Vector3.Cross(transform.up, fowardVector) * speed * Time.deltaTime);
        }
    }
}
