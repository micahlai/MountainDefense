using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public Animator anim;
    public GameObject image;
    public PauseUI pause;
    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(true);
        StartCoroutine(waitAndDeactive(2.1f));
    }

    // Update is called once per frame
    public void quit()
    {
        Application.Quit();
    }
    public void loadScene(int scene)
    { 
        if (pause != null)
        {
            pause.boolPause(false);
        }
        StartCoroutine(transition(scene));
    }
    IEnumerator transition(int scene)
    {
        image.SetActive(true);
        anim.SetTrigger("Fade");
        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadSceneAsync(scene);
        yield return null;
    }
    IEnumerator waitAndDeactive(float time)
    {
        yield return new WaitForSeconds(time);
        image.SetActive(false);
    }
}
