using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleManager : MonoBehaviour
{
    public ObjectPool objectPool;
    public float timeToRespawn;
    private float timer;

    public Vector2 spawnPosition;

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && PanelManager.Instance.isTutorialOver)
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
