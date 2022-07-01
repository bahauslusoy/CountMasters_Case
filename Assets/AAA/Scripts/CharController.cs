using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharController : MonoBehaviour
{
    public GameManager gameManager;


    public bool isFinished;

    [SerializeField] private GameObject mainCharArrivalPoint;
    public Slider slider;
    public GameObject passingPoint;
    void Start()
    {
        float distance = Vector3.Distance(transform.position, passingPoint.transform.position);
        slider.maxValue = distance;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (isFinished)
        {
            transform.position = Vector3.Lerp(transform.position, mainCharArrivalPoint.transform.position, 0.015f);
        }
        else
        {
            float distance = Vector3.Distance(transform.position, passingPoint.transform.position);
            slider.value= distance;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z), 0.3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), 0.3f);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isFinished)
        {
            transform.Translate(Vector3.forward * 1.5f * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Multiply") || other.CompareTag("Addition"))
        {
            int nmbr = int.Parse(other.name);
            gameManager.playerManagement(other.tag, nmbr, other.transform);

        }
        else if (other.gameObject.CompareTag("EnemyTrigg"))
        {
            gameManager.EnemyTrigger();
            isFinished = true;
        }
    }
    private void OnCollisionEnter(Collision col)  // for pole movement system
    {
        if (col.gameObject.CompareTag("Pole"))
        {

            //Debug.Log("Girdin mi");
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
    }
}

