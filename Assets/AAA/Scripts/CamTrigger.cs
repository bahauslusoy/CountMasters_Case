using System.Collections;
using System.Collections.Generic;
using Ambrosia.EventBus;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SubPlayer"))
        {
            EventBus<EventCamControl>.Emit(this, new EventCamControl());
            Debug.Log("SSS");


        }
    }
}
