using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    Vector3 targetV3;


    void Update()
    {
        if (target != null)
        {
            targetV3 = target.position;
        }
        gameObject.transform.LookAt(targetV3);
        
    }
}
