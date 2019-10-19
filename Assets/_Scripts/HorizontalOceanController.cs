using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// File Name: HorizontalOceanController.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Oct. 19, 2019
/// Description: Controller that controls the Ocean in Level2
/// Revision History:
/// </summary>
public class HorizontalOceanController : MonoBehaviour
{
    public float horizontalSpeed = 0.1f;
    public float resetPosition;
    public float resetPoint;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = 18.4f;
        resetPoint = -10.4f;
        //Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the ocean left by horizontalSpeed
    /// </summary>
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        transform.position = new Vector2(resetPosition, -0.8f);
    }

    /// <summary>
    /// This method checks if the ocean reaches the left boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if(transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}
