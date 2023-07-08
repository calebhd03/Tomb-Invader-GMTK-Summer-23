using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    [SerializeField]
    private EnemyCS spawnAmount;

    public float SpawnNumber = 0;
    public GameObject[] enemys;


    void Start()
    {
        SpawnNumber = spawnAmount.Value;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        while(SpawnNumber >= 1)
        {
            int randomIndex = Random.Range(0, enemys.Length);
            Vector3 randonSpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));

            Instantiate(enemys[randomIndex], randonSpawnPosition, Quaternion.identity);
            SpawnNumber = SpawnNumber -= 1;
            yield return new WaitForSeconds(2.0f);
        }
    }
}
