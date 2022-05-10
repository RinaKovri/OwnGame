using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    private GameManager gameManager;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    public GameObject player;
    public float zPos;
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void SpawnObjects()
    {
        Vector3 spawnPos = new Vector3(Random.Range(1.3f, -1.3f), 2, Random.Range(zPos, player.transform.position.z));
        int index = Random.Range(0, pickupPrefabs.Length);

        if (gameManager.isGameActive)
        {
            Instantiate(pickupPrefabs[index], spawnPos, pickupPrefabs[index].transform.rotation);
        }

    }
}
