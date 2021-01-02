using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : Enemy,IDamageable
{
    
    public int Health { get; set; }
    [SerializeField]
    private GameObject diamondPrefab;

    public override void Init()
    {
        base.Init();
        Health = health;
    }
    //public override void Movement()
   // {
      //  base.Movement();

    //}
    public void Damage()
    {
        anim.SetTrigger("Hit");
        if (isDead == true)
        {
            return;
        }
        this.Health--;
        if (this.Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Destroy(this.gameObject, 2f);
            GameObject diamond = Instantiate(diamondPrefab, this.transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }

  
}
