using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour {

    public int magnitudeMin;

    Vector2 startPos;
    Vector2 direction;

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 inicioTouch, swipeDelta;
    private bool estaArrastando = false;

    public Vector2 SwipeDelta
    {
        get
        {
            return SwipeDelta;
        }
    }

    public bool SwipeLeft
    {
        get
        {
            return swipeLeft;
        }
    }

    public bool SwipeRight
    {
        get
        {
            return swipeRight;
        }
    }

    public bool SwipeUp
    {
        get
        {
            return swipeUp;
        }
    }

    public bool SwipeDown
    {
        get
        {
            return swipeDown;
        }
    }

    void Update()
    {
        swipeLeft = swipeRight = swipeUp = swipeDown = false;

        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    swipeDelta = touch.position - startPos;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    if (swipeDelta.magnitude > magnitudeMin)
                    {                      
                        float x = swipeDelta.x;
                        float y = swipeDelta.y;

                        if (Mathf.Abs(x) > Mathf.Abs(y))
                        {
                            if (x < 0)
                            {
                                swipeLeft = true;
                            }
                            else
                            {
                                swipeRight = true;
                            }
                        }
                        else
                        {
                            if (y < 0)
                            {
                                swipeDown = true;
                            }
                            else
                            {
                                swipeUp = true;
                            }
                        }
                        Reset();
                    }
                break;
            }
        }
    }

    private void Reset()
    {
        startPos = swipeDelta = Vector2.zero;        
    }
}
