using UnityEngine;
using System.Collections;
using UnityEngine.AI;
//using UnityStandardAssets.Characters.ThirdPerson;

public class AI : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent nav;
    public float maxSpeed = 10;
    public float minSpeed = 1;
    public float speed;
    //public ThirdPersonCharacter character;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        speed = Random.Range(minSpeed, maxSpeed);
        nav.speed = speed;
        target = GameObject.Find("End");
        nav.SetDestination(target.transform.position);
    }

    void Update()
    {
        /*
        if (nav.remainingDistance > nav.stoppingDistance)
        {
            character.Move(nav.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
        */
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("End");
        }
        if (other.gameObject.CompareTag("Tree"))
        {
            Destroy(this);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}