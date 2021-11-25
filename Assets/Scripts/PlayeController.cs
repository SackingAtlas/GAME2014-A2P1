using UnityEngine;
public class PlayeController : MonoBehaviour
{
    public float maxSwipe;
    Vector2 moveTo;
    float lastPosition;
    float startTime;
    float speedHitWith;
    Vector3 startTouch, lastTouch, hitFrom;
    Vector3 worldTouch;

    bool moved, newHit, moveHere, inAir, haveBeenHit = false;
    public float runSpeed = 10.0f;
    public float pullForce;

    Animator anim;
    Rigidbody2D rb;
    public GameObject buttonObject;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    //maybe set up swipe to hit
    //power of hit based of time and distance touch takes
    //must hit eyeball

    void Update()
    {
        if (!buttonObject.GetComponent<ButtonScripts>().buttonTouched)
        {
            Move();
        }
        Facing();
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
            anim.SetBool("moving", false);
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
                    break;

                case TouchPhase.Moved:
                    if(Vector3.Distance(startTouch, worldTouch) > maxSwipe)
                    {
                        moved = true;
                        if (!inAir && haveBeenHit == true && newHit == true)
                        {
                            speedHitWith = (worldTouch - lastTouch).magnitude;
                            FlickEyeball();
                            lastTouch = worldTouch;
                            //Vector2 firePower = (worldTouch - startTouch) * pullForce;
                            //rb.velocity = firePower;
                            //moved = false;
                            //moveHere = false;
                            //anim.SetBool("inAir", true);
                            //inAir = true;
                            //haveBeenHit = false;
                            //newHit = false;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    if (!moved)
                    {
                        moveTo = new Vector2(worldTouch.x, transform.position.y);
                        moveHere = true;
                    }
                    //else
                    //{
                    //    if (!inAir && haveBeenHit == true)
                    //    {
                    //        Vector2 firePower = (worldTouch - startTouch) * pullForce;
                    //        rb.velocity = firePower;
                    //        moved = false;
                    //        moveHere = false;
                    //        anim.SetBool("inAir", true);
                    //        inAir = true;
                    //        haveBeenHit = false;
                    //    }
                    //}
                    newHit = true;
                    break;
            }            
        }
        if (moveHere && moveTo.x != transform.position.x)
                transform.position = Vector2.MoveTowards(transform.position, moveTo, runSpeed * Time.deltaTime);       
    }

    private void FlickEyeball()
    {
        //float distanceTraveled = Vector2.Distance(startTouch, worldTouch);
        //float speedHit = distanceTraveled / startTime;
        //Debug.Log(speedHit);
        //Vector2 firePower = (worldTouch - startTouch) * pullForce * speedHit;
        //Debug.Log(firePower);

        Vector2 firePower = (worldTouch - startTouch) * (speedHitWith * pullForce);
        rb.velocity = firePower;
        moved = false;
        moveHere = false;
        anim.SetBool("inAir", true);
        inAir = true;
        haveBeenHit = false;
        newHit = false;
    }

    public void Attack()
    {
        Debug.Log("down fucked");
        buttonObject.GetComponent<ButtonScripts>().buttonTouched = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        anim.SetBool("inAir", false);
        inAir = false;
        if(col.gameObject.name == "FingerSwinger")
        Debug.Log(col.contacts[0].point);
    }

    //void OnCollisionExit2D(Collision2D col)
    //{
    //    anim.SetBool("inAir", true);
    //    inAir = true;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "FingerSwinger")
            haveBeenHit = true;
        hitFrom = collision.transform.position;
    }
}
