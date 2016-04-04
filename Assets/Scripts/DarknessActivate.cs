using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class DarknessActivate : MonoBehaviour
{
    private Stopwatch stopwatch;
    private GameObject _darknessChild;
    private bool flagForStopwatch;
    public int MillisecondsOfLight;
	// Use this for initialization
	void Start ()
	{   
        _darknessChild = gameObject.transform.GetChild(0).gameObject;
        stopwatch = Stopwatch.StartNew();
    }
	
	// Update is called once per frame
	void Update () {
	    if (!_darknessChild.activeSelf)
	    {           
            if (!flagForStopwatch)
	        {
	            Restart(stopwatch);
	            flagForStopwatch = true;
	        }
            if (stopwatch.ElapsedMilliseconds > MillisecondsOfLight && flagForStopwatch)
	        {
                _darknessChild.SetActive(true);
	            flagForStopwatch = false;
                stopwatch.Reset();
	        }
        }
    }

    //Unity is using a subset of .NET 2.0 and Restart() is added in .NET 4.0, 
    //so I just made my own since the other is not available
    public void Restart(Stopwatch internalStopwatch)
    {
        internalStopwatch.Reset();
        internalStopwatch.Start();
    }
}
