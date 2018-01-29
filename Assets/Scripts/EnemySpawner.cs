using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public int startEnemies = 20;
    public int currentWaveSize = 5;
    public float timeBetweenWaves = 5.0f;
    public Transform[] spawnpoints;
    public GameObject[] enemyPrefab;

    private int spawnIndex;
    private int currentEnemies = 0;
    private float nextSpawnTime = 0.0f;
   // private GameObject enemy;
    private Vector3 spawnPosition;
    private List<int> validIndices;
    private int lastRemoved = -1;

    //private ParticleSystem lampPs;


    

    // Use this for initialization
    void Start () {
        //nextSpawnTime = Time.time + timeBetweenWaves;
        validIndices = new List<int>();
        for (int i = 0; i < spawnpoints.Length; i++) {
            validIndices.Add(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawnTime && currentEnemies < startEnemies && gameObject.CompareTag("Tower")) {
            if (!gameObject.GetComponentInChildren<ParticleSystem>().IsAlive()) {
                gameObject.GetComponentInChildren<ParticleSystem>().Play();
            }
            nextSpawnTime = Time.time + timeBetweenWaves;
            StartCoroutine(SpawnWave());
        }

        if (GameManagerSingleton.Instance.enemiesKilled == startEnemies && gameObject.CompareTag("Tower")) {
            GameManagerSingleton.Instance.enemiesKilled = 0;
            for (int i = 0; i < GameManagerSingleton.Instance.towers.Length; i++) {
                if (GameManagerSingleton.Instance.towers[i].CompareTag("Tower")) {
                    List<GameObject> goList = new List<GameObject>(GameManagerSingleton.Instance.towers);
                    goList.Remove(GameManagerSingleton.Instance.towers[i]);
                    GameManagerSingleton.Instance.towers = goList.ToArray();
                }
            }
            gameObject.tag = "Untagged";
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            if (GameManagerSingleton.Instance.towers.Length > 0) {
                GameManagerSingleton.Instance.towers[0].tag = "Tower";
                TweenTrail();
                GameManagerSingleton.Instance.towers[0].GetComponentInChildren<ParticleSystem>().Play();
            }
        }
	}



    void TweenTrail () {
        string path = "";
        if (GameManagerSingleton.Instance.towers.Length == 1) {
            path = "New Path 1";
        }
        if (GameManagerSingleton.Instance.towers.Length == 2) {
            path = "PathLamptoLamp1";
        }
        GameObject t = GameObject.FindGameObjectWithTag("Trail");
        
        iTween.MoveTo(t, iTween.Hash("path", iTweenPath.GetPath(path), "easeType", iTween.EaseType.easeInOutSine, "time", 5));
        //GameManagerSingleton.Instance.towers[0].GetComponentsInParent<AudioSource>()[1].Play();
        gameObject.GetComponentsInParent<AudioSource>()[1].Play();
    }


    IEnumerator SpawnWave () {
        currentEnemies += currentWaveSize;
        for (int i = 0; i < currentWaveSize; i++) {
            
            spawnIndex = validIndices[Random.Range(0, validIndices.Count)];
            spawnPosition = new Vector3(spawnpoints[spawnIndex].position.x, spawnpoints[spawnIndex].position.y, spawnpoints[spawnIndex].position.z);
            Instantiate(enemyPrefab[(Random.Range(0.0f, 1f) <= 0.5 ? 0 : 1)], spawnPosition, spawnpoints[spawnIndex].rotation);
            RemoveValidIndices(spawnIndex);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void RemoveValidIndices (int r) {
        validIndices.Remove(r);
        if (lastRemoved != -1) {
            validIndices.Add(lastRemoved);
        }
        lastRemoved = r;
    }

    
}
