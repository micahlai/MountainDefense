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
    public GameObject death;
    public GameObject clone;
    //public ThirdPersonCharacter character;


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        speed = Random.Range(minSpeed, maxSpeed);
        nav.speed = speed;
        target = GameObject.Find("End");
        nav.SetDestination(target.transform.position);
        death = GameObject.Find("Death");
        clone = Instantiate(death);
        clone.SetActive(false);
    }

    void Update()
    {
        clone.transform.position = transform.position;
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
            die();
        }
        if (other.gameObject.CompareTag("Tree"))
        {
            die();
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            die();

        }
    }
    public void die()
    {
        clone.SetActive(true);
        clone.GetComponent<destroyAfterTime>().ObjectDestroy(5);
        Destroy(this.gameObject);
    }
}