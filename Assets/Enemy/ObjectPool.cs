using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyRam;
    [SerializeField] [Range(0, 50f)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float instantiateTime = 1f;

    GameObject[] pool;
    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(InstatniateEnemies());
    }
    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        
        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyRam, transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

   IEnumerator InstatniateEnemies()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(instantiateTime);
        }
    }
}
