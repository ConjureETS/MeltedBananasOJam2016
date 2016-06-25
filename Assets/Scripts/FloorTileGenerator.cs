using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class FloorTileGenerator : MonoBehaviour {
    public bool Generated = false;
    public bool TileStartFalling;
    public GameObject tile;
    public int x;
    public int y;
    public int rowFalling = 0;
    public GameObject[] floorArray;
    //public GameObject[] testArray;
	// Use this for initialization
	void Start()
    {
        #if UNITY_EDITOR
        if(!Generated)
        {
            CreateFloor();
        }
        #endif
    }
    void CreateFloor()
    {
        floorArray = new GameObject[x * y];
        for (int i = 0; i < x * y; ++i)
        {
            floorArray[i] = (GameObject)Instantiate(tile, new Vector3(i / y, 0, i % y), new Quaternion());
            floorArray[i].name = i / y + "," + i % y;
        }
#if UNITY_EDITOR
        Generated = true;
#endif
    }
    void Update()
    {
        if (TileStartFalling)
        {
            RowFall(rowFalling);
        }
    }
    void RowFall(int j)
    {
        for (int i = j*y; i < (j+1)*y; ++i)
        {
            ((TileController)floorArray[i].GetComponent<TileController>()).wasTouched = true;
            //Destroy(floorArray[i],1);
        }
        if (j>x)
        {
            ++rowFalling;
        }
    }
    void End()
    {
#if UNITY_EDITOR
        for (int i = 0; i < x * y; ++i)
        {
            Destroy(floorArray[i]);
        }
#endif

    }

}
