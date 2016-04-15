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
    public float MaximumForce;
    private Rigidbody2D _playerBody;

    //Setting the player animator
    private Animator _animator;

    //sounds
    private AudioController _audioController;
    private AudioSource _runningSource;

    //Setting the jump variable to avoid air jumping
    private bool _isCollided;

    //Abandoned(?) idea of having the player jump further the more you hold the jump key down
    //float _actualJumpForce;

    //Our bitflag which checks if the fox is facing left or right
    public bool flipped;

    //bool that checks if fox is running
    public bool isRunning;

    //Setting the animation speed here
    public float animationSpeed;

    //Light in the darkness
    private GameObject lightObject;

    // Use this for initialization
    void Start ()
	{
	    _animator = GetComponent<Animator>();    
        _animator.speed = animationSpeed;

        _audioController = new AudioController();
        _runningSource = GetComponents<AudioSource>()[0];
        //_killPlayer = (KillPlayer) FindObjectOfType(typeof (KillPlayer));
        _playerBody = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    float currentForce = _playerBody.velocity.magnitude;

        if (currentForce > MaximumForce)
        {       
            float brakeSpeed = currentForce - MaximumForce;
            _playerBody.drag = brakeSpeed;
        }
        else
        {
            //Default drag value
            _playerBody.drag = 0.05f;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            isRunning = true;
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
            isRunning = true;
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
            isRunning = false;
        }

	    if (Input.GetKey(KeyCode.Space) && _isCollided)
	    {          
            //_actualJumpForce += JumpForce*0.1f;
            //if (_actualJumpForce < JumpForce)
            //{
	        isRunning = false;
            _playerBody.AddForce(new Vector2(0, JumpForce));
	        //}
	    }

	    //if (_killPlayer.died)
	    //{
	    //    UnityEngine.Debug.Log("I am hereee!");
        //     GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //     GetComponent<Rigidbody2D>().angularVelocity = 0f;
	    //    _killPlayer.died = false;
	    //} 

	    if (lightObject)
	    {
	        lightObject.transform.position = transform.position;
	    }
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            _animator.Play("PlayerJumping");
            _playerBody.AddForce(new Vector2(0, JumpForce + AdditionalJumpForce));
        }       
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if ((col.isTrigger && col.gameObject.tag.Equals("Ground")) || (col.isTrigger && col.gameObject.tag.Equals("Leaf")))
        {
            if (isRunning)
            {
                _animator.SetBool("IsRunning", true);
                _audioController.PlaySound(_runningSource);
            }
            else
            {
                _animator.SetBool("IsRunning", false);
                _audioController.StopSound(_runningSource);
            }
            _animator.SetBool("IsJumping", false);
            _isCollided = true;
            //_actualJumpForce = 0f;
        }

        if (col.gameObject.tag.Equals("Darkness") && !lightObject)
        {
            lightObject = (GameObject)Instantiate(Resources.Load("Light"), transform.position, Quaternion.identity);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Destroy(lightObject);
        _audioController.StopSound(_runningSource);
        _animator.SetBool("IsRunning", false);
        _animator.SetBool("IsJumping", true);
        _isCollided = false;
    }

}
