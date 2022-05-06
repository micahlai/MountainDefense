using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
//using UnityStandardAssets.Characters.ThirdPerson;

public class AI : MonoBehaviour
{
    public GameObject target;
    [HideInInspector]public NavMeshAgent nav;
    public float speed;
    public float speedMultiplier;
    private float normalSpeed;
    public GameObject death;
    public startStopParticle rain;
    public startStopParticle thunder;
    public scoreManager score;
    public endScript end;
    public GameObject slowDown;
    //public ThirdPersonCharacter character;


    void Awake()
    {
        end = FindObjectOfType<endScript>();
        score = FindObjectOfType<scoreManager>();
        rain = GameObject.Find("Rain").GetComponent<startStopParticle>();
        thunder = GameObject.Find("Thunder").GetComponent<startStopParticle>();
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        target = GameObject.Find("End");
        nav.SetDestination(target.transform.position);
        normalSpeed = speed;
        
    }

    void Update()
    {
        if (rain.isRunning || thunder.isRunning)
        {
            speed = normalSpeed / 3;
            slowDown.SetActive(true);
        }
        else
        {
            speed = normalSpeed;
            slowDown.SetActive(false);
        }
        if (thunder.isRunning)
        {
            StartCoroutine(waitAndDie(3));
        }

        nav.speed = speed * speedMultiplier;
       if(Vector3.Distance(transform.position, target.transform.position) < 7)
            {
            if (!end.ended)
            {
                end.finish(gameObject);
                end.ended = true;
            }
            
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            die();
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            rockBounce rock = other.gameObject.GetComponent<rockBounce>();
            if (rock == null)
            {
                die();
            }
            else
            {
                rock.AddKill();
                die(rock.pointMultiplier);
            }

        }
    }
    public void die(int multiplier = 1)
    {
        ParticleSystem ps = Instantiate(death, transform.position, transform.rotation).GetComponent<ParticleSystem>();
        ps.startColor = GetComponent<Renderer>().material.color;

        if (score != null)
        {
            score.scoreNum += 1 * multiplier;
        }
        Destroy(this.gameObject);
    }
    IEnumerator waitAndDie(int time)
    {
        yield return new WaitForSeconds(time);
        die();

    }
}