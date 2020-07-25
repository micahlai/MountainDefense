using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnCamera : MonoBehaviour
{
    public CinemachineDollyCart cart;
    public float cartPos = 0;
    public float[] positions;
    public float speed = 0.1f;
    public float mouseDragMultiplier = 300;
    float currentPos;
    public bool lockOnHold = true;
    [Space]
    public Camera cam;
    public float scale;
    private float mousePos;

    // Start is called before the first frame update
    void Start()
    {
        cart.m_Position = cartPos;
    }

    // Update is called once per frame
    void Update()
    {
        cart.m_Position = cartPos;

        mousePos = (Input.mousePosition.x / Screen.width);

        if (mousePos > 1)
        {
            mousePos = 1f;
            cartPos += mouseDragMultiplier * Time.deltaTime;
        }
        if (mousePos < 0)
        {
            mousePos = 0f;
            cartPos -= mouseDragMultiplier * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cartPos = positions[0];
        }
        if (Input.GetKey(KeyCode.W))
        {
            cartPos = positions[1];
        }
        if (Input.GetKey(KeyCode.E))
        {
            cartPos = positions[2];
        }
        if (Input.GetKey(KeyCode.R))
        {
           cartPos = positions[3];
        }
        cam.orthographicSize -= Input.mouseScrollDelta.y * scale;
        if (cam.orthographicSize > 120)
        {
            cam.orthographicSize = 120;
        }
        if (cam.orthographicSize < 10)
        {
            cam.orthographicSize = 10;
        }

    }
   
   
}
