using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSelection : MonoBehaviour
{
    public int index;
    public Vector2[] selectionPositions;
    public RectTransform selection;
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
            index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 3;
        }
    }
    IEnumerator Move(RectTransform rt, Vector2 targetPos)
    {
        float step = 0;
        while (step < 1)
        {
            rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime * 2);
            rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime * 2);
            yield return new WaitForEndOfFrame();
        }
    }
}
