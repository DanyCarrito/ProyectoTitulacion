using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleManager : MonoBehaviour
{
    public ObjectPool objectPool;
    public float timeToRespawn;
    private float timer;

    public Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (timer > timeToRespawn)
            {
                timer = 0;
                GameObject pooledObject = objectPool.GetPooledObject();

                if (pooledObject != null)
                {
                    pooledObject.transform.position = spawnPosition;
                    pooledObject.SetActive(true);
                    pooledObject.GetComponent<TriangleMovement>().isActive = true;
                }
            }
        }
    }
}
