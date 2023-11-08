using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject stone;

    public float maxX;

    public Transform spawnPoint;


    [SerializeField] float cooldown;

    [SerializeField] int poolsize = 20;
    [SerializeField] List<GameObject> objectPool =  new List<GameObject>();


    private void Awake()
    {
        for (int i = 0; i < poolsize; i++)
        {
            GameObject stonePrefabs = Instantiate(stone,transform.position,Quaternion.identity);
            stonePrefabs.SetActive(false);
            objectPool.Add(stonePrefabs);
        }
    }

    void Start()
    {
            StartCoroutine(SpawnStoneCourotine());
    }

    IEnumerator SpawnStoneCourotine()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);

        GameObject stonePrefabs = GetObjectPool();
        stonePrefabs.transform.position = spawnPos;
        stonePrefabs.SetActive(true);

        yield return new WaitForSeconds(cooldown);

        StartCoroutine(SpawnStoneCourotine());

        if(cooldown > 0.2f)
        {
            cooldown -= 0.01f;
        }
    }
     
    GameObject GetObjectPool()
    {
        for(int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy) 
            {
                return objectPool[i];
            }
        }
        return null;
    }
}
