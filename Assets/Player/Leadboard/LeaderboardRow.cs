using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRow : MonoBehaviour
{
    public Text rank;
    public Text playerName;
    public Text score;

    public LeaderboardPosition leaderPos;

    private void Update()
    {
        rank.text = (leaderPos.rank + 1).ToString();
        playerName.text = leaderPos.name;
        score.text = leaderPos.score.ToString();
    }
}
