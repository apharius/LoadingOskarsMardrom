using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateHandler : MonoBehaviour {
    public int score;
    public GameObject enemy;
    private GameObject[] spawnerList;
    private GameObject player;
    public GameObject banPanel;
    public AudioClip youdied;
    // Use this for initialization
    void Start () {
        spawnerList = GameObject.FindGameObjectsWithTag("Spawner");
        StartCoroutine(SpawnEnemy());
        player = GameObject.FindGameObjectWithTag("Player");
	}

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int spawnIndex = UnityEngine.Random.Range(0, spawnerList.Length);
            Instantiate(enemy, spawnerList[spawnIndex].transform);
            yield return new WaitForSeconds(1);
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void newKill()
    {
        enemy.GetComponent<EnemyBehavior>().speed *= 1.005f;

        if(player.GetComponent<PlayerBehavior>().health < 100)
        {
            player.GetComponent<PlayerBehavior>().health += 1;
        }
        
    }

    internal void GameOver()
    {
        PlayerPrefs.SetInt("LastScore", score);
        GameObject backgroundMusic = GameObject.Find("BackgroundMusic");
        banPanel.SetActive(true);
        AudioSource audioSource = backgroundMusic.GetComponent<AudioSource>();
        audioSource.mute = true;
        audioSource.loop = false;
        audioSource.clip = youdied;
        audioSource.mute = false;

        StartCoroutine(WaitAndLoad(audioSource));


    }

    private IEnumerator WaitAndLoad(AudioSource audioSource)
    {
        audioSource.Play();

        yield return new WaitWhile(predicate: () => audioSource.isPlaying);

        SceneManager.LoadScene("Gameover",LoadSceneMode.Single);
    }
}
