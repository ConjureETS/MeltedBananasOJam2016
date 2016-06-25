using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    GameObject gameController;


    // Use this for initialization
    void Start () {

        gameController = GameObject.Find("GameController");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tile")
        {// && gameController.GetComponent<GameController>().fallTriggerActivated == true
            other.GetComponent<TileController>().wasTouched = true;
            Debug.Log("Tile touched");
        }
        if (other.tag == "Trigger")
        {
            Debug.Log("Trigger entered");
            //gameController.GetComponent<GameController>().fallTriggerActivated = true;
        }
    }
}
