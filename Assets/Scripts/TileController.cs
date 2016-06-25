using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour
{

    public float speed;
    public float speedAddition;
    public float seconds;
    public bool wasTouched;
    public bool timerStart;
    float initialTime;
    private bool hasStartedMovement;
    Vector3 movement;
    //GameObject gameController;

    // Use this for initialization
    void Start()
    {
        movement = new Vector3(0.0f, -1, 0.0f);
        timerStart = false;
        //gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (wasTouched == true)
        {
            CountdownUntilFall(seconds);
        }
        if (hasStartedMovement == true)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
            speed = speed + speedAddition;
        }
    }

    private void CountdownUntilFall(float seconds)
    {
        if (!timerStart)
        {
            initialTime = Time.realtimeSinceStartup + seconds;
            timerStart = true;
        }
        if (Time.realtimeSinceStartup >= initialTime)
        {
            hasStartedMovement = true;
        }

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "DestroyTrigger")
        {
            Destroy(this.gameObject);
        }
    }
}
