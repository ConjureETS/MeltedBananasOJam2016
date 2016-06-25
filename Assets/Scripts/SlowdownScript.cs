using UnityEngine;
using System.Collections;

public class SlowdownScript : MonoBehaviour {

    private float duration = 5.0f;
    private bool pickedUp = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update()
    {
        if(pickedUp)
        {
            Time.timeScale = 0.5f;
            StartCoroutine(Wait(duration));
            Time.timeScale = 1.0f;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pickedUp = true;
            gameObject.SetActive(false);
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
