using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockBounce : MonoBehaviour
{
    public int pointMultiplier = 1;
    public int numOfCollisions = 0;

    private void Start()
    {
        pointMultiplier = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioManager>().Play("Rock", 1 * Mathf.Pow(0.75f, numOfCollisions));
        numOfCollisions += 1;
    }
    private void OnTriggerEnter(Collider collision)
    {
        FindObjectOfType<AudioManager>().Play("Rock", 1 * Mathf.Pow(0.75f, numOfCollisions));
        numOfCollisions += 1;
    }
    public void AddKill()
    {
        pointMultiplier += 1;
        FindObjectOfType<scoreManager>().UpdateMultiplier(pointMultiplier);
    }
}
