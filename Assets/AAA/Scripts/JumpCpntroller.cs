using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCpntroller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))  
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0,20,0),ForceMode.Impulse);
        }  
    }
}
