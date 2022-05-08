using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLeaderboard : MonoBehaviour
{
    public void GetScores()
    {
        LeaderboardController.main.manager.GetLeaderboard();
    }
}
