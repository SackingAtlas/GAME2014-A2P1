using UnityEngine;
public class PlayeController : MonoBehaviour
{
    public float maxSwipe;
    Vector2 moveTo;
    Vector3 startTouch;
    Vector3 endTouch;

    bool moved;
    public float runSpeed = 10.0f;


    void Start()
    {

    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        foreach (Touch touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouch = worldTouch;
                    break;

                case TouchPhase.Moved:
                    if(Vector3.Distance(startTouch, worldTouch) > maxSwipe)
                    moved = true;
                    break;

                case TouchPhase.Ended:
                    if (!moved)
                    {
                        moveTo = new Vector2(worldTouch.x, transform.position.y);
                    }
                    else
                    {
                        Debug.Log("ya don and moved");
                        //swipe stuff
                        moved = false;
                    }
                    Debug.Log(moveTo);
                    break;
            }            
        }
        transform.position = Vector2.MoveTowards(transform.position, moveTo, runSpeed * Time.deltaTime);
    }
}
