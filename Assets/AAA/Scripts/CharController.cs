using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharController : MonoBehaviour
{
    enum State
    {
        preGame,

        inGame,

    }
    public GameManager gameManager;
    // Animator camAnim;

    private State _currentState = State.preGame;
    public bool isFinished;

    private float speed;

    [SerializeField] private GameObject mainCharArrivalPoint;
    public Slider slider;
    public GameObject passingPoint;
    [SerializeField] private GameObject StartPanel;
    public GameObject FailPanel;
    private float count = 0;

    Animator CharAnim;
    void Start()
    {
        float distance = Vector3.Distance(transform.position, passingPoint.transform.position);
        slider.maxValue = distance;
        // camAnim.GetComponent<Animator>();
        StartPanel.SetActive(true);
        speed = 0;
        CharAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (_currentState)
        {
            case State.preGame:
                if (Input.GetMouseButtonDown(0))
                {
                    speed = 0;
                    StartPanel.SetActive(false);
                    CharAnim.SetTrigger("Start");
                    _currentState = State.inGame;
                    count ++;
                }

                break;

            case State.inGame:
                if (isFinished)
                {
                    transform.position = Vector3.Lerp(transform.position, mainCharArrivalPoint.transform.position, 0.015f);

                }
                else
                {
                    float distance = Vector3.Distance(transform.position, passingPoint.transform.position);
                    slider.value = distance;

                    if (!isFinished)
                    {
                        speed = 1.5f;
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    }

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
                break;

        }


    }

    private void FixedUpdate()
    {

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
            //camAnim.Play("mainCamera");
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

