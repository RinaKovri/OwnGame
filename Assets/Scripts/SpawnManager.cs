using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    private GameManager gameManager;
    public GameObject player;

    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
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
        Vector3 spawnPos = new Vector3(Random.Range(1f, -1f), Random.Range(1.5f, 3f), Random.Range(player.transform.position.z - 5, zPos));//objects appear only within the boundaries of the road
        int index = Random.Range(0, pickupPrefabs.Length);

        if (gameManager.isGameActive)
        {
            Instantiate(pickupPrefabs[index], spawnPos, pickupPrefabs[index].transform.rotation);
        }
    }
}
