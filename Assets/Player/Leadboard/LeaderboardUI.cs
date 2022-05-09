using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LeaderboardUI : MonoBehaviour
{
    public RectTransform ContentParent;
    public int rowHeight;
    public List<LeaderboardPosition> leaderboardPositions;
    public GameObject rowPrefab;
    public List<LeaderboardRow> leaderboardRows;


    public InputField nameEnter;
    public GameObject nameEnterPanel;
    public Text errorText;
    // Start is called before the first frame update
    void Start()
    {
        errorText.text = "";
        nameEnterPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ContentParent.sizeDelta = new Vector2(ContentParent.sizeDelta.x, leaderboardPositions.ToArray().Length * rowHeight);
    }
    public void RefreshUI()
    {


        foreach(LeaderboardRow lr in leaderboardRows)
        {   
            leaderboardRows.Remove(lr);
            Destroy(lr.gameObject);
        }
        foreach(LeaderboardPosition lp in leaderboardPositions)
        {
             GameObject gb = Instantiate(rowPrefab, ContentParent);
            LeaderboardRow lr = gb.GetComponent<LeaderboardRow>();
            leaderboardRows.Add(lr);

            lr.leaderPos = lp;
        }
    }
    public void ClearData()
    {
        foreach(LeaderboardPosition lp in leaderboardPositions)
        {
            leaderboardPositions.Remove(lp);
        }
    }
    public void AddItem(string playerName, int rank, int score)
    {
        LeaderboardPosition lp = new LeaderboardPosition();

        lp.name = playerName;
        lp.rank = rank;
        lp.score = score;
        leaderboardPositions.Add(lp);
    }
    public void SubmitName()
    {
        string playerName = nameEnter.text;
        if (playerName != "")
        {
            errorText.text = "";
            nameEnterPanel.SetActive(false);
            FindObjectOfType<PlayfabManager>().SubmitName(playerName);
        }
        else
        {
            errorText.text = "Player name cannot be empty";
        }
    }
    public void UpdateInputField()
    {
        nameEnter.text = FindObjectOfType<PlayfabManager>().displayName;
    }
}
