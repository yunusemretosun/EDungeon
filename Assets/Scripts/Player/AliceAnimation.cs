using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceAnimation : MonoBehaviour
{
    private Animator animator;
    private Animator swordarc;
    void Start()
    {
        animator =  GetComponentInChildren<Animator>();
        swordarc = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        animator.SetFloat("Move",Mathf.Abs(move));
    }
    public void RangeAttack()
    {
        animator.SetTrigger("RangeAttack");
        swordarc.SetTrigger("SwordArc");
    }
    public void MeleeAttack()
    {
        animator.SetTrigger("MeleeAttack");
    }
    public void Jumping(bool jumping)
    {
        animator.SetBool("Jumping", jumping);
    }
    public void Dashing(bool dashing)
    {
        animator.SetBool("Dashing", dashing);
    }
    public void Death()
    {
        animator.SetTrigger("Death");
    }

}
