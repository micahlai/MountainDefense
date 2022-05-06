﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;

    public Vector3 point;

    public Vector2 sizeRange = new Vector2(1.5f, 4.5f);
    // Start is called before the first frame update
    void Start()
    {
        float size = Random.Range(sizeRange.x, sizeRange.y);
        transform.localScale = new Vector3(size, size, size);

        transform.position = point;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GrowSFX()
    {
        audioSource.Play();
    }
}
