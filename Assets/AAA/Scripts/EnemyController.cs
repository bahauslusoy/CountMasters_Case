using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Ambrosia.EventBus;

public class EnemyController : MonoBehaviour
{
    public GameObject attackTarget;
    NavMeshAgent NavMesh;
    bool isAttacked;
    void Start()
    {
        NavMesh = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {

    }
    public void EnemyAttackAnim()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        isAttacked = true;
    }

    void LateUpdate() 
    {
        if(isAttacked)
        {
            NavMesh.SetDestination(attackTarget.transform.position);
        }
    }

    

    private void OnTriggerEnter(Collider other) 
    {
         if (other.gameObject.CompareTag("Player"))
        {
            
            EventBus<EventCamControl>.Emit(this, new EventCamControl());
            //GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StainEffect(gameObject.transform,true);
            gameObject.SetActive(false);
        }
    }
}
