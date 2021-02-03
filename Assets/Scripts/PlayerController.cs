using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
	[SerializeField] private float jumpSpeed = 5.0f;
	[SerializeField] private float jumpHeight = 3.0f;

	private bool jumping = false;
	private bool falling = false;

	private void Update()
	{
		Vector3 position = transform.position;

		position.x += moveSpeed * Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Space) && !jumping && !falling)
		{
			jumping = true;
		}

		if (jumping)
		{
			position.y += jumpSpeed * Time.deltaTime;

			if (position.y >= jumpHeight)
			{
				position.y = jumpHeight;

				jumping = false;
				falling = true;
			}
		}		
		else if (falling)
		{
			position.y -= jumpSpeed * Time.deltaTime;

			if (position.y <= 0.0f)
			{
				position.y = 0.0f;

				falling = false;
			}
		}

		transform.position = position;
	}
}
