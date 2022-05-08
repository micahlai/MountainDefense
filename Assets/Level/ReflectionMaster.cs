using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionMaster : MonoBehaviour
{
    public Material normal;
    public Material reflective;

    public Renderer[] renderersAffected;

    [Range(0f, 1f)]
    public float reflectivness;

    void Update()
    {
        foreach(Renderer r in renderersAffected)
        {
            r.material.Lerp(normal, reflective, reflectivness);
        }
    }
}
