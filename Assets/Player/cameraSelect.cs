
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class cameraSelect : MonoBehaviour
{
    public Camera cam;
    public GameObject[] objects;
    public float[] cooldowns;
    public float[] usage;
    public Vector3[] offset;
    [Space]
    public ObstacleSelection selection;
    public startStopParticle thunder;
    public startStopParticle rain;
    public bool canPlace = true;
    
    public GameObject treePreview;

    public bool mobileInput = false;
    bool startedWithRay;

    void Start()
    {
        startedWithRay = false;
        cam = Camera.main;
        for (int i = 0; i < usage.Length; i++)
        {
            
            usage[i] = cooldowns[i];
        }
        treePreview.SetActive(false);
    }
    void Update()
    {
        for (int i = 0; i < usage.Length; i++)
        {
            if(usage[i] < cooldowns[i])
            {
                usage[i] += Time.deltaTime;
            }
            if (usage[i] > cooldowns[i])
            {
                usage[i] = cooldowns[i];
            }
            selection.status[i] = (usage[i] / cooldowns[i])*100;
        }

        //Preview
        if (canPlace)
        {
            Ray rayPrev = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPrev;
            
            if (selection.index == 1 && (!mobileInput || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)))
            {
                if (Physics.Raycast(rayPrev, out hitPrev) && (hitPrev.transform.tag == "Level" || hitPrev.transform.tag == "Enemy"))
                {
                    if (usage[selection.index] >= cooldowns[selection.index])
                    {
                        Debug.DrawLine(transform.position, hitPrev.point, Color.white);
                        treePreview.SetActive(true);
                        treePreview.transform.LookAt(gameObject.transform);
                        treePreview.transform.position = hitPrev.point;
                        treePreview.transform.rotation = new Quaternion(0,treePreview.transform.rotation.y,0,treePreview.transform.rotation.w);
                    }
                    else
                    {
                        treePreview.SetActive(false);
                    }
                }
                else
                {
                    treePreview.SetActive(false);
                }
            }
            else
            {
                treePreview.SetActive(false);
            }
        }
        else
        {
            treePreview.SetActive(false);
        }

        if (!mobileInput)
        {
            if (Input.GetMouseButtonDown(0) && canPlace && !EventSystem.current.IsPointerOverGameObject())
            {
                placeSelection(cam.ScreenPointToRay(Input.mousePosition));
            }
        }
        else
        {
            if (Input.touchCount > 0 && !EventSystem.current.currentSelectedGameObject)
            {
                Touch touch = Input.touches[Input.touches.Length - 1];
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = cam.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    startedWithRay = Physics.Raycast(ray, out hit);
                }
                    
                if (touch.phase == TouchPhase.Ended)
                {
                    if (canPlace && startedWithRay)
                    {
                        placeSelection(cam.ScreenPointToRay(touch.position));
                    }
                }
            }
        }
    }

    void placeSelection(Ray r)
    {
        if (selection.index == 0 || selection.index == 1)
        {
            Ray ray = r;
            RaycastHit hit;
            if (selection.index == 0)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (usage[selection.index] >= cooldowns[selection.index])
                    {
                        Instantiate(objects[selection.index], hit.point + offset[selection.index], Quaternion.identity);
                        Debug.DrawLine(transform.position, hit.point, Color.red);
                        usage[selection.index] = 0;
                    }
                }
            }
            else if (selection.index == 1)
            {
                if (Physics.Raycast(ray, out hit) && (hit.transform.tag == "Level" || hit.transform.tag == "Enemy"))
                {
                    if (usage[selection.index] >= cooldowns[selection.index])
                    {
                        GameObject g = Instantiate(objects[selection.index], hit.point + offset[selection.index], Quaternion.identity);
                        if (g.GetComponent<Tree>() != null)
                        {
                            g.GetComponent<Tree>().point = hit.point;
                        }
                        Debug.DrawLine(transform.position, hit.point, Color.red);
                        usage[selection.index] = 0;
                    }
                }
            }
        }
        else if ((selection.index == 2 || selection.index == 3) && usage[selection.index] >= cooldowns[selection.index])
        {
            if (selection.index == 2)
            {
                rain.toggleParticle(true);
                usage[2] = 0;
            }
            if (selection.index == 3)
            {
                thunder.toggleParticle(true);
                Handheld.Vibrate();
                usage[3] = 0;


            }
        }
    }
}
