using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startStopParticle : MonoBehaviour
{
    public bool isParticleActivated;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    private float time = 20;
    public float destroyTime = 20;
    bool isRunning = false;
    public skyBoxChange sky;
    // Start is called before the first frame update
    void Start()
    {
        toggleParticle(false);
    }

    private void Update()
    {
        if (isRunning)
        {
            time -= Time.deltaTime;
            print(time);
        }
        if(time <= 0)
        {
            toggleParticle(false);
            time = destroyTime;
        }
    }
    // Update is called once per frame
    public void toggleParticle(bool activated)
    {
        isParticleActivated = activated;
        if (isParticleActivated)
        {
            
                isRunning = true;
                particle1.Play();
            particle2.Play();
            if (particle3 != null)
            {
                particle3.Play();
            }
            sky.changeSkybox(true, sky.darkExpose, sky.normalExpose);

        }
        else
        {
           
                particle1.Stop();
            particle2.Stop();
            if (particle3 != null)
            {
                particle3.Stop();
            }
            isRunning = false;
            sky.changeSkybox(false, sky.darkExpose, sky.normalExpose);

        }
    }

}
