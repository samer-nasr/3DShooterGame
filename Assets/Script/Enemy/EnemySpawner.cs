using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Transform[] positions;


    private GameObject enemy;

    private float enemySpawner = 10f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        StartCoroutine(spawnEnemy(enemySpawner , enemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval , GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Transform pos = positions[Random.Range(0, positions.Length)];
        GameObject newEnemy = Instantiate(enemy , pos.position , Quaternion.identity );
        StartCoroutine(spawnEnemy(interval , enemy));
    }
}
