using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Move speed")]
	[SerializeField] private float moveSpeed = 10.0f;
	[SerializeField] private float jumpSpeed = 5.0f;
	[SerializeField] private float minJumpSpeed = 1.0f;

	[Header("Inertia")]
	[SerializeField] private float jumpInertia = 2.0f;
	[SerializeField] private float fallInertia = 2.0f;

	[Header("Jump limits")]
	[SerializeField] private float groundHeight = 0.0f;
	[SerializeField] private float jumpHeight = 3.0f;
	[SerializeField] private float jumpCoolDown = 0.5f;

	private float currentJumpSpeed = 0.0f;
	private float currentFallSpeed = 0.0f;

	private bool canJump = true;
	private bool isJumping = false;
	private bool isFalling = false;

	private void Update()
	{
		Vector3 position = transform.position;

		position.x += moveSpeed * Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Space) && canJump)
		{
			isJumping = true;
			canJump = false;

			currentJumpSpeed = jumpSpeed;
		}

		MovePlayerV(ref position);

		transform.position = position;
	}

	/// <summary>
	/// Move player along vertical axis.
	/// </summary>
	private void MovePlayerV(ref Vector3 position)
	{
		if (isJumping)
		{
			currentJumpSpeed -= jumpInertia * Time.deltaTime;
			currentJumpSpeed = Mathf.Clamp(currentJumpSpeed, minJumpSpeed, jumpSpeed);

			position.y += currentJumpSpeed * Time.deltaTime;

			if (position.y >= jumpHeight)
			{
				position.y = jumpHeight;

				currentFallSpeed = currentJumpSpeed;

				isJumping = false;
				isFalling = true;
			}
		}
		else if (isFalling)
		{
			currentFallSpeed += fallInertia * Time.deltaTime;

			position.y -= currentFallSpeed * Time.deltaTime;

			if (position.y <= groundHeight)
			{
				position.y = groundHeight;

				isFalling = false;

				this.DelayedAction(() =>
				{
					canJump = true;
				}, jumpCoolDown);
			}
		}
	}
}
