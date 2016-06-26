using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0f;
    public float turn = 0f;
    public float boostFactor = 1f;
    public float seconds;
    float initialTime;
    bool SpeedBoostTimerStart;
    public GameObject camera;
    public Rigidbody characterRigidBody;
    //private Rigidbody rb;


	
	// Update is called once per frame
	void Update () {
        Vector3 fowardVector = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z);
        if (Input.GetAxis("Vertical")>0)
        {

            characterRigidBody.velocity = ( fowardVector * speed * boostFactor * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical")<0)
        {
            characterRigidBody.velocity = (-fowardVector * speed * boostFactor * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal")<0)
        {
            characterRigidBody.velocity = (Vector3.Cross(-transform.up, fowardVector) * speed * boostFactor * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            characterRigidBody.velocity = (Vector3.Cross(transform.up, fowardVector) * speed * boostFactor * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        SpeedBoostTimer(seconds);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "SpeedBoost")
        {
            other.gameObject.SetActive (false);
            SpeedBoostTimerStart = true;
        }
    }

    private void SpeedBoostTimer(float seconds)
    {
        if (SpeedBoostTimerStart)
        {
            boostFactor = 8f;
            initialTime = Time.realtimeSinceStartup + seconds;
            SpeedBoostTimerStart = false;
        }
        if (Time.realtimeSinceStartup >= initialTime)
        {
            boostFactor = 1f;
        }

    }
}
