using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Movement : MonoBehaviour
{
    //Freezing the player when dead
    //private KillPlayer _killPlayer;

    //Setting the movement variables
    public float HorizontalSpeed;
    public float JumpForce;
    public float AdditionalJumpForce;

    //Setting the player animator
    private Animator _animator;

    //Setting the jump variable to avoid air jumping
    private bool _isCollided;

    //Abandoned(?) idea of having the player jump further the more you hold the jump key down
    //float _actualJumpForce;

    //Our bitflag which checks if the fox is facing left or right
    public bool flipped;

    //Setting the animation speed here
    public float animationSpeed;

    // Use this for initialization
    void Start ()
	{
	    _animator = GetComponent<Animator>();    
        _animator.speed = animationSpeed;
        //_killPlayer = (KillPlayer) FindObjectOfType(typeof (KillPlayer));
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
	    {
            _animator.SetBool("IsRunning", true);
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            Vector3 flipRight = new Vector3(transform.localScale.x * -1, transform.localScale.y,
                transform.localScale.z);
            if (flipRight.x < 0 && !flipped)
            {
                transform.localScale = flipRight;
                flipped = true;
            }
            transform.position += move * Time.deltaTime * HorizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            _animator.SetBool("IsRunning", true);
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            Vector3 flipLeft = new Vector3(transform.localScale.x * -1, transform.localScale.y,
                transform.localScale.z);
            if (flipLeft.x > 0 && flipped)
            {
                transform.localScale = flipLeft;
                flipped = false;
            }
            transform.position += move * Time.deltaTime * HorizontalSpeed;
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

	    if (Input.GetKey(KeyCode.Space) && _isCollided)
	    {          
            //_actualJumpForce += JumpForce*0.1f;
            //if (_actualJumpForce < JumpForce)
            //{
            _animator.SetBool("IsRunning", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
	        //}
	    }

	    //if (_killPlayer.died)
	    //{
	    //    UnityEngine.Debug.Log("I am hereee!");
        //     GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //     GetComponent<Rigidbody2D>().angularVelocity = 0f;
	    //    _killPlayer.died = false;
	    //} 
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            _animator.SetBool("IsJumping", false);
            _animator.Play("PlayerJumping");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce + AdditionalJumpForce));
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if ((col.isTrigger && col.gameObject.tag.Equals("Ground")) || (col.isTrigger && col.gameObject.tag.Equals("Leaf")))
        {
            _animator.SetBool("IsJumping", false);
            _isCollided = true;
            //_actualJumpForce = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _animator.SetBool("IsJumping", true);
        _isCollided = false;
    }
}
