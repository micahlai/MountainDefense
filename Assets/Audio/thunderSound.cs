using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderSound : MonoBehaviour
{
    public ParticleSystem thunder;
    private int currentNumberOfParticles = 0;
    AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(thunder.particleCount > currentNumberOfParticles)
        {
            manager.Play("Thunder");
        }
        currentNumberOfParticles = thunder.particleCount;
    }
}
