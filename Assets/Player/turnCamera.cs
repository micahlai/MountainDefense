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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lerpValue(cartPos, positions[0], speed);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            lerpValue(cartPos, positions[1], speed);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            lerpValue(cartPos, positions[2], speed);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            lerpValue(cartPos, positions[3], speed);
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
