using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCount : MonoBehaviour
{
    public GameObject enemy;

    public List<GameObject> enemies = new List<GameObject>();

    public bool isEnemyAlive = true;
    public TextMeshProUGUI enemyCountText;

    void Start()
    {
        SpawnEnemy();
        //CreateEnemiesAroundPoint();
    }


    void Update()
    {
        enemyCountText.text = enemies.Count.ToString();

        if (enemies.Count == 0)
        {
            isEnemyAlive = false;
        }

    }

    public void SpawnEnemy()
    {

        for (int i = 0; i < 20; i++)
        {
            GameObject newEnemy = Instantiate(enemy, EnemyPosition(), Quaternion.identity,transform);
            enemies.Add(newEnemy);
        }
    }
    public Vector3 EnemyPosition()
    {
        Vector3 pos = Random.insideUnitSphere * 0.5f;
        Vector3 newPos = transform.position + pos;
        newPos.y = 0.0f;

        return newPos;
    }
    

    /*public void CreateEnemiesAroundPoint()
    {
    float radius = 1f;
    Vector3 pos = Random.insideUnitSphere * 0.5f;
    Vector3 newPos = transform.position + pos;
    float num = 10;
    for (int i = 0; i < num; i++)
    {

        // Distance around the circle 
        var radians = 2 * Mathf.PI / num * i;

        // Get the vector direction 
        var vertical = Mathf.Sin(radians);
        var horizontal = Mathf.Cos(radians);

        var spawnDir = new Vector3(horizontal, 0, vertical);

        // Get the spawn position 
        var spawnPos = newPos + spawnDir * radius; // Radius is just the distance away from the point

        // Now spawn 
        GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity) as GameObject;




    }
}*/
}
