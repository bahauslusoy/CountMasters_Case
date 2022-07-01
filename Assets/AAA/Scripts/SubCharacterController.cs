using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SubCharacterController : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent navmesh;
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ArrivalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.SetDestination(Target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Saw"))
        {

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Hammer"))
        {

            //GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StainEffect(gameObject.transform);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

            //GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StainEffect(gameObject.transform,false);
            gameObject.SetActive(false);
        }
    }

}
