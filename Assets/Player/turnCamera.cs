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
    private bool isTurning = false;

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
            isTurning = false;
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
            StartCoroutine(turnLerp(positions[0], speed));
        }
        if (Input.GetKey(KeyCode.W))
        {
            StartCoroutine(turnLerp(positions[1], speed));
        }
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(turnLerp(positions[2], speed));
        }
        if (Input.GetKey(KeyCode.R))
        {
           StartCoroutine(turnLerp(positions[3], speed));
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
    IEnumerator turnLerp (float position, float speed)
    {
        isTurning = true;
        while(cartPos != position && isTurning)
        {
            cartPos = Mathf.Lerp(cartPos, position, Time.deltaTime * speed);
        }
        isTurning = false;
        yield return null;
    }
   
}
