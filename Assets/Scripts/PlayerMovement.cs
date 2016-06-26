using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0f;
    public float turn = 0f;

    public float jump = 0f;
    //private Rigidbody rb;
    public Rigidbody characterRigidBody;
    private bool isGrounded;
    Vector3 up;

    // Boost
    public float boostFactor;
    public float seconds;
    float boostDeadline;
    bool SpeedBoostTimerStart;
    // Slow motion
    public float timeFactor = 0.2f;
    public float duration = 5.0f;
    float slowmoDeadline;
    private bool SlowmoTimerStart = false;


	
    // Update is called once per frame
    void FixedUpdate()
    {
        SpeedBoostTimer(seconds);
        SlowmoTimer(duration);
        ManageMovement();
    }

    private void ManageMovement()
    {

        Vector3 forwardVector = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        if (Input.GetAxis("Vertical") > 0 && isGrounded)
        {
            characterRigidBody.velocity = (forwardVector * speed * boostFactor * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") < 0 && isGrounded)
        {
            characterRigidBody.velocity = (-forwardVector * speed * boostFactor * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") < 0 && isGrounded)
        {
            characterRigidBody.velocity = (Vector3.Cross(-transform.up, forwardVector) * speed * boostFactor * Time.deltaTime );
        }
        else if (Input.GetAxis("Horizontal") > 0 && isGrounded)
        {
            characterRigidBody.velocity = (Vector3.Cross(transform.up, forwardVector) * speed * boostFactor * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        { 
            characterRigidBody.velocity += new Vector3(0, jump * boostFactor, 0);
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            other.gameObject.SetActive(false);
            SpeedBoostTimerStart = true;
        }

        if (other.gameObject.CompareTag("Slowmo"))
        {
            SlowmoTimerStart = true;
            other.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;           
        }
    }

    private void SpeedBoostTimer(float seconds)
    {
        if (SpeedBoostTimerStart)
        {
            boostFactor = 2.0f;
            boostDeadline = Time.realtimeSinceStartup + seconds;
            SpeedBoostTimerStart = false;
        }
        if (Time.realtimeSinceStartup >= boostDeadline)
        {
            boostFactor = 1.0f;
        }
    }

    private void SlowmoTimer(float seconds)
    {
        if (SlowmoTimerStart)
        {
            TimeManager.SlowFactor = 0.2f;
            slowmoDeadline = Time.realtimeSinceStartup + seconds;
            SlowmoTimerStart = false;
        }
        if (Time.realtimeSinceStartup >= slowmoDeadline)
        {
            TimeManager.SlowFactor = 1.0f;
        }
    }
}
