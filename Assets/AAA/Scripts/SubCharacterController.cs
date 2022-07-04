using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class SubCharacterController : MonoBehaviour
{
    private PlayerCount playerCount;
    private CharController charController;
    private Transform center;
    private Rigidbody rb;
    private Animator CharAnim;
    void Start()
    {
        CharAnim = GetComponent<Animator>();
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
            playerCount.characterList.Remove(gameObject);
            CameraShaker.Instance.ShakeOnce(1.5f, 1.5f, .1f, 1f);

        }

        else if (other.gameObject.CompareTag("Saw"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            playerCount.CharDead();
            gameObject.SetActive(false);
            playerCount.characterList.Remove(gameObject);
            CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, 1f);
        }
        else if (other.gameObject.CompareTag("Hammer"))
        {
            playerCount.CharDead();
            gameObject.SetActive(false);
            playerCount.characterList.Remove(gameObject);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StainEffect(gameObject.transform, true);
            CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, 1f);

        }
    }

}