using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    public GameObject nameWindow;
    public bool hasName = false;

    public string displayName;

    // Start is called before the first frame update
    void Start()
    {
        Login();
        DontDestroyOnLoad(this.gameObject);
    }
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Successful login");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }
        if(name == null)
        {
            FindObjectOfType<LeaderboardUI>().nameEnterPanel.SetActive(true);
        }
    }

    public void SubmitName(string playerName)
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = playerName,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }
    

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        displayName = result.DisplayName;
        Debug.Log("Updated display name");
    }

    void OnError(PlayFabError error)
    {
        Debug.LogWarning("Error while logging in");
        Debug.LogWarning(error.GenerateErrorReport());
    }
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Highscore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard data sent");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Highscore",
            StartPosition = 0,
            MaxResultsCount = 25
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }

        LeaderboardUI leaderboardUI = FindObjectOfType<LeaderboardUI>();
        if (leaderboardUI != null)
        {
            leaderboardUI.ClearData();
            foreach (var item in result.Leaderboard)
            {
                leaderboardUI.AddItem(item.Profile.DisplayName, item.Position, item.StatValue);
                print(item.Profile.DisplayName);
            }
            try
            {
                FindObjectOfType<LeaderboardUI>().RefreshUI();
            }
            catch
            {

            }
        }
    }
}
