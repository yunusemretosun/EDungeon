using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiantScript :Enemy,IDamageable
{
    public int Health {get;set;}
    [SerializeField]
    private GameObject diamondPrefab;

    
    public override void Init()
    {
        base.Init();
        this.Health = health;
    
    }

    public override void Movement()
    {
        base.Movement();

    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        anim.SetTrigger("Hit");
     
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

