using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayeController : MonoBehaviour
{
    public float maxSwipe;
    Vector2 moveTo;
    float lastPosition;
    float groundedTime, endTime;
    float speedHitWith;
    float idleTimer, hitTimer, HazradHurtTimer, sheildTimer;
    Vector3 startTouch, lastTouch, hitFrom, startHit, endHit;
    Vector3 worldTouch;

    bool moved, newHit, inAir, haveBeenHit = false;
    public bool tapped = false;
    public float runSpeed = 10.0f;
    public float flickForce;

    Animator anim;
    public Animator blinkAnim;
    Rigidbody2D rb;
    GroundedScript onGround;
    public bool buttonPressed;
    public Slider HealthBar;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        onGround = GetComponentInChildren<GroundedScript>();
        HealthBar.value = 100;
    }

    void Update()
    {
        Debug.Log(HazradHurtTimer);
        Timers();

        if(!buttonPressed)
        Move();

        Facing();
        anim.SetBool("inAir", !onGround.isGrounded);
        inAir = !onGround.isGrounded;
    }

    private void IdleCheck()
    {
        idleTimer -= Time.deltaTime;
        if(idleTimer <= 0)
        {
            if (Random.Range(1, 100) < 40)
                anim.Play("Blink");
            if (Random.Range(1, 100) < 25)
                blinkAnim.SetTrigger("Blink");
            idleTimer = 2f;
        }
    }
    private void Facing()
    {
        if(lastPosition != transform.position.x)
        {
            anim.SetBool("moving", true);
            if (lastPosition >= transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            lastPosition = transform.position.x;
        }
        else
        {
            IdleCheck();
            anim.SetBool("moving", false);
        }
    }
    private void Move()
    {
        foreach (Touch touch in Input.touches)
        {
            worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouch = worldTouch;
                    newHit = true;
                    break;

                case TouchPhase.Moved:
                    if (Vector3.Distance(startTouch, worldTouch) > maxSwipe)
                    {
                        moved = true;
                        tapped = false;
                        if (!inAir && haveBeenHit)
                        {
                            FlickEyeball();
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    if (!moved && !inAir)
                    {
                        moveTo = new Vector2(worldTouch.x, transform.position.y);
                        tapped = true;
                    }
                    else
                    moved = false;
                    haveBeenHit = false;
                    break;
            }            
        }
        if (!inAir && tapped && moveTo.x != transform.position.x)
        {
            if (onGround.hitWall)
            {
                if (onGround.wallPosition < transform.position.x)
                {
                    if (moveTo.x > transform.position.x)
                        onGround.hitWall = false;
                    else
                        moveTo = transform.position;
                }
                else
                {
                    {
                        if (moveTo.x < transform.position.x)
                            onGround.hitWall = false;
                        else
                            moveTo = transform.position;
                    }
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, moveTo, runSpeed * Time.deltaTime);
        }                
    }

    private void FlickEyeball()
    {
        speedHitWith = Vector3.Distance(startHit, endHit) / endTime;
        Vector2 firePower = (endHit - startHit) * (speedHitWith * flickForce);
        rb.velocity = firePower;
    }
    public void Timers()
    {
        if(HazradHurtTimer > 0)
            HazradHurtTimer -= Time.deltaTime;
        if(hitTimer < 2)
            hitTimer += Time.deltaTime;
    }
    private void TakeDamage()
    {
        if(sheildTimer <= 0)
        {
            anim.Play("Hurt");
            HazradHurtTimer = 0.5f;
            HealthBar.value -= 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FingerSwinger")
        {
            hitTimer = 0f;
            startHit = collision.transform.position;
        }
        if (collision.gameObject.tag == "Hazard")
        {
            TakeDamage();

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            if(HazradHurtTimer <= 0)
            {
                TakeDamage();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FingerSwinger")
        {
            endHit = collision.transform.position;
            endTime = hitTimer;
            haveBeenHit = true;
            newHit = false;
        }
    }
}
