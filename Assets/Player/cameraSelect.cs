
using UnityEngine;

public class cameraSelect : MonoBehaviour
{
    public Camera cam;
    public Transform treeRotation;
    public GameObject[] objects;
    public float[] cooldowns;
    public float[] usage;
    public Vector3[] offset;
    [Space]
    public ObstacleSelection selection;
    public startStopParticle thunder;
    public startStopParticle rain;
    public bool canPlace = true;

    void Start()
    {
        cam = Camera.main;
        for (int i = 0; i < usage.Length; i++)
        {
            
            usage[i] = cooldowns[i];
        }
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
                            Instantiate(objects[selection.index], hit.point + offset[selection.index], treeRotation.rotation);
                            Debug.DrawLine(transform.position, hit.point);
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
                            Instantiate(objects[selection.index], hit.point + offset[selection.index], treeRotation.rotation);
                            Debug.DrawLine(transform.position, hit.point);
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
