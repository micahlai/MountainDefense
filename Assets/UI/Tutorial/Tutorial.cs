using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Animator anim;
    public Text text;
    public string[] messages;
    private int tutorialIndex = 0;
    [Space]
    public EnemySpawner spawner;
    public Load loader;

    bool newSlide = false;
    // Start is called before the first frame update
    void Start()
    {
        spawner.canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = messages[tutorialIndex];
        if (tutorialIndex == 6 && newSlide)
        {
            spawner.canSpawn = true;
            newSlide = false;
        }
        if (tutorialIndex == 7 && newSlide)
        {

            for (int i = 0; i < 4; i++)
            {
                spawner.SpawnEnemyOnPoint(0);
                newSlide = false;
            }
        }
        if (tutorialIndex == 15 && newSlide)
        {
            anim.SetTrigger("Fade");
            StartCoroutine(waitAndLoad(1));
            newSlide = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tutorialIndex < 15)
            {
                tutorialIndex++;
                newSlide = true;
            }
        }

    }
    
    IEnumerator waitAndLoad(float time)
    {
        yield return new WaitForSeconds(time);
        loader.loadScene(0);
    }
}
