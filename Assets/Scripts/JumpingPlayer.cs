using UnityEngine;
using System.Collections;

public class JumpingPlayer : MonoBehaviour
{

    public float jump = 0f;
    private Rigidbody rb;
    private bool isGrounded;
    Vector3 up;


    void Start()
    {
        up = new Vector3();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
        Debug.LogWarning(isGrounded);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            up = rb.velocity;
            up.y = jump;
            rb.velocity = up;
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }
}
