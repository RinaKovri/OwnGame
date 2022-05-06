using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    private PlayerController playerControllerScript;
    public GameObject player;
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void SpawnObjects()
    {
        Vector3 spawnPos = new Vector3(Random.Range(1.3f, -1.3f), 1, Random.Range(-354f, player.transform.position.z));
        int index = Random.Range(0, pickupPrefabs.Length);

        if (!playerControllerScript.gameOver)
        {
            Instantiate(pickupPrefabs[index], spawnPos, pickupPrefabs[index].transform.rotation);
        }

    }
}
