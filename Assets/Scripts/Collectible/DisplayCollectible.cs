using UnityEngine;
using System.Collections;

public class DisplayCollectible : MonoBehaviour
{

    public static int CollectibleCount;

    private GameObject _camera;
    private Vector3 _cameraPositon;


	// Use this for initialization
	void Start ()
	{
	    CollectibleCount = 0;
        this.gameObject.GetComponent<TextMesh>().text = CollectibleCount + "/3 Apples";

        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update ()
	{
        this.gameObject.GetComponent<TextMesh>().text = CollectibleCount + "/3 Apples";
	    _cameraPositon = _camera.transform.position;
	    transform.position = new Vector3(_cameraPositon.x-7,_cameraPositon.y+3.5f, -1);
	}
}
