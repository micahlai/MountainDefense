using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnCamera : MonoBehaviour
{
    public CinemachineDollyCart cart;
    public float cartPos = 0;
    public float[] positions;
    public float snapSpeed = 10;
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
        Cursor.lockState = CursorLockMode.Confined;
        cart.m_Position = cartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (cartPos > 1)
        {
            cartPos = 0;
        }
        if(cartPos < 0)
        {
            cartPos = 1;
        }
        cart.m_Position = cartPos;

        mousePos = (Input.mousePosition.x / Screen.width);

        if (mousePos > 0.98 || Input.GetKey(KeyCode.D))
        {
            mousePos = 1f;
            cartPos += mouseDragMultiplier * Time.deltaTime;
        }
        if (mousePos < 0.02 || Input.GetKey(KeyCode.A))
        {
            mousePos = 0f;
            cartPos -= mouseDragMultiplier * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            SmoothCameraOnCircle(0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            SmoothCameraOnCircle(1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            SmoothCameraOnCircle(2);
        }
        if (Input.GetKey(KeyCode.R))
        {
            SmoothCameraOnCircle(3);
        }
        

    }
    void SmoothCameraOnCircle(int indexTarget)
    {
        if (Mathf.Abs(cartPos - positions[indexTarget]) < 0.5)
        {
            cartPos = Mathf.Lerp(cartPos, positions[indexTarget], Time.deltaTime * snapSpeed);
        }
        else
        {
            cartPos = Mathf.Lerp(cartPos, positions[indexTarget] + 1, Time.deltaTime * snapSpeed);
        }
    }
   
   
}
