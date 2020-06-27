using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimationController : MonoBehaviour
{
    public Animator leverAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Right()
    {
        leverAnimator.GetCurrentAnimatorStateInfo(0).IsName("Right");
        leverAnimator.SetTrigger("Right");
    }
    public void Left()
    {
        leverAnimator.GetCurrentAnimatorStateInfo(0).IsName("Left");
        leverAnimator.SetTrigger("Left");
    }
    public void Upper()
    {
        leverAnimator.GetCurrentAnimatorStateInfo(0).IsName("Upper");
        leverAnimator.SetTrigger("Upper");
    }
    public void Down()
    {
        leverAnimator.GetCurrentAnimatorStateInfo(0).IsName("Down");
        leverAnimator.SetTrigger("Down");
    }
    public void animReset()
    {
        leverAnimator.SetTrigger("Reset");
    }
}
