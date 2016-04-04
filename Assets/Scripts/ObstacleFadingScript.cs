using UnityEngine;
using System.Collections;

public class ObstacleFadingScript : MonoBehaviour
{

    public GameObject Tree;
    public Color A = Color.magenta;
    public Color B = Color.blue;
    public float speed = 1.0f;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
	{
        Tree = this.gameObject;
	    spriteRenderer = Tree.GetComponent<SpriteRenderer>();
	    spriteRenderer.color = Color.red;
	    foreach (var component in Tree.GetComponents<PolygonCollider2D>())
	    {
	        component.enabled = false;
	    }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnMouseDown()
    {
        
        spriteRenderer.color = Color.Lerp(A, B, Mathf.PingPong(Time.time * speed, 1.0f));
        foreach (var component in Tree.GetComponents<PolygonCollider2D>())
        {
            component.enabled = true;
        }
        
    }
}
