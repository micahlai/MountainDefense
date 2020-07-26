
using UnityEngine;

public class cameraSelect : MonoBehaviour
{
    public Camera cam;
    public Transform treeRotation;
    public GameObject[] objects;
    public Vector3[] offset;
    [Space]
    public ObstacleSelection selection;
    public startStopParticle thunder;
    public startStopParticle rain;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            if (selection.index == 0 || selection.index == 1)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    Instantiate(objects[selection.index], hit.point + offset[selection.index], treeRotation.rotation);
                    Debug.DrawLine(transform.position, hit.point);

                }
            }else if (selection.index == 2 || selection.index == 3)
            {
                if(selection.index == 2)
                {
                    rain.toggleParticle(true);
                }
                if (selection.index == 3)
                {
                    thunder.toggleParticle(true);
                }
            }
        }
    }
}
