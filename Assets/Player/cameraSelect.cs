
using UnityEngine;

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

    void Start()
    {
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
            
            if (selection.index == 1)
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
        

        
        


        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            if (selection.index == 0 || selection.index == 1)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
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
                            if(g.GetComponent<Tree>() != null)
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
                    usage[3] = 0;
                    

                }
            }
        }
    }
}
