using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;

public class FinisCamTrigg : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SubPlayer"))
        {
            EventBus<EventFinishCam>.Emit(this, new EventFinishCam());
            


        }
    }
}
