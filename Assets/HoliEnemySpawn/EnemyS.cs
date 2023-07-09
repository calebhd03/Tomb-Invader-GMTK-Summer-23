using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    [SerializeField]
    private WaveSpawnerScriptableObject spawnAmount;

    public float SpawnNumber = 0;
    public List<GameObject> enemys;
    public GameObject tombScarabs;
    public GameObject sapperAsp;
    public GameObject hauntedJar;
    public GameObject boneWarrior;
    public GameObject sphinxGolem;

    public Transform P;


    void Start()
    {
        SpawnNumber = spawnAmount.tombScarabs;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        for(int i = 0; i < spawnAmount.tombScarabs; i++)
        {
            enemys.Add(tombScarabs);
        }
        for (int i = 0; i < spawnAmount.sapperAsp; i++)
        {
            enemys.Add(sapperAsp);
        }
        for (int i = 0; i < spawnAmount.hauntedJar; i++)
        {
            enemys.Add(hauntedJar);
        }
        for (int i = 0; i < spawnAmount.boneWarrior; i++)
        {
            enemys.Add(boneWarrior);
        }
        for (int i = 0; i < spawnAmount.sphinxGolem; i++)
        {
            enemys.Add(sphinxGolem);
        }

        while (enemys.Count > 0)
        {
            int randomIndex = Random.Range(0, enemys.Count);
            Vector3 randonSpawnPosition = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), 0);
            GameObject e = Instantiate(enemys[randomIndex], randonSpawnPosition, Quaternion.identity);
            e.GetComponent<Enemy>().player = P;
            enemys.RemoveAt(randomIndex);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
