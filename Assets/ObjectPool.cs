using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    List<PooledObjectsClass> pooledObjectsClassList;
    public GameObject [] objectsToPool;
    public int amountToPool;


    private void Awake()
    {
        sharedInstance = this;
        OnAwake();
    }

    private void OnAwake()
    {
        pooledObjectsClassList = new List<PooledObjectsClass>();

        for (int i = 0; i < objectsToPool.Length; i++)
        {
            pooledObjectsClassList.Add(new PooledObjectsClass());
            pooledObjectsClassList[i].pooledObj = new List<GameObject>();
            GameObject temp;

            for (int j = 0; j < amountToPool; j++)
            {
                temp = Instantiate(objectsToPool[i]);
                temp.SetActive(false);
                pooledObjectsClassList[i].pooledObj.Add(temp);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        int random = Random.Range(0, objectsToPool.Length);
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjectsClassList[random].pooledObj[i].activeInHierarchy)
            {
                return pooledObjectsClassList[random].pooledObj[i];
            }
        }

        return null;
    }

    public class PooledObjectsClass
    {
        public List<GameObject> pooledObj;
    }
}
