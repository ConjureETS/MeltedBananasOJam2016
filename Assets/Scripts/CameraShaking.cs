using UnityEngine;
using System.Collections;

public class CameraShaking : MonoBehaviour
{

    public Rigidbody player;
    public bool isStoped;
    public float magnitude = 0f;
    //private float hauteurMax = 0.75f;
    private float intesity = 0f;
    private float shake = 0.05f;
    private float timeShaking = 10f;
    private float timeBreathing = 0f;
    Vector3 pos;
    Transform camera;

    // Use this for initialization
    void Awake()
    {
        if (camera == null)
        {
            camera = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        pos = camera.localPosition;
    }

    void FixedUpdate()
    {

        if (player.velocity.magnitude == 0)
        {
            timeBreathing += Time.deltaTime;
            float y = ((Mathf.Cos(timeBreathing)) / 4) + 0.85f;

            if (y < 0)
            {
                y = Mathf.Abs(y);
            }
            else if (y > 1)
            {
                float temp = y;
                y -= (temp - 1) * 2;
            }
            camera.localPosition = new Vector3(0, y, 0);
//            if (timeShaking > 5 && timeShaking < 11)
//            {
//                timeBreathing += Time.deltaTime;
//                float y = ((Mathf.Cos(timeBreathing)) /4) + 0.85f;
//
//                if (y < 0)
//                {
//                    y = Mathf.Abs(y);
//                }
//                else if (y > 1)
//                {
//                    float temp = y;
//                    y -= (temp - 1)*2;
//                }
//                camera.localPosition = new Vector3(0, y, 0);
//                Debug.LogWarning("y : " + y);
//                Debug.Log(camera.localPosition);
//                timeShaking -= Time.deltaTime;
//            }
//
//            else if (timeShaking > 0 && timeShaking < 5)
//            {
//                camera.localPosition = pos + Random.insideUnitSphere * intesity;
//
//                timeShaking -= Time.deltaTime;
//                intesity += Time.deltaTime * shake;
//            }
//
//            else
//            {
//                timeShaking = 0f;
//                camera.localPosition = pos;
//            }
        }
	   
    }
}
