using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DiscordPresence;
using System;

public class DiscordRichPresenceIntegration : MonoBehaviour
{

    string detail;
    public int startTime;
    // Start is called before the first frame update
    void Awake()
    {
    }

    private void Start()
    {
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int cur_time = (int)(DateTime.UtcNow - epochStart).TotalSeconds;
        startTime = cur_time;
    }

    // Update is called once per frame
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if(sceneName == "Main")
        {
            sceneName = "Game";
        }
        detail = "";
        PresenceManager.UpdatePresence(detail: detail, state: "In " + sceneName, start: startTime);

        
    }
}
