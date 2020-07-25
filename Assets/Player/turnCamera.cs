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
    public int zoom = 60;
    public int normal = 100;
    public float smooth = 3;
    private bool isZoomed = false;
    public Camera cam;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        cart.m_Position = cartPos;
    }

    // Update is called once per frame
    void Update()
    {
        cart.m_Position = cartPos;
        if (Input.GetMouseButton(1))
        {
            float mousePos = Input.mousePosition.x / Screen.width;
            if(mousePos > 1)
            {
                mousePos = 1;
            }
            if(mousePos < 0)
            {
                mousePos = 0;
            }
            cartPos = (mousePos * mouseDragMultiplier) + currentPos;
            if (lockOnHold)
            {
                Cursor.visible = false;
            }

        }
        else
        {
            currentPos = cartPos;
            Cursor.visible = true;
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            //isZoomed = !isZoomed;
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
        /*
        if (isZoomed)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * smooth);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, normal, Time.deltaTime * smooth);
        }
        */

    }
   
   
}
