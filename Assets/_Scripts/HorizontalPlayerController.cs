using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
/// <summary>
/// File Name: HorizontalPlayerController.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Oct. 19, 2019
/// Description: Controller that controls the Player in Level2
/// Revision History:
/// </summary>
public class HorizontalPlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;
    public GameController gameController;

    // private instance variables
    private AudioSource _thunderSound;
    private AudioSource _yaySound;

    // Start is called before the first frame update
    void Start()
    {
        _thunderSound = gameController.audioSources[(int)SoundClip.THUNDER];
        _yaySound = gameController.audioSources[(int)SoundClip.YAY];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    // Takes User Input to move the player up or down
    public void Move()
    {
        Vector2 newPosition = transform.position;

        if(Input.GetAxis("Vertical") > 0.0f)
        {
            newPosition += new Vector2(0.0f,speed.max);
        }

        if (Input.GetAxis("Vertical") < 0.0f)
        {
            newPosition += new Vector2(0.0f,speed.min);
        }

        transform.position = newPosition;
    }
    // Checks the player's position to keep them in the borders
    public void CheckBounds()
    {
        // check right boundary
        if(transform.position.y > boundary.Top)
        {
            transform.position = new Vector2( transform.position.x, boundary.Top);
        }

        // check left boundary
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x,boundary.Bottom);
        }
    }
    
    // Triggers on collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            // Lose a life with cloud
            case "Cloud":
                _thunderSound.Play();
                gameController.Lives -= 1;
                break;
            // Gain points with Island
            case "Island":
                _yaySound.Play();
                gameController.Score += 100;
                break;
        }
    }

}
