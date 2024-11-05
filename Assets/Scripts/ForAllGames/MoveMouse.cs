using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveMouse : MonoBehaviour
{
    Camera cam;
    Vector3 previousPosition;

    public float speed;
    public float radius;
    public Rigidbody2D rb;

    

   // public Transform posTarget; // Asigna el objeto objetivo desde el inspector
 //   private Vector3 posActual;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        //pos = N(posDes - posActual) sumarlo para ir lenro 
 
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

        mousePos.z = 0;

        Vector2 resta = (mousePos - transform.position);

        Vector2 desireV;


        if (resta.magnitude > radius)
        {
            //truncate
            //desireV = (mousePos - transform.position).normalized * speed;
            desireV = (mousePos - transform.position);
        }
        else
        {
            
            desireV = Truncate(resta.normalized, speed);
        }

        Vector2 currentVel = new Vector2(rb.velocity.x, rb.velocity.y);
        Vector2 SteeringVel = new Vector2(desireV.x - currentVel.x, desireV.y - currentVel.y);


        rb.AddForce(SteeringVel);
    }

    Vector2 Truncate(Vector2 v2, float size )
    {
        if(v2.magnitude < size)
        {
            return v2;
        }
        else
        {
            return v2.normalized * size;
        }
    }

    float Truncate(float n, float max)
    {
        if(n < max)
        {
            return n;
        }
        else
        {
            return max;
        }
    }
}

public static class DrawArrow
{
    public static void ForGizmo(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Gizmos.DrawRay(pos, direction);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
        Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
    }

    public static void ForGizmo(Vector3 pos, Vector3 direction, UnityEngine.Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Gizmos.color = color;
        Gizmos.DrawRay(pos, direction);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
        Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
    }

    public static void ForDebug(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Debug.DrawRay(pos, direction);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Debug.DrawRay(pos + direction, right * arrowHeadLength);
        Debug.DrawRay(pos + direction, left * arrowHeadLength);
    }
    public static void ForDebug(Vector3 pos, Vector3 direction, UnityEngine.Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Debug.DrawRay(pos, direction, color);

        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Debug.DrawRay(pos + direction, right * arrowHeadLength, color);
        Debug.DrawRay(pos + direction, left * arrowHeadLength, color);
    }
}
