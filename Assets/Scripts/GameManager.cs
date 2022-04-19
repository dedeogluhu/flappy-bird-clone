using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject cloudPrefab1;
    public GameObject cloudPrefab2;
    public GameObject cloudPrefab3;
    public GameObject pipePrefab;
    public GameObject gameOverMenu;
    public Text scoreText;

    public float cloudSpawnInterval = 5f;
    public float pipeSpawnInterval = 5f;

    private List<GameObject> cloudPrefabs;
    private System.Random randomNumber;
    private int _score = 0;

    void Start()
    {
        Time.timeScale = 1;

        scoreText.text = _score.ToString();

        randomNumber = new System.Random();
        cloudPrefabs = new List<GameObject> { cloudPrefab1, cloudPrefab2, cloudPrefab3 };

        StartCoroutine(SpawnClouds(cloudSpawnInterval));
        StartCoroutine(SpawnPipes(pipeSpawnInterval));
    }

    IEnumerator SpawnClouds(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(cloudPrefabs[randomNumber.Next(0, 3)], new Vector3(6, 2.5f, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnPipes(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(pipePrefab, new Vector3(6, (float)randomNumber.NextDouble() + 1.5f, 0), Quaternion.identity);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0.3f;
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void UpdateScore(int score)
    {
        _score += score;
        scoreText.text = _score.ToString();
    }
}
