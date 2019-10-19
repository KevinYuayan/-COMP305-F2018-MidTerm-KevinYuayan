using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;
/// <summary>
/// File Name: HorizontalIslandController.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Oct. 19, 2019
/// Description: Controller that controls the Island in Level2
/// Revision History:
/// </summary>
public class HorizontalIslandController : MonoBehaviour
{
    public float horizontalSpeed = 0.05f;


    public Boundary boundary;

    private bool _isLevel2;

    // Start is called before the first frame update
    void Start()
    {        
        // Checks if Level is 2
        GameObject scoreBoardObj = GameObject.Find("ScoreBoard");
        _isLevel2 = (SceneManager.GetActiveScene().name == "Level2");
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the Island left by horizontalSpeed
    /// </summary>
    void Move()
    {
        if (_isLevel2)
        {
            Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        // Level 3
        else
        {
            Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
            Vector2 currentPosition = transform.position;

            currentPosition += newPosition;
            transform.position = currentPosition;
        }

    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        if (_isLevel2)
        {
            float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
            transform.position = new Vector2(boundary.Right, randomYPosition);
        }
        // Level 3
        else
        {
            float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
            transform.position = new Vector2(boundary.Left, randomYPosition);
        }
    }

    /// <summary>
    /// This method checks if the Island reaches the left boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (_isLevel2)
        {
            if (transform.position.x <= boundary.Left)
            {
                Reset();
            }
        }
        // Level 3
        else
        {
            if (transform.position.x >= boundary.Right)
            {
                Reset();
            }
        }
    }
}
