using UnityEngine;
using System.Collections;

public class SeekerController : MonoBehaviour {

    bool isAggroed;
    float step;
    public float speed;
    GameObject player;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Aggro")
        {
            //isAggroed = true;
            agent.destination = player.transform.position;
        }
        //if (isAggroed == true)
        //{
        //    agent.destination = player.transform.position;

        //}
    }
}
