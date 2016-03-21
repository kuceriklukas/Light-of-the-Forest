using UnityEngine;
using System.Collections;

public class SpiderBehaviour : MonoBehaviour
{

    private Animator _animator;
    //public GameObject target;
    //public float distance;
    //private int direction;
    public bool isGoingLeft;
    public float MovementSpeed = 1f;
    private bool flipped; 

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        //direction = 1;
        _animator.SetBool("IsWalking", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGoingLeft)
        {
            Vector3 flipRight = new Vector3(transform.localScale.x * -1, transform.localScale.y,
                transform.localScale.z);
            if (flipRight.x > 0 && flipped)
            {
                transform.localScale = flipRight;
                flipped = false;
            }
            transform.position += new Vector3(MovementSpeed, 0, 0);
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            Vector3 flipLeft = new Vector3(transform.localScale.x * -1, transform.localScale.y,
                transform.localScale.z);
            if (flipLeft.x < 0 && !flipped)
            {
                transform.localScale = flipLeft;
                flipped = true;
            }

            transform.position += new Vector3(MovementSpeed * -1, 0, 0);
            _animator.SetBool("IsWalking", true);
        }

        //if (Vector2.Distance(target.transform.position, transform.position) > distance)
        //{
        //    direction *= -1;     
        //   }
        //   transform.position += new Vector3(MovementSpeed * direction, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Wall"))
        {
            isGoingLeft = !isGoingLeft;
        }
    }
}

