
using UnityEngine;

public class cameraSelect : MonoBehaviour
{
    public Camera cam;
    public Transform treeRotation;
    public GameObject[] objects;
    public Vector3[] offset;
    [Space]
    public ObstacleSelection selection;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Destroy(Instantiate(objects[selection.index], hit.point + offset[selection.index], treeRotation.rotation));
                Debug.DrawLine(transform.position, hit.point);
            }
        }
    }
}
