using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawning", 5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawning()
    {
        int i = Random.Range(0, 12);
        Instantiate(Enemy, spawnPoints[i].position, transform.rotation);
    }

}
