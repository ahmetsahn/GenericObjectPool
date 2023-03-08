using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolWithGenerics<T> : MonoBehaviour where T : Component
{
    public static ObjectPoolWithGenerics<T> Instance { get; private set; }

    [SerializeField]
    private T prefab;

    private Queue<T> objectPool = new Queue<T>();


    private void Awake()
    {
        Instance = this;
    }

    public T GetObject()
    {
        if (objectPool.Count == 0)
        {
            AddObject();
        }

        return objectPool.Dequeue();
    }

    private void AddObject()
    {
        var newObject = Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objectPool.Enqueue(newObject);
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objectPool.Enqueue(objectToReturn);
    }
}
