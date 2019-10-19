using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;
/// <summary>
/// File Name: HorizontalCloudController.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Oct. 19, 2019
/// Description: Controller that controls the Cloud in Level2
/// Revision History:
/// </summary>
public class HorizontalCloudController : MonoBehaviour
{
    [Header("Speed Values")]
    [SerializeField]
    public Speed horizontalSpeedRange;

    [SerializeField]
    public Speed verticalSpeedRange;

    public float verticalSpeed;
    public float horizontalSpeed;

    [SerializeField]
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
    /// This method moves the ocean left by horizontalSpeed
    /// </summary>
    void Move()
    {
        if (_isLevel2)
        {
            Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        // Level 3
        else
        {
            Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
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
            horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
            verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

            float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
            transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + 2.0f), randomYPosition);
        }
        // Level 3
        else
        {
            horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
            verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

            float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
            transform.position = new Vector2(Random.Range(boundary.Left, boundary.Left - 2.0f), randomYPosition);
        }
    }

    /// <summary>
    /// This method checks if the ocean reaches the left boundary
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
