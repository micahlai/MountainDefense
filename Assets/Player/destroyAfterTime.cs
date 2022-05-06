using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class destroyAfterTime : MonoBehaviour
{
    public float lastingTime;
    public bool destroyOverTime = true;
    public UnityEvent deathEvent;
    public float eventTimeOffset;
    float TimeAlive = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FixedUpdate()
    {
        if (destroyOverTime)
        {
            TimeAlive += Time.deltaTime;
            if (TimeAlive > lastingTime - eventTimeOffset)
            {
                deathEvent.Invoke();
            }
            if (TimeAlive > lastingTime)
            {
                Destroy(gameObject);
            }

        }
    }

    public void ObjectDestroy(float time)
    {
        Destroy(gameObject, time);
    }
}
