using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainControl : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(StainPassive());
    }

   IEnumerator StainPassive()
   {
     yield return new WaitForSeconds(5f);
     gameObject.SetActive(false);
   }
}
