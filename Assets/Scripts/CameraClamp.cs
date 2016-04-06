using UnityEngine;
using System.Collections;

public class CameraClamp : MonoBehaviour {

    //Camera Clamp variables
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Clamp setup
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, xMin, xMax);
        v3.y = Mathf.Clamp(v3.y, yMin, yMax);
        transform.position = v3;
    }
}
