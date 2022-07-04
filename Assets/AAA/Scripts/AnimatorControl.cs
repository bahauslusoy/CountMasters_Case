using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    public Animator charAnim;
    void Start()
    {
        charAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharAnimControl()
    {
        charAnim.SetTrigger("Start");
    }
}
