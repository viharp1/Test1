using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public RectTransform rt;
    public Vector3 centerPt;
    public float radius;
    public float maxSpeed;
    public float touchTolerance;

    private Rigidbody2D playerBody;
    private Vector3 initialPoint;

    void Start()
    {

        centerPt = rt.anchoredPosition;
        // Get the initial position of the joystick
        initialPoint = rt.position;
        playerBody = player.GetComponent<Rigidbody2D>();
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
            {   // reset the joystick to the center
                rt.anchoredPosition = centerPt;
                return;
            }

            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                Vector2 touchLocation = touch.position;
                Vector3 worldTouch = Camera.main.ScreenToWorldPoint(new Vector3(touchLocation.x, touchLocation.y, 0));

                if (inBounds(worldTouch.x, worldTouch.y))
                {
                    Vector3 position = new Vector3(rt.anchoredPosition.x, rt.anchoredPosition.y, 0);
                    Vector3 movement = worldTouch - position;
                    Vector3 newPos = position + movement;
                    Vector3 offset = newPos - initialPoint;
                    rt.anchoredPosition = centerPt + Vector3.ClampMagnitude(offset, radius);

                    float moveHorizontal = (rt.anchoredPosition.x - centerPt.x) / radius;
                    float moveVertical = (rt.anchoredPosition.y - centerPt.y) / radius;

                    playerBody.AddForce(player.transform.up * maxSpeed * moveVertical);
                    playerBody.AddForce(player.transform.right * maxSpeed * moveHorizontal);
                }
            }
        } else
        {
            // reset the joystick to the center
            rt.anchoredPosition = centerPt;
        }
    }

    bool inBounds(float x, float y)
    {
        if ((x <= initialPoint.x + radius + touchTolerance) && (x >= initialPoint.x - radius - touchTolerance) && (y <= initialPoint.y + radius + touchTolerance) && (y >= initialPoint.y - radius - touchTolerance))
        {
            return true;
        }
        return false;
    }
}
