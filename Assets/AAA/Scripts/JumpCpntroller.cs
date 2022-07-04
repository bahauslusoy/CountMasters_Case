using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCpntroller : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SubPlayer"))  
        {
            //other.GetComponent<SubCharacterController>().Jump();

            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 30f, ForceMode.Impulse);
        }  
    }
}
