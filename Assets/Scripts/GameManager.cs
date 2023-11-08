using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject stone;

    public float maxX;

    public Transform spawnPoint;


    [SerializeField] float cooldown;

    [SerializeField] int poolsize = 20;
    [SerializeField] List<GameObject> objectPool =  new List<GameObject>();

    [SerializeField] TriggerScorring trigger;

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] int currentScore;
    [SerializeField] int highScore;


    private void OnEnable()
    {
        trigger.onTriggerScorring += IncreaseCurrentScore;
    }

    private void OnDisable()
    {
        trigger.onTriggerScorring -= IncreaseCurrentScore;
    }

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
        currentScoreText.text = currentScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
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

    void IncreaseCurrentScore()
    {
        currentScore += 10;
        currentScoreText.text = currentScore.ToString();

        if(currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

}
