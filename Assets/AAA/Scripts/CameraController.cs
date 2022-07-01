using System;
using System.Collections;
using System.Collections.Generic;
using Ambrosia.EventBus;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    private Animator camAnimator;
   //public GameObject target;
    //public Vector3 offset;
    void Start()
    {
        camAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventBus<EventCamControl>.AddListener(CameraChange);
    }
    private void OnDisable()
    {
        EventBus<EventCamControl>.RemoveListener(CameraChange);
    }

    private void CameraChange(object sender, EventCamControl @event)
    {
        camAnimator.Play("finishCam");
        Debug.Log("cam");
    }

    void LateUpdate()
    {
       // this.transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime);
    }
}
