using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;

public class FinishLine : MonoBehaviour
{
    
   


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("SubPlayer"))
        {
           EventBus<EventFinish>.Emit(this,new EventFinish());
        }
    }
}
