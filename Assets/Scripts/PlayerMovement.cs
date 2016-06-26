using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0f;
    public float turn = 0f;

    public Rigidbody characterRigidBody;

    // Boost
    public float boostFactor = 1f;
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

        Vector3 fowardVector = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        if (Input.GetAxis("Vertical") > 0)
        {
            characterRigidBody.velocity = (fowardVector * speed * boostFactor * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            characterRigidBody.velocity = (-fowardVector * speed * boostFactor * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterRigidBody.velocity = (Vector3.Cross(-transform.up, fowardVector) * speed * boostFactor * Time.deltaTime );
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            characterRigidBody.velocity = (Vector3.Cross(transform.up, fowardVector) * speed * boostFactor * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpeedBoost")
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

    private void SpeedBoostTimer(float seconds)
    {
        if (SpeedBoostTimerStart)
        {
            boostFactor = 8.0f;
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
