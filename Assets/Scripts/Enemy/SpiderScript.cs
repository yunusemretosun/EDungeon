using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : Enemy,IDamageable
{

    public GameObject acid;
    [SerializeField]
    private GameObject diamondPrefab;
    public int Health { get; set; }


    public override void Init()
    {
        base.Init();
        this.Health = health;
    }

    public override void Movement()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        if (direction.x > 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x < 0 )
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        this.Health--;
        if (this.Health < 1)
        {
            anim.SetBool("Death", true);
            Destroy(this.gameObject, 2f);
            GameObject diamond = Instantiate(diamondPrefab, this.transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            isDead = true;
        }
    }
    public void Attack()
    {
        Instantiate(acid, this.transform.position, this.transform.rotation);
    }
}


