using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float HorizontalSpeed;
    public float JumpForce;
    private Animator _animator;
    private bool _isCollided = false;

    private GameObject _layer1;
    public float Layer1Speed;

    private GameObject _layer2;

    private GameObject _layer3;
    public float Layer3Speed;

    private GameObject _layer4;
    public float Layer4Speed;
    // Use this for initialization
    void Start ()
	{
	    _animator = GetComponent<Animator>();
        _layer1 = GameObject.FindGameObjectWithTag("ForegroundLayer1");
        _layer2 = GameObject.FindGameObjectWithTag("GroundLayer2");
        _layer3 = GameObject.FindGameObjectWithTag("BlurryLayer3");
        _layer4 = GameObject.FindGameObjectWithTag("BackgroundLayer4");
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKey(KeyCode.RightArrow))
	    {
            _layer1.transform.position += new Vector3(((Input.GetAxis("Horizontal") * HorizontalSpeed) * -1) * Layer1Speed, 0);
            _layer3.transform.position += new Vector3(((Input.GetAxis("Horizontal") * HorizontalSpeed)) * Layer3Speed, 0);
            _layer4.transform.position += new Vector3(((Input.GetAxis("Horizontal") * HorizontalSpeed)) * Layer4Speed, 0);

            _animator.SetBool("IsRunningLeft", false);
            _animator.SetBool("IsRunningRight", true);
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += move * Time.deltaTime * HorizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _layer1.transform.position += new Vector3(((Input.GetAxis("Horizontal") * HorizontalSpeed) * -1) * Layer1Speed, 0);
            _layer3.transform.position += new Vector3(((Input.GetAxis("Horizontal") * HorizontalSpeed)) * Layer3Speed, 0);
            _layer4.transform.position += new Vector3((Input.GetAxis("Horizontal") * HorizontalSpeed) * Layer4Speed, 0);

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
