using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class FloorTileGenerator : MonoBehaviour {

    public GameObject tile;
    public int x;
    public int y;
    public GameObject[] floorArray;
    //public GameObject[] testArray;
	// Use this for initialization
	void Start () {
        CreateFloor();
        
	}
    void CreateFloor()
    {
        floorArray = new GameObject[x*y];
        for (int i = 0; i < x * y; ++i)
        {
            floorArray[i] = (GameObject)Instantiate(tile, new Vector3(i/y, 0, i%y), new Quaternion());
            floorArray[i].name = i/y + "," + i%y;
        }
    }
    

}
