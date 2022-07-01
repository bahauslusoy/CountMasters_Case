using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    void Start()
    {

    }


    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime);
    }
}
