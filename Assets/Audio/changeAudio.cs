using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class changeAudio : MonoBehaviour
{
    public AudioMixer mixer;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mixer.SetFloat("Volume", volume);
    }
}
