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
    // Start is called before the first frame update
    void Start()
    {
        spawner.canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = messages[tutorialIndex];
        if (tutorialIndex == 5)
        {
            spawner.canSpawn = true;
        }
        if (tutorialIndex == 12)
        {
            anim.SetTrigger("Fade");
            StartCoroutine(waitAndLoad(1));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tutorialIndex < 12)
            {
                tutorialIndex++;
            }
        }

    }
    
    IEnumerator waitAndLoad(float time)
    {
        yield return new WaitForSeconds(time);
        loader.loadScene(0);
    }
}
