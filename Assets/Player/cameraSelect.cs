
using UnityEngine;

public class cameraSelect : MonoBehaviour
{
    public Camera cam;
    public GameObject boulder;
    public GameObject tree;
    public Vector3 offset;
    public Transform treeRotation;
    public float treeDestroyTime = 100;

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
                
                Destroy(Instantiate(tree, hit.point + offset, treeRotation.rotation), treeDestroyTime);
            }
        }
    }
}
