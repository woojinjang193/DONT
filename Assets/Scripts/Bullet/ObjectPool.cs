
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<PooledObject> pool = new List<PooledObject>();
    [SerializeField] PooledObject prefab;
    [SerializeField] int size;

    private void Awake()
    {
        for (int i = 0; i < size; i++)
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            pool.Add(instance);
        }
    }

    public PooledObject GetPool(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            return Instantiate(prefab, position, rotation);
        }
        PooledObject instance = pool[pool.Count - 1];
        pool.RemoveAt(pool.Count - 1);

        instance.returnPool = this;
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        instance.gameObject.SetActive(true);

        return instance;
    }

    public void ReturnPool(PooledObject instance)
    {
        instance.gameObject.SetActive(false);
        pool.Add(instance);
    }

}
