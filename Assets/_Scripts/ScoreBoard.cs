using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// File Name: ScoreBoard.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Oct. 19, 2019
/// Description: Holds data that isn't destroyed
/// Revision History:
/// </summary>
[System.Serializable]
public class ScoreBoard : MonoBehaviour
{
    public int lives;
    public int score;
    public int highScore;
}
