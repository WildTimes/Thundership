using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 deltaPosition;
    public Vector2 deltaMove;

    public float deadZone;
    // a partir dessa distância o swipe passa a ser considerado.

    public bool tap;
    public bool isSwiping;
    public bool swipeLeft;
    public bool swipeRight;


    void Start()
    {
        deadZone = 10;
        Reset();
    }

    void Update()
    {
        #region Mouse Input
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }
        #endregion

        #region Touch Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startPosition = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }

        #endregion

        /// Calcula o lado do swipe
        if (tap)
        {
            if (Input.touches.Length > 0)
            {
                deltaPosition = Input.touches[0].position - startPosition;
            }
            if (Input.GetMouseButton(0))
            {
                deltaPosition = (Vector2)Input.mousePosition - startPosition;
            }
        }

        if (deltaPosition.magnitude > deadZone)
        {
            isSwiping = true;
            
            float x = deltaPosition.x;
            float y = deltaPosition.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    swipeRight = true;
                    deltaMove.x = deltaPosition.x - deadZone;
                }
                else
                {
                    swipeLeft = true;
                    deltaMove.x = deltaPosition.x + deadZone;
                }
            }
        }
    }


    void Reset()
    {
        startPosition = Vector2.zero;
        deltaPosition = Vector2.zero;
        deltaMove = Vector2.zero;

        tap = false;
        isSwiping = false;
        swipeLeft = false;
        swipeRight = false;
    }
}
