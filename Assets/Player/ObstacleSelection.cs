using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSelection : MonoBehaviour
{
    public int index;
    public Vector2[] selectionPositions;
    public RectTransform selection;
    public Image[] fillImages;
    public Text[] percentages;
    public float[] status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Move(selection, selectionPositions[index]));
        selection.sizeDelta = new Vector2(55, 55);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Select(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Select(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Select(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Select(3);
        }

        index += Mathf.RoundToInt(Input.mouseScrollDelta.y);
        index = Mathf.Clamp(index, 0, 3);
        
        for (int i = 0; i < percentages.Length; i++)
        {
            percentages[i].text = Mathf.RoundToInt(status[i]).ToString() + "%";
            fillImages[i].fillAmount = status[i] / 100;
        }
    }
    IEnumerator Move(RectTransform rt, Vector2 targetPos)
    {
        float step = 0;
        while (step < 1)
        {
            rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime * 3);
            rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime * 3);
            yield return new WaitForEndOfFrame();
        }
    }
    public void Select(int i)
    {
        index = i;
    }
}
