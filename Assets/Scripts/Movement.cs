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

    //Our bitflag which checks if the fox is facing left or right
    private bool flipped;

    // Use this for initialization
    void Start ()
	{
	    _animator = GetComponent<Animator>();    
        _animator.SetBool("IsRunning", true);
	}
	
	// Update is called once per frame
	void Update ()
	{

        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
	    {
            _animator.SetBool("IsRunning", true);
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            Vector3 flipRight = new Vector3(transform.localScale.x * -1, transform.localScale.y,
                transform.localScale.z);
            if (flipRight.x > 0 && flipped)
            {
                transform.localScale = flipRight;
                flipped = false;
            }
            transform.position += move * Time.deltaTime * HorizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            _animator.SetBool("IsRunning", true);
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            Vector3 flipLeft = new Vector3(transform.localScale.x * -1, transform.localScale.y,
                transform.localScale.z);
            if (flipLeft.x < 0 && !flipped)
            {
                transform.localScale = flipLeft;
                flipped = true;
            }
            transform.position += move * Time.deltaTime * HorizontalSpeed;
        }
        else
        {
            _animator.SetBool("IsRunning", false);
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
