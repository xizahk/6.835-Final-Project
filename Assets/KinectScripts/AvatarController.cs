using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;


[RequireComponent(typeof(Animator))]
public class AvatarController : MonoBehaviour
{
	// private instance of the KinectManager
	protected KinectManager kinectManager;

	// transform caching gives performance boost since Unity calls GetComponent<Transform>() each time you call transform 
	private Transform _transformCache;
	public new Transform transform
	{
		get
		{
			if (!_transformCache)
				_transformCache = base.transform;

			return _transformCache;
		}
	}

	public void Awake()
	{

	}

	// Update the avatar each frame.
	public void UpdateAvatar(uint UserID)
	{
		if (!transform.gameObject.activeInHierarchy)
			return;

		// Get the KinectManager instance
		if (kinectManager == null)
		{
			kinectManager = KinectManager.Instance;
		}

		// move the avatar to its Kinect position
		MoveAvatar(UserID);
	}

	// Set bones to their initial positions and rotations
	public void ResetToInitialPosition()
	{

	}

	// Invoked on the successful calibration of a player.
	public void SuccessfulCalibration(uint userId)
	{

	}

	// Moves the avatar in 3D space - pulls the tracked position of the spine and applies it to root.
	// Only pulls positional, not rotational.
	protected void MoveAvatar(uint UserID)
	{
		if (kinectManager == null)
			return;

		//// Get the position of the body and store it.
		//Vector3 trans = kinectManager.GetUserPosition(UserID);

		bool tiltLeft = kinectManager.isTiltLeft();
		bool tiltRight = kinectManager.isTiltRight();
		bool flap = kinectManager.isFlap();

		// Smoothly transition to the new position
		// Move the avatar left, right, up, or down depending on whether tilt and/or flapping gestures are captured
		//Vector3 trans = bodyRoot.localPosition;
		Vector3 trans = new Vector3(0, 0, 0);
		trans += (tiltLeft) ? new Vector3(-Constants.CHARACTER_TILT_SPEED, 0, 0) : new Vector3(0, 0, 0);
		trans += (tiltRight) ? new Vector3(Constants.CHARACTER_TILT_SPEED, 0, 0) : new Vector3(0, 0, 0);
		float deltaY = 0;
		if (!flap && transform.localPosition[1] > 0)
		{
			// Make player fall down slowly
			deltaY = -Math.Min(transform.localPosition[1], Constants.CHARACTER_FALL_SPEED * Time.deltaTime);
		}
		else if (flap && trans[1] < Constants.CHARACTER_MAX_HEIGHT)
		{
			deltaY = Constants.CHARACTER_FLAP_SPEED;
		}
		trans += new Vector3(0, deltaY, 0);
		transform.localPosition += trans;
	}
}