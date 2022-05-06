using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseUI : MonoBehaviour
{
    public bool canPause = false;
    public bool isPaused = false;
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    pauseUI.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    pauseUI.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
        else
        {
            isPaused = false;
        }
    }
    
    public void boolPause(bool pauser)
    {
        isPaused = pauser;
        if (isPaused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
