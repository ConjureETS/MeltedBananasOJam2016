using UnityEngine;
using System.Collections;

public class SphereMover : MonoBehaviour {
    public Vector3 pointB;
    private float rate;

     IEnumerator Start()
     {
         var pointA = transform.position;
         while (true) {
             yield return StartCoroutine(MoveObject(transform, pointA, pointB, 1.0f));
             yield return StartCoroutine(MoveObject(transform, pointB, pointA, 1.0f));
         }
     }
  
     IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
     {
         var i= 0.0f;
         //rate = 1.0f/time;
         while (i < 1.0f) {
             i += Time.deltaTime * TimeManager.SlowFactor;
             thisTransform.position = Vector3.Lerp(startPos, endPos, i);
             yield return null; 
         }
     }
}
