using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LayerMovement : MonoBehaviour
{
    //Scroll Speed
    public float scrollSpeed;
    private bool scrolling;
    //The variable that will reset the layers to original position
    //after each replay (otherwise they are remaining in the position they were stopped)
    private Vector2 savedOffset;
    //The ever increasing variable we need, to make Mathf work (replacing Time.time for reasons)
    private float customTime;
    //Setting varibales needed for player following
    private GameObject player;
    private float playerPositionHorizontal;
    private Vector3 layerPosition;
    private int i;
    private float _previousPosition;

    void Start()
    {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
        player = GameObject.FindGameObjectWithTag("Fox");
        layerPosition = transform.position;

        playerPositionHorizontal = player.transform.position.x;
        transform.position = new Vector3(playerPositionHorizontal, layerPosition.y, layerPosition.z);
        i = 0;
    }

    void FixedUpdate()
    {
        i++;
        if (i > 1)
        {
            _previousPosition = playerPositionHorizontal;
            i = 0;
        }
        //Layer scrolling
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            playerPositionHorizontal = player.transform.position.x;
            transform.position = new Vector3(playerPositionHorizontal, layerPosition.y, layerPosition.z);

            scrolling = !(Math.Abs(playerPositionHorizontal - _previousPosition) < 0.05f);
            if (scrolling)
            {
                customTime += Time.deltaTime;
                float x = Mathf.Repeat(customTime*scrollSpeed, 1);
                Vector2 offset = new Vector2(x, savedOffset.y);
                GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            playerPositionHorizontal = player.transform.position.x;
            transform.position = new Vector3(playerPositionHorizontal, layerPosition.y, layerPosition.z);

            scrolling = !(Math.Abs(playerPositionHorizontal - _previousPosition) < 0.05f);
            if (scrolling)
            {
                customTime -= Time.deltaTime;
                float x = Mathf.Repeat(customTime*scrollSpeed, 1);
                Vector2 offset = new Vector2(x, savedOffset.y);
                GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
            }
        }    
    }

    //When the game is stopped
    void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
