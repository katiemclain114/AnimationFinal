using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed;
    public float accel;
    public float runSpeed;
    public float attackSpeed;
    private Vector2 currentSpeed;

    //This is the direction the player is facing.
    //0 is up, 1 is right, 2 is down, 3 is left.
    private int facing = 0;

    private bool run;
    private bool attacking;
    private bool moving;

    private Rigidbody2D body;
    private Animator anim;

    public GameObject hitBox;

    private Vector3 attackPos;
    
    

    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        moving = false;
        if (!attacking)
        {
            CheckMoveCtrls();
            anim.SetInteger("facingParam", facing);
        }
        body.MovePosition(body.position + (currentSpeed * Time.fixedDeltaTime));
        
        switch (facing)
        {
            case 0:
                attackPos = transform.position + Vector3.up;
                break;
            case 1:
                attackPos = transform.position + Vector3.right;
                break;
            case 2:
                attackPos = transform.position + Vector3.down;
                break;
            case 3:
                attackPos = transform.position + Vector3.left;
                break;
        }
    }
    
    void Attack()
    {

        //Instantiate(hitBox, attackPos, Quaternion.identity);
        hitBox.SetActive(true);
        hitBox.transform.position = attackPos;
        //hitBox.GetComponent<Animator>().Play("shrinkHitBoxAnim", -1, 0);
        //hitBox.GetComponent<HitBox>().EnableCollider();
        attacking = true;
        anim.SetBool("Attacking", true);

        switch (facing)
        {
           case 0:
               currentSpeed = new Vector2(0, attackSpeed);
               break;
           case 1:
               currentSpeed = new Vector2(attackSpeed, 0);
               break;
           case 2:
               currentSpeed = new Vector2(0, -attackSpeed);
               break;
           case 3:
               currentSpeed = new Vector2(-attackSpeed, 0);
               break;
        }

    }

    public void StopAttacking()
    {
        hitBox.SetActive(false);
        //hitBox.GetComponent<HitBox>().DisableCollider();
        attacking = false;
        anim.SetBool("Attacking", false);
    }
    

    void CheckMoveCtrls()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            facing = 0;
            moving = true;

            if (run)
            {
                currentSpeed.y = Mathf.Min(currentSpeed.y + (accel * Time.deltaTime), runSpeed);
            }
            else
            {
                currentSpeed.y = Mathf.Min(currentSpeed.y + (accel * Time.deltaTime), walkSpeed);
            }

        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            facing = 2;
            moving = true;
            
            if (run)
            {
                currentSpeed.y = Mathf.Max(currentSpeed.y - (accel * Time.deltaTime), -runSpeed);
            }
            else
            {
                currentSpeed.y = Mathf.Max(currentSpeed.y - (accel * Time.deltaTime), -walkSpeed);
            } 
        }
        else
        {
            currentSpeed.y = Mathf.Lerp(currentSpeed.y, 0, .2f);
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            facing = 1;
            moving = true;

            if (run)
            {
                currentSpeed.x = Mathf.Min(currentSpeed.x + (accel * Time.deltaTime), runSpeed);
            }
            else
            {
                currentSpeed.x = Mathf.Min(currentSpeed.x + (accel * Time.deltaTime), walkSpeed);
            }

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            facing = 3;
            moving = true;
            
            if (run)
            {
                currentSpeed.x = Mathf.Max(currentSpeed.x - (accel * Time.deltaTime), -runSpeed);
            }
            else
            {
                currentSpeed.x = Mathf.Max(currentSpeed.x - (accel * Time.deltaTime), -walkSpeed);
            } 
        }
        else
        {
            currentSpeed.x = Mathf.Lerp(currentSpeed.x, 0, .2f);
        }

        run = Input.GetKey(KeyCode.LeftShift);
        // if (Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     anim.SetTrigger("StartRun");
        // }
        
        if (!attacking)
        {
            anim.SetBool("Running", run);
            anim.SetBool("Moving", moving);
        }
    }
    
}