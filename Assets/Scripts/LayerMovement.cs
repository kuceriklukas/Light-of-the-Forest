using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LayerMovement : MonoBehaviour
{
    //Scroll Speed
    public float scrollSpeed;
    //The variable that will reset the layers to original position
    //after each replay (otherwise they are remaining in the position they were stopped)
    private Vector2 savedOffset;
    //The ever increasing variable we need, to make Mathf work (replacing Time.time for reasons)
    private float customTime;
    //Setting varibales needed for player following
    private GameObject player;
    private float playerPositionHorizontal;
    private Vector3 layerPosition;

    void Start()
    {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
        player = GameObject.FindGameObjectWithTag("Fox");
        layerPosition = transform.position;
    }

    void FixedUpdate()
    {
        //Layer scrolling
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            customTime += Time.deltaTime;
            float x = Mathf.Repeat(customTime * scrollSpeed, 1);
            Vector2 offset = new Vector2(x, savedOffset.y);
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);

            playerPositionHorizontal = player.transform.position.x;
            transform.position = new Vector3(playerPositionHorizontal, layerPosition.y, layerPosition.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            customTime -= Time.deltaTime;
            float x = Mathf.Repeat(customTime * scrollSpeed, 1);
            Vector2 offset = new Vector2(x, savedOffset.y);          
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);

            playerPositionHorizontal = player.transform.position.x;
            transform.position = new Vector3(playerPositionHorizontal, layerPosition.y, layerPosition.z);
        }
    }
    //When the game is stopped
    void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
