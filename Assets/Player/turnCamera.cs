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

    //mobile input
    private float cameraStartPos;
    [HideInInspector]public bool movingCamera;
    public Touch cameraTouch;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        cart.m_Position = cartPos;
        movingCamera = false;
    }

    
    void Update()
    {
        //mobile input
        if(Input.touchCount > 0)
        {
            cameraTouch = Input.touches[Input.touches.Length - 1];
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(cameraTouch.position);

            if(cameraTouch.phase == TouchPhase.Began)
            {
                cameraStartPos = cartPos;

                Ray ray = cam.ScreenPointToRay(cameraTouch.position);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit))
                {
                    movingCamera = true;
                }
            }
            if(cameraTouch.phase == TouchPhase.Moved && movingCamera)
            {
                cartPos += -cameraTouch.deltaPosition.x * 0.0007f;
                
            }
            if(cameraTouch.phase == TouchPhase.Ended || cameraTouch.phase == TouchPhase.Canceled)
            {
                movingCamera = false;
            }
        }

        if (cartPos > 1)
        {
            cartPos = 0;
        }
        if(cartPos < 0)
        {
            cartPos = 1;
        }
        cart.m_Position = cartPos;

        if (!FindObjectOfType<cameraSelect>().mobileInput)
        {
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
