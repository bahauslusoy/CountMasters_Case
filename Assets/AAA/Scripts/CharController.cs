using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ambrosia.EventBus;
using System;

public class CharController : MonoBehaviour
{
    enum State
    {
        preGame,

        inGame,

        finishGame,

        failGame,

    }
    public GameManager gameManager;
    // Animator camAnim;

    private State _currentState = State.preGame;
    //public bool isFinished;

    private float speed;

    private float HorSpeed;

    // [SerializeField] private GameObject charArrivalPoint;
    public Slider slider;
    public GameObject passingPoint;
    [SerializeField] private GameObject StartPanel;

    public GameObject SuccessPanel;
    private float count = 0;

    private PlayerCount playerCount;

    Vector3 FirstPos, endPos;

    private AnimatorControl animatorControl;
    private SubCharacterController subCharacterController;

    private void OnEnable()
    {
        EventBus<EventFinish>.AddListener(FinishGame);
    }
    private void OnDisable()
    {
        EventBus<EventFinish>.RemoveListener(FinishGame);
    }

    private void FinishGame(object sender, EventFinish @event)
    {

        _currentState = State.finishGame;

    }

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCount>();
        float distance = Vector3.Distance(transform.position, passingPoint.transform.position);
        slider.maxValue = distance;
        //camAnim.GetComponent<Animator>();
        StartPanel.SetActive(true);
        speed = 0;
        // subCharControl.CharAnim = GetComponent<Animator>();
        Time.timeScale = 0;

    }

    void Update()
    {
        switch (_currentState)
        {
            case State.preGame:
                if (Input.GetMouseButtonDown(0))
                {
                    Time.timeScale = 1;
                    speed = 0;
                    HorSpeed = 0;
                    StartPanel.SetActive(false);
                    // subCharControl.CharAnim.SetTrigger("Start");
                    _currentState = State.inGame;
                    count++;
                    //animatorControl.charAnim.SetTrigger("Start");
                }

                break;

            case State.inGame:

                /*if (isFinished)
                {
                    transform.position = Vector3.Lerp(transform.position, charArrivalPoint.transform.position, 0.015f);

                }*/
                //else
                // {
                float distance = Vector3.Distance(transform.position, passingPoint.transform.position);
                slider.value = distance;

                //if (!isFinished)
                // {
                speed = 1.5f;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                // }

                /*if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (Input.GetAxis("Mouse X") < 0)
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z), 0.3f);
                    }
                    if (Input.GetAxis("Mouse X") > 0)
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z), 0.3f);
                    }
                }*/
                if (Input.GetMouseButtonDown(0))
                {
                    FirstPos = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                {
                    endPos = Input.mousePosition;

                    float differenceX = endPos.x - FirstPos.x;

                    HorSpeed = 0.01f;

                    transform.Translate(differenceX * HorSpeed * Time.deltaTime, 0, 0);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    FirstPos = Vector3.zero;
                    endPos = Vector3.zero;
                }

                float Xposition = Mathf.Clamp(transform.position.x, -1.2f, 1.2f);
                transform.position = new Vector3(Xposition, transform.position.y, transform.position.z);
                //}
                break;

            case State.finishGame:

                //subCharacterController.CharAnim.SetTrigger("Win");
                SuccessPanel.SetActive(true);
                speed = 0;
                HorSpeed = 0;
                Time.timeScale = 0;
                break;

                /*case State.failGame:
                    speed = 0;
                    FailPanel.SetActive(true);

                    break;*/

        }
    }

}