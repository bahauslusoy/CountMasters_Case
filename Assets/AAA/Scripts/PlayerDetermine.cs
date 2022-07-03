using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetermine : MonoBehaviour
{
    private CharController charController;
    private EnemyCount enemyCount;
    public SphereCollider sphereColl;
    private bool isPlayerDetermined = false;
    public bool attack = false;

    void Start()
    {
        charController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>();
        enemyCount = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCount>();
        transform.eulerAngles = new Vector3(0, 180, 0);
    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SubPlayer") && isPlayerDetermined == false)
        {
            isPlayerDetermined = true;
            StartCoroutine(Stop());
            sphereColl.enabled = false;
            attack = true;
        }
    }
    private IEnumerator Stop()
    {
        charController.enabled = false;
        yield return new WaitUntil(() => enemyCount.isEnemyAlive ==false);
        charController.enabled = true;
    }
}
