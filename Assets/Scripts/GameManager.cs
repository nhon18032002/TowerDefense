using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        EnemySpawner.instance.Spawn("Bat", Vector3.zero, Quaternion.identity);
        EnemySpawner.instance.Spawn("Goblin", Vector3.zero, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < 30; i++)
        {
            int index = Random.Range(0, 2);
            string name = EnemyManager.instance.listPrefab.getPrefab(index).name;
            EnemySpawner.instance.Spawn(name, Vector3.zero, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
    
