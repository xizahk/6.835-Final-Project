using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // Add new constants to this script as needed, e.g.
    // public const int NUMBER_OF_PLAYERS = 4;

    // KINECT GESTURE DETECTION THRESHOLDS
    public const float FLAP_UP= 0.15f;
    public const float FLAP_DOWN = 0.2f;

    // SCREEN
    public const float CAMERA_GAME_LEVEL_SPEED = 2f;
    public const int SCREEN_HEIGHT = 1000;

    // CHARACTER
    public const int CHARACTER_MAX_HEIGHT = SCREEN_HEIGHT;
    public const float CHARACTER_TILT_SPEED = .5f;
    public const float CHARACTER_FLAP_SPEED = 1.5f;
    public const float CHARACTER_FALL_SPEED = 1f;

    // UI TEXT
    public static readonly string PlayerTag = "Player";
    public static readonly string StatusFlapToStart = "Flap to start";
    public static readonly string StatusDeadFlapToStart = "Dead. Flap to start";

    // MAP
    public const int STARTING_PATH = 3;

    // COLLECTIBLES
    public const float COLLECTIBLE_MIN_Y = 1f;
    public const float COLLECTIBLE_MAX_Y = 3f;
}
