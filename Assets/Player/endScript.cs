using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScript : MonoBehaviour
{
    public Animator deadAnim;
    public bool ended = false;
    public GameObject dead;
    public LookAt cameraTarget;
    public PauseUI pause;
    private bool zoom = false;
    public EnemySpawner spawner;
    public cameraSelect select;
    // Start is called before the first frame update
    void Start()
    {
        dead.SetActive(false);
        pause = FindObjectOfType<PauseUI>();
        spawner = FindObjectOfType<EnemySpawner>();
        select = FindObjectOfType<cameraSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zoom)
        {
            
            if(!(Camera.main.orthographicSize <= 10))
            {
                Camera.main.orthographicSize -= Time.deltaTime * 40;
            }
            else
            {
                
                dead.SetActive(true);
                deadAnim.SetTrigger("Dead");
                zoom = false;
            }
        }
    }
    public void finish(GameObject enemy)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Tutorial")
        {
            spawner.canSpawn = false;
            pause.canPause = false;
            select.canPlace = false;
            cameraTarget.target = enemy.transform;
            zoom = true;

            LeaderboardController.main.SendScore();
        }
        else
        {
            FindObjectOfType<Tutorial>().Leak();
            enemy.GetComponent<AI>().die();
        }

    }
}
