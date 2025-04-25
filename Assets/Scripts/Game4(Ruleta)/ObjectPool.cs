using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; 
    public int poolSize = 10; 

    public List<GameObject> pool; 

    void Start()
    {
        pool = new List<GameObject>();

        //for (int i = 0; i < poolSize; i++)
        //{
        //    GameObject obj = Instantiate(prefab);
        //    obj.SetActive(false); 
        //    pool.Add(obj); 
        //}
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }

    public void RemovePooledObject(GameObject index)
    {
        pool.Remove(index);
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

}
