using UnityEngine;
using System.Collections;

public class SlowdownScript : MonoBehaviour {

    private float duration = 5.0f;
    private bool SlowmoActive = false;

	// Use this for initialization
	void Start () {
	    
	}

    void FixedUpdate()
    {
        if (SlowmoActive)
        {
            SlowmoTimer(5.0f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SlowmoActive = true;
            gameObject.SetActive(false);
        }
    }

    private void SlowmoTimer(float seconds)
    {
        float initialTime = Time.realtimeSinceStartup + seconds;
        Time.timeScale = 0.5f;
        SlowmoActive = false;
        if (initialTime + Time.deltaTime >= initialTime)
        {
            Time.timeScale = 1f;
        }
    }
}
