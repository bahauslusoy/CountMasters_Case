using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubCharacterController : MonoBehaviour
{
    private PlayerCount playerCount;
    private CharController charController;

    private Transform center;
    private Rigidbody rb;

    public Image dangerImage;

    //private bool isFinished;
    public Animator CharAnim;
    void Start()
    {
        dangerImage.enabled = false;
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
            StartCoroutine(DangerActive());

        }

        else if (other.gameObject.CompareTag("Saw"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().DestroyEffect(gameObject.transform);
            playerCount.CharDead();
            gameObject.SetActive(false);
            playerCount.characterList.Remove(gameObject);
        }
        else if (other.gameObject.CompareTag("Hammer"))
        {
            playerCount.CharDead();
            gameObject.SetActive(false);
            playerCount.characterList.Remove(gameObject);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StainEffect(gameObject.transform, true);

        }
    }
    public IEnumerator DangerActive()
    {
        dangerImage.enabled = true;
        yield return new WaitForSeconds(0.1f);
        dangerImage.enabled = false ;
    }
}