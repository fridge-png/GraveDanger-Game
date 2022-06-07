using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public int poolId;
        public GameObject prefab;
        public int size;

    }

    [Tooltip("Each element represents an object pool.")]
    [SerializeField] public Pool[] pools;
    Dictionary<int, Queue<GameObject>> poolDict;

    public static ObjectPooler instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;

        }

    }

    void Start()
    {

        poolDict = new Dictionary<int, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {

            Queue<GameObject> objects = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {

                GameObject newobj = Instantiate(pool.prefab);
                newobj.SetActive(false);
                objects.Enqueue(newobj);
            }

            poolDict.Add(pool.poolId, objects);

        }

    }

    public GameObject spawnFromPool(int poolId, Vector3 pos, Quaternion rot)
    {

        if (poolDict[poolId].Count != 0)
        {
            GameObject obj = poolDict[poolId].Dequeue();

            obj.SetActive(true);
            PoolerInterface onspawnscript = obj.GetComponentInChildren<PoolerInterface>();

            if (onspawnscript != null)
            {
                onspawnscript.onSpawn();
            }

            if (poolId == 1)
            {
                obj.GetComponentInChildren<UnityEngine.AI.NavMeshAgent>().Warp(pos);
                obj.transform.rotation = rot;
            }
            else
            {
                obj.transform.position = pos;
                obj.transform.rotation = rot;
            }

            return obj;

        }
        return null;

    }

    public void backToPool(int poolId, GameObject obj)
    {
        obj.SetActive(false);
        poolDict[poolId].Enqueue(obj);

    }



}
