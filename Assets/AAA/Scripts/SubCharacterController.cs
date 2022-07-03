using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCharacterController : MonoBehaviour
{
    private PlayerCount playerCount;
    private CharController charController;

    private Transform center;
    private Rigidbody rb;

    //private bool isFinished;
    //public Animator CharAnim;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playerCount = GameObject.Find("Player").GetComponent<PlayerCount>();
        charController = transform.parent.GetComponent<CharController>();

        center = playerCount.transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, center.position, Time.fixedDeltaTime * 1f);


    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            playerCount.CharDead();
            gameObject.SetActive(false);
        }

        else if (other.gameObject.CompareTag("Saw"))
        {
            playerCount.CharDead();
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Hammer"))
        {
            playerCount.CharDead();
            gameObject.SetActive(false);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StainEffect(gameObject.transform, true);
        }
    }
}