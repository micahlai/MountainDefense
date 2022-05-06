using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("ree");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void explode(Transform position)
    {
        Instantiate(gameObject, position);
    }
}
