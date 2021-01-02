using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IDamageable
{
    
    private Rigidbody2D rgbdy;
    //jump
    [SerializeField]
    private float jumpForce = 7f;
    private bool resetJump = false;

    [SerializeField]
    protected int health;

    [SerializeField]
    private float moveSpeed = 5f;

    public float dashSpeed; 
    public float startDashTime;
    private float dashTime;
    [SerializeField]
    private bool resetDash = false;

    private bool isDead = false;

    private bool grounded = false;

    private AliceAnimation aliAnim;
    private SpriteRenderer playerSprite;
    private SpriteRenderer swordArcSprite;

    public int Health { get; set; }

    public int diamonds;
    //public GameObject dashEffect;

    void Start()
    {
        Health = health;
        rgbdy = GetComponent<Rigidbody2D>();
        aliAnim = GetComponent<AliceAnimation>();
        playerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        dashTime = startDashTime;
        
    }

  
    void Update()
    {
        Movement();
        Attack();

        if (Input.GetKeyDown(KeyCode.LeftShift) && !resetDash)
        {
            GoDash();

        }
    }

    void GoDash()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            rgbdy.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;
            if (direction > 0)
            {
                rgbdy.velocity = Vector2.right * dashSpeed;
               // Instantiate(dashEffect, transform.position, Quaternion.identity);
            }     
            else if (direction < 0)
            {
                rgbdy.velocity = Vector2.left * dashSpeed;
              //  Instantiate(dashEffect, transform.position, Quaternion.identity);

            }
                
        }
        StartCoroutine(ResetDashRoutine());
    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        grounded = IsGrounded();//surekli olarak kontrol etmemize yariyacak ,constantly casting that recast
        //tersini dusun.
        if (moveX > 0)
        {
            Flip(false) ;
        }
        else if (moveX < 0)
        {
            Flip(true) ;
        }

        

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
            aliAnim.Jumping(true);
           
        }
       



        rgbdy.velocity = new Vector2(moveX * moveSpeed, rgbdy.velocity.y);
        GetComponent<AliceAnimation>().Move(moveX);

    }
  
   
    
    void Flip(bool faceRight)
    {
        if(faceRight == false) { 
            playerSprite.transform.localScale = new Vector3(1, 1, 1);
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;
           

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = 1f;
            swordArcSprite.transform.localPosition = newPos;
           
        }
        else if(faceRight==true) {
            playerSprite.transform.localScale = new Vector3(-1, 1, 1);
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = true;
            

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = -1f;
            swordArcSprite.transform.localPosition = newPos;
            
        }


    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsGrounded())
        {
            aliAnim.MeleeAttack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && IsGrounded())
        {

            aliAnim.RangeAttack();
        }
    }
    void Jump()
    {
        rgbdy.velocity = new Vector2(rgbdy.velocity.x, jumpForce);
        StartCoroutine(ResetJumpRoutine());
    }
    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                aliAnim.Jumping(false);
                return true;

            }
            
                
        }   
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(1f); 
        resetJump = false;
    }
    IEnumerator ResetDashRoutine()
    {
        resetDash = true;
        yield return new WaitForSeconds(1f);
        resetDash = false;
        
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
            aliAnim.Death();
            isDead = true;
            Destroy(this.gameObject, 2f);
        }
    }
}
