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
    public bool isRunning = false;
    AudioManager manager;
    float targetVolume = 0;
    float volume = 0;
    public bool isThunder;

     

    void Start()
    { 
        toggleParticle(false);
        manager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (isRunning)
        {
            time -= Time.deltaTime;
        }
        if(time <= 0)
        {
            toggleParticle(false);
            time = destroyTime;
        }
        volume = Mathf.Lerp(volume, targetVolume, Time.deltaTime);
        if (isThunder)
        {
            manager.setVolume("Rain1", volume);
        }
        else
        {
            manager.setVolume("Rain2", volume);
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
            targetVolume = 1;

        }
        else
        {
            isRunning = false;
            particle1.Stop();
            particle2.Stop();
            if (particle3 != null)
            {
                particle3.Stop();
            }
            targetVolume = 0;
        }
    }

}
