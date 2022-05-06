using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text score;
    public int scoreNum;
    public Text scoreDead;
    [Space]
    public Text scoreMultiplier;
    public float timeToDisappearMultiplier = 1;
    public int highestMultiplier;
    float additionalSize = 0;
    Color startingColor;
    public Color FlashColor;

    // Start is called before the first frame update
    void Start()
    {
        scoreNum = 1;
        startingColor = new Color(scoreMultiplier.color.r, scoreMultiplier.color.g, scoreMultiplier.color.b, 0);
        scoreMultiplier.text = "";
        scoreMultiplier.color = startingColor;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = (scoreNum - 1).ToString();
        scoreDead.text = "Your Score: " + (scoreNum - 1).ToString();

        additionalSize = Mathf.Lerp(additionalSize, 0, Time.deltaTime);
        scoreMultiplier.rectTransform.sizeDelta = new Vector2(scoreMultiplier.rectTransform.sizeDelta.x, 5 + additionalSize);
        
        scoreMultiplier.color = Color.Lerp(scoreMultiplier.color, startingColor, Time.deltaTime * timeToDisappearMultiplier);
        if(scoreMultiplier.color.a < 0.1)
        {
            highestMultiplier = 1;
        }
        
    }
    public void UpdateMultiplier(int multiplier)
    {
        if (multiplier > 1)
        {
            if(multiplier >= highestMultiplier)
            {
                highestMultiplier = multiplier;
                scoreMultiplier.text = "x" + multiplier.ToString();
                additionalSize = multiplier * 5;
                additionalSize = Mathf.Clamp(additionalSize, 0, 35);
                scoreMultiplier.color = FlashColor;
            }
        }
    }
}
