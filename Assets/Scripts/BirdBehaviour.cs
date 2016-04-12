﻿using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class BirdBehaviour : MonoBehaviour {

	//private Animator _animator;

    //Variables for bird movement
    public bool isGoingLeft;
    public float MovementSpeed;
    private bool flipped;

    //Variables for bird stunning
    private float savedSpeed;
    private Stopwatch stopwatch;
    public bool stunned;

    // Use this for initialization
    void Start()
    {
        //_animator = GetComponent<Animator>();
        //_animator.SetBool("IsWalking", true);
        savedSpeed = MovementSpeed;
        stopwatch = Stopwatch.StartNew();
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
            //_animator.SetBool("IsWalking", true);
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
            //_animator.SetBool("IsWalking", true);
        }

        if (stunned && stopwatch.ElapsedMilliseconds >= 3000)
        {
            stunned = false;
            MovementSpeed = savedSpeed;
        }
        if (stopwatch.ElapsedMilliseconds > 10000)
        {
            Restart(stopwatch);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Wall"))
        {
            isGoingLeft = !isGoingLeft;
        }
    }

    public void Stun()
    {
        Restart(stopwatch);
        MovementSpeed = 0;
        stunned = true;
    }

    //Unity is using a subset of .NET 2.0 and Restart() is added in .NET 4.0, 
    //so I just made my own since the other is not available
    public void Restart(Stopwatch internalStopwatch)
    {
        internalStopwatch.Reset();
        internalStopwatch.Start();
    }
}
