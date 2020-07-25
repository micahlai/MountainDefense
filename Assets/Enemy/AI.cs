using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent nav;
    public float maxSpeed = 10;
    public float minSpeed = 1;
    public float speed;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        speed = Random.Range(minSpeed, maxSpeed);
        nav.speed = speed;
        target = GameObject.Find("End");
    }

    void Update()
    {
        nav.SetDestination(target.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("End");
        }
    }
}