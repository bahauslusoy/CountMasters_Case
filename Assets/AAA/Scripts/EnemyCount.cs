using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public GameObject enemy;

    public List<GameObject> enemies = new List<GameObject>();

    public bool isEnemyAlive = true;

    void Start()
    {
        SpawnEnemy();
    }

    
    void Update()
    {
        if(enemies.Count == 0)
        {
            isEnemyAlive = false;
        }

    }

    public void SpawnEnemy()
    {
        for(int i = 0; i <10 ; i++)
        {
            GameObject newEnemy = Instantiate(enemy,EnemyPosition(),Quaternion.identity, transform);
            enemies.Add(newEnemy);
        }
    }
    public Vector3 EnemyPosition()
    {
        Vector3 pos = Random.insideUnitSphere * 0.5f ;
        Vector3 newPos = transform.position + pos;
        newPos.y = 0.0f;
        
        return newPos;
    }
}
