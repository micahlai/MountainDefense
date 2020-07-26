using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyBoxChange : MonoBehaviour
{

    public float normalExpose = 0.75f;
    public float darkExpose = 0.25f;
    public bool isDark;
    // Start is called before the first frame update
    void Start()
    {
        if (isDark)
        {
            RenderSettings.skybox.SetFloat("_Exposure", darkExpose);
        }
        else if (!isDark)
        {
            RenderSettings.skybox.SetFloat("_Exposure", normalExpose);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeSkybox(bool dark, float darkLight, float normalLight)
    {
        isDark = dark;
        if (dark)
        {
            for (float i = darkLight; i < normalLight; i++)
            {
                RenderSettings.skybox.SetFloat("_Exposure", i);
            }
        }
        else
        {
            for (float i = normalLight; i > darkLight; i++)
            {
                RenderSettings.skybox.SetFloat("_Exposure", i);
            }
        }
    }
}
