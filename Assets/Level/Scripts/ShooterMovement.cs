using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShooterMovement : MonoBehaviour {

    public Rigidbody2D bullet;              // Prefab of the rocket.
    public float speed;				// The speed the rocket will fire at.
    public RectTransform rt;
    public Vector3 centerPt;
    public float radius;
    public Text text;
    public GameObject gun;
    public float touchTolerance;

    private bool hasFired;
    private int frameNum;
    private Vector3 initialPoint;
    private AudioSource shootSound;
    private float moveVertical;
    private float moveHorizontal;

    void Start()
    {
        shootSound = GetComponent<AudioSource>();
        centerPt = rt.anchoredPosition;
        // Get the initial position of the joystick
        initialPoint = rt.position;
    }
    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = new Touch();
            Touch[] touches = Input.touches;
            int i = 0;
            bool found = false;
            while (i < touches.Length && !found)
            {
                Touch temp = touches[i];
                Vector2 touchLocation = temp.position;
                Vector3 worldTouch = Camera.main.ScreenToWorldPoint(new Vector3(touchLocation.x, touchLocation.y, 0));
                if (inBounds(worldTouch.x, worldTouch.y))
                {
                    found = true;
                    touch = temp;
                }
                i++;
            }
            if (!found)
            {   // continue firing in previous direction
                if (!hasFired)
                {
                    moveHorizontal = (rt.anchoredPosition.x - centerPt.x) / radius;
                    moveVertical = (rt.anchoredPosition.y - centerPt.y) / radius;
                    float angle = Mathf.Atan(moveVertical / moveHorizontal) * Mathf.Rad2Deg;
                    // If the fire button is pressed...
                    if (moveHorizontal != 0 || moveVertical != 0)
                    {
                        hasFired = true;
                        // ... set the animator Shoot trigger parameter and play the audioclip.
                        //anim.SetTrigger("Shoot");

                        Rigidbody2D bulletInstance = Instantiate(bullet, gun.transform.position, Quaternion.Euler(new Vector3(0, 0, 90 + angle))) as Rigidbody2D;
                        Vector2 velocity = new Vector2(moveHorizontal, moveVertical);
                        velocity.Normalize();
                        velocity *= speed;
                        shootSound.Play();
                        bulletInstance.velocity = velocity;
                    }
                }
                else if (Time.frameCount - frameNum >= 20)
                {
                    frameNum = Time.frameCount;
                    hasFired = false;
                }
                return;
            }

                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    Vector2 touchLocation = touch.position;
                    Vector3 worldTouch = Camera.main.ScreenToWorldPoint(new Vector3(touchLocation.x, touchLocation.y, 0));

                if (Time.frameCount % 30 == 0)
                    {
                        //text.text = "joystick loc is (" + rt.position.x + " , " + rt.position.y + ")\n" + "anchoredPos is (" + rt.anchoredPosition.x + " , " + rt.anchoredPosition.y + ")\n" + "location is (" + worldTouch.x + " , " + worldTouch.y + ")";
                    }
                    if (inBounds(worldTouch.x, worldTouch.y))
                    {
                        Vector3 position = new Vector3(rt.anchoredPosition.x, rt.anchoredPosition.y, 0);
                        Vector3 movement = worldTouch - position;
                        Vector3 newPos = position + movement;
                        Vector3 offset = newPos - initialPoint;
                        rt.anchoredPosition = centerPt + Vector3.ClampMagnitude(offset, radius);

                        if (!hasFired)
                        {
                            moveHorizontal = (rt.anchoredPosition.x - centerPt.x) / radius;
                            moveVertical = (rt.anchoredPosition.y -centerPt.y) / radius;
                            float angle = Mathf.Atan(moveVertical / moveHorizontal) * Mathf.Rad2Deg;
                            // If the fire button is pressed...
                            if (moveHorizontal != 0 || moveVertical != 0)
                            {
                            if (Time.frameCount % 50 == 0)
                            {
                                //text.text = "FIRED with x speed of " + moveHorizontal + " y speed of " + moveVertical + " and angle of " + angle;
                            }
                                hasFired = true;
                                // ... set the animator Shoot trigger parameter and play the audioclip.
                                //anim.SetTrigger("Shoot");
                                
                                // ... instantiate the rocket facing right and set it's velocity to the right. 

                                Rigidbody2D bulletInstance = Instantiate(bullet, gun.transform.position, Quaternion.Euler(new Vector3(0, 0, 90+angle))) as Rigidbody2D;
                            Vector2 velocity = new Vector2(moveHorizontal, moveVertical);
                            velocity.Normalize();
                            velocity *= speed;
                            shootSound.Play();
                            bulletInstance.velocity = velocity;
                            }
                        }
                        else if (Time.frameCount - frameNum >= 20)
                        {
                            frameNum = Time.frameCount;
                            hasFired = false;
                        }
                    }
                }
            
        } else
        {
            // the user is not touching the screen currently
            if (!hasFired)
            {
                float angle = Mathf.Atan(moveVertical / moveHorizontal) * Mathf.Rad2Deg;
                // If the fire button is pressed...
                if (moveHorizontal != 0 || moveVertical != 0)
                {
                    hasFired = true;
                    // ... set the animator Shoot trigger parameter and play the audioclip.
                    //anim.SetTrigger("Shoot");

                    Rigidbody2D bulletInstance = Instantiate(bullet, gun.transform.position, Quaternion.Euler(new Vector3(0, 0, 90 + angle))) as Rigidbody2D;
                    Vector2 velocity = new Vector2(moveHorizontal, moveVertical);
                    velocity.Normalize();
                    velocity *= speed;
                    shootSound.Play();
                    bulletInstance.velocity = velocity;
                }
            }
            else if (Time.frameCount - frameNum >= 20)
            {
                frameNum = Time.frameCount;
                hasFired = false;
            }


        }
    }

    bool inBounds(float x, float y)
    {
        if ((x <= initialPoint.x+radius+touchTolerance) && (x >= initialPoint.x-radius-touchTolerance) && (y <= initialPoint.y+radius+touchTolerance) && (y >= initialPoint.y-radius-touchTolerance))
        {
            return true;
        }
        return false;
    }
}
