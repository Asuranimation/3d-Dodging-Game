using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject stone;

    public float maxX;

    public Transform spawnPoint;

    [SerializeField] float cooldown;


    void Start()
    {
            StartCoroutine(SpawnStoneCourotine());
    }


    void Update()
    {
        
    }

    IEnumerator SpawnStoneCourotine()
    {

        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(stone, spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(cooldown);

        StartCoroutine(SpawnStoneCourotine());

        if(cooldown > 0.2f)
        {
            cooldown -= 0.01f;
        }

    }
}
