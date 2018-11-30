using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;
    private GameObject[] enemies;

    private void Start() {
        enemies = new GameObject[5];
        for(int i = 0; i < enemies.Length; i++) {
            enemies[i] = null;
        }
    }

    // Update is called once per frame
    void Update () {
		if(enemies[0] == null){
            enemies[0] = Instantiate(enemyPrefab) as GameObject;
            enemies[0].transform.position = new Vector3(0,1.8f,0);
            enemies[0].transform.Rotate(0, Random.Range(0, 360), 0);
        }
        if (enemies[1] == null) {
            enemies[1] = Instantiate(enemyPrefab) as GameObject;
            enemies[1].transform.position = new Vector3(-18.62949f, 1.792465f, 16.5f);
            enemies[1].transform.Rotate(0, Random.Range(0, 360), 0);
        }
        if (enemies[2] == null) {
            enemies[2] = Instantiate(enemyPrefab) as GameObject;
            enemies[2].transform.position = new Vector3(-8.0f, 1.8f, -6.0f);
            enemies[2].transform.Rotate(0, Random.Range(0, 360), 0);
        }
        if (enemies[3] == null) {
            enemies[3] = Instantiate(enemyPrefab) as GameObject;
            enemies[3].transform.position = new Vector3(15.0f, 1.8f, -15.5f);
            enemies[3].transform.Rotate(0, Random.Range(0, 360), 0);
        }
        if (enemies[4] == null) {
            enemies[4] = Instantiate(enemyPrefab) as GameObject;
            enemies[4].transform.position = new Vector3(17.0f, 1.8f, 18.0f);
            enemies[4].transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }
}
