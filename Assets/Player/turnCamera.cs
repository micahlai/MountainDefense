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
            cartPos = (-Input.mousePosition.x / Screen.width * mouseDragMultiplier) + currentPos;
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
            cartPos = Mathf.Lerp(cartPos, positions[0], Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            cartPos = Mathf.Lerp(cartPos, positions[1], Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            cartPos = Mathf.Lerp(cartPos, positions[2], Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.R))
        {
            cartPos = Mathf.Lerp(cartPos, positions[3], Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            isZoomed = !isZoomed;
        }

        if (isZoomed)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * smooth);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, normal, Time.deltaTime * smooth);
        }

    }
    void lerpValue(float start, float end, float speed)
    {
        for (float i = 0; i < 100; i += speed * Time.deltaTime)
        {
           cartPos = Mathf.Lerp(start, end, i / 100);
        }
        

        
    }
   
}
