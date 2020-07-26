using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
    public float lastingTime;
    public bool destroyOverTime = true;
    // Start is called before the first frame update
    void Start()
    {
        if (destroyOverTime)
        {
            Destroy(gameObject, lastingTime);
        }
    }
    
    public void ObjectDestroy(float time)
    {
        Destroy(gameObject, time);
    }
}
