using UnityEngine;

public class MoveMouse : MonoBehaviour
{
    Camera cam;
    LineRenderer line;
    Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        line = GetComponent<LineRenderer>();
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        
        
    }
}
