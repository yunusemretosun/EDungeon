using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform PointA, PointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isHit = false;
    protected bool isDead = false;
    protected PlayerManager player;



    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        
    }
    public void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat")==false)
        {
            return;
        }
        Movement();
    }
    public virtual void Movement()
    {

        
        Direction();

        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        float diffA = Vector3.Distance(PointA.position, player.transform.position);
        float diffB = Vector3.Distance(PointB.position, player.transform.position);
        if (distance < 3.0f && diffA !=0f && diffB!=0f)
        {
            anim.SetBool("InCombat", true);
            currentTarget = transform.position;
        }
        else
        {
            anim.SetBool("InCombat", false);
            Position();
        }





        if (anim.GetBool("InCombat") == false )
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
           
        }
        else
        {
            anim.SetTrigger("Idle");
        }


    }

   public virtual void Position()
    {

        if (transform.position == PointA.position && transform.position != PointB.position )
        {
            currentTarget = PointB.position;
            anim.SetTrigger("Idle");

            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position == PointB.position)
        {
            currentTarget = PointA.position;
            anim.SetTrigger("Idle");
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
    }

    public virtual void Direction()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }







}
