using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour {
    public Material mat;
    public float blindness = 0.5f;
    public Rigidbody character;
    public float blindnessRatio = 0.1f;
    public float blindnessSpeed = 0.1f;
    public float velocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Vector2 planarVelocity = new Vector3(character.velocity.x, 0, character.velocity.z);
        if (character.velocity.magnitude > 0)
        {
            blindness =  1 * blindnessRatio;
            blindnessRatio += 0.01f;
        }
        else if (blindnessRatio >= 0.1f)
        {
            blindnessRatio -= 0.01f;
            blindness = 1 * blindnessRatio;
        }
       

        mat.SetFloat("_Blindness", blindness);
        Graphics.Blit(src, dest,mat);
    }
}
