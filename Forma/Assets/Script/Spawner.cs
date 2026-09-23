using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float waiter = 2f;
    void Start()
    {
        StartCoroutine(SpawnerTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnerTime()
    {
        yield return new WaitForSeconds(waiter);
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}
