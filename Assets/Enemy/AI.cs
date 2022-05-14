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

    bool canDie;
    float TimeToDeath;
    bool startDeathCountdown;
    //public ThirdPersonCharacter character;

    Quaternion q;

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
    private void Start()
    {
        nav.updateRotation = false;
        canDie = true;
        startDeathCountdown = false;
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

        nav.speed = speed * speedMultiplier;
       if(Vector3.Distance(transform.position, target.transform.position) < 7)
            {
            if (!end.ended)
            {
                end.finish(gameObject);
                end.ended = true;
            }
            
        }
        if (nav.velocity.normalized != Vector3.zero)
        {
            q = Quaternion.LookRotation(nav.velocity.normalized);
            q.x = 0;
            q.z = 0;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.fixedDeltaTime * 2);

        if(canDie && thunder.isRunning)
        {
            TimeToDeath = Random.Range(0.1f, 4f);
            startDeathCountdown = true;
            canDie = false;
        }

        if (startDeathCountdown)
        {
            TimeToDeath -= Time.deltaTime;
            if(TimeToDeath <= 0)
            {
                die();
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
        canDie = false;
        ParticleSystem ps = Instantiate(death, transform.position, transform.rotation).GetComponent<ParticleSystem>();
        ps.startColor = GetComponent<Renderer>().material.color;

        FindObjectOfType<AudioManager>().Play("Kill");

        if (score != null)
        {
            score.scoreNum += 1 * multiplier;
        }
        Destroy(this.gameObject);
    }
}