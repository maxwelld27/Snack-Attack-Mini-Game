using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerM : MonoBehaviour
{
     private float spawnRangeX = 4.5f;
    private float spawnPosZ = 4.5f;
    public GameObject[] CollectiblePrefabs;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCollectible", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomCollectible()
    {
        int collectibleIndex = Random.Range(0, CollectiblePrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),10, Random.Range(-spawnRangeX, spawnRangeX));
            Instantiate(CollectiblePrefabs[collectibleIndex], spawnPos, CollectiblePrefabs[collectibleIndex].transform.rotation);
    }
}
