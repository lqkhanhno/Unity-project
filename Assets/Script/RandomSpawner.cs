using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefab;
    public float spawnRate;
    public float nextSpawn = Random.Range(1, 30);
    int whatToSpawn;
    GameObject spawnedPrefab;

    void Update()
    {
        if (Time.time > nextSpawn && spawnedPrefab == null)
        {
            whatToSpawn = Random.Range(1, 3);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(itemPrefab[0], transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(itemPrefab[1], transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(itemPrefab[2], transform.position, Quaternion.identity);
                    break; ;
            }
            spawnRate = Random.Range(30, 60);
            nextSpawn = Time.time + spawnRate;
        }
    }

}
