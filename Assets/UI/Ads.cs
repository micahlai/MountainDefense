using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
#if UNITY_IOS
    string gameId = "4766516";
#else
    string gameId = "4766517";
#endif
    void Start()
    {
        Advertisement.Initialize(gameId);
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("iosvideo"))
        {
            Advertisement.Show("iosvideo");
            
        }
    }
}
