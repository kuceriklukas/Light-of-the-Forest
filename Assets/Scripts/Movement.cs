using System;
using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    //Setting the movement variables
    public float HorizontalSpeed;
    public float JumpForce;

    //Setting the player animator
    private Animator _animator;
    //Setting the jump variable to avoid air jumping
    private bool _isCollided = false;

    // Use this for initialization
    void Start ()
	{
	    _animator = GetComponent<Animator>();    
	}
	
	// Update is called once per frame
	void Update ()
	{

        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
	    {
            _animator.SetBool("IsRunningLeft", false);
            _animator.SetBool("IsRunningRight", true);
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += move * Time.deltaTime * HorizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            _animator.SetBool("IsRunningRight", false);
            _animator.SetBool("IsRunningLeft", true);
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += move * Time.deltaTime * HorizontalSpeed;
        }
        else
        {
            _animator.SetBool("IsRunningLeft", false);
            _animator.SetBool("IsRunningRight", false);
        }

	    if (Input.GetKeyDown(KeyCode.Space) && _isCollided)
	    {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
	    }	    
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            _isCollided = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _isCollided = false;
    }
}
