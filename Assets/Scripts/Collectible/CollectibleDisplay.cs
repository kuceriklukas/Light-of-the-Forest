using UnityEngine;
using System.Collections;

public class CollectibleDisplay : MonoBehaviour
{

    public float HowManyCollectibles;
    public float XOffSet;
    public float YOffSet;
    public static int CollectibleCount;

    private GameObject _camera;
    private Vector3 _cameraPosition;

	// Use this for initialization
	void Start ()
	{
	    CollectibleCount = 0;

        _camera = GameObject.FindGameObjectWithTag("MainCamera");
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.gameObject.GetComponent<TextMesh>().text = CollectibleCount + "/" + HowManyCollectibles;
        _cameraPosition = _camera.transform.position;
        this.gameObject.transform.position = new Vector3(_cameraPosition.x+XOffSet,_cameraPosition.y+YOffSet,-1);
	}
}
