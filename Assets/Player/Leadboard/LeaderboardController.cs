using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour
{
    public PlayfabManager manager;

    public static LeaderboardController main;

    private void Awake()
    {
        manager = FindObjectOfType<PlayfabManager>();
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SendScore()
    {
        manager.SendLeaderboard(FindObjectOfType<scoreManager>().scoreNum);
    }
}
    