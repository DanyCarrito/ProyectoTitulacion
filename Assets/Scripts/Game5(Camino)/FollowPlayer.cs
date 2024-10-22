using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // El objeto a seguir
    public float speed; // Velocidad de seguimiento

    void Update()
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
