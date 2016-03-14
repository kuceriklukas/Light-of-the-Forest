using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LayerMovement : MonoBehaviour
{
    public float scrollSpeed;
    private Vector2 savedOffset;
    private float customTime;

    void Start()
    {
        savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            customTime += Time.deltaTime;
            float x = Mathf.Repeat(customTime * scrollSpeed, 1);
            Vector2 offset = new Vector2(x, savedOffset.y);
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            customTime -= Time.deltaTime;
            float x = Mathf.Repeat(customTime * scrollSpeed, 1);
            Vector2 offset = new Vector2(x, savedOffset.y);          
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
    }

    void OnDisable()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
