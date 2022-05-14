using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRow : MonoBehaviour
{
    public Text rank;
    public Text playerName;
    public Text score;
    [Space]
    public Image bg;
    [Space]
    public Color gold;
    public Color silver;
    public Color bronze;
    [Space]
    public LeaderboardPosition leaderPos;

    private void Update()
    {
        rank.text = (leaderPos.rank + 1).ToString();
        playerName.text = leaderPos.name;
        score.text = leaderPos.score.ToString();

        if(leaderPos.rank == 0)
        {
            bg.color = gold;
        }
        else if (leaderPos.rank == 1)
        {
            bg.color = silver;
        }
        else if (leaderPos.rank == 2)
        {
            bg.color = bronze;
        }
    }
}
