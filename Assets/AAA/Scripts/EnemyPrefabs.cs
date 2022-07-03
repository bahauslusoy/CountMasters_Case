using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabs : MonoBehaviour
{
    private PlayerDetermine playerDetermine;
    private EnemyCount enemyCount;
    private PlayerCount playerCount;
    private Transform player;

    private bool kill = false;

    void Start()
    {
        playerDetermine = FindObjectOfType<PlayerDetermine>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyCount = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCount>();
        playerCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCount>();
    }

    void Update()
    {
        if (playerDetermine.attack)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.fixedDeltaTime * 2.7f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SubPlayer") && !kill)
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StainEffect(gameObject.transform, true);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().EnemyStainEffect(gameObject.transform, true);
            playerCount.characterList.Remove(other.gameObject);
            playerCount.CharDead();
            Destroy(other.gameObject);

            enemyCount.enemies.Remove(gameObject);
            Destroy(gameObject);
            kill = true;
        }
    }
}
