using UnityEngine;
using System.Collections;

public class SphereMover : MonoBehaviour {

    public float speed = 2.0f;
    private bool goingRight = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (goingRight)
             transform.Translate (Vector2.right * speed * Time.deltaTime);
         else
             transform.Translate (-Vector2.right * speed * Time.deltaTime);
         
        if(transform.position.x >= transform.position.x + 4.0f) {
            goingRight = false;
         }
         
        if(transform.position.x <= transform.position.x -4) {
            goingRight = true;
         }
	}
}
