using UnityEngine;

public class MoveMouse : MonoBehaviour
{
    Camera cam;
    Vector3 previousPosition;

    public float speed;
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


        Vector3 direction = (mousePos - transform.position).normalized;
        Vector2 direction2d = new Vector2(direction.x, direction.y);

        rb.velocity += direction2d * Time.deltaTime * speed;

    }
}
