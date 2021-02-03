using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	[SerializeField] private Transform target = null;
	[SerializeField] private bool ignoreY = false;

	private Vector3 offset = Vector3.zero;

	private void Awake()
	{
		offset = target.position - transform.position;
	}

	private void LateUpdate()
	{
		float yPosition = transform.position.y;

		Vector3 newPosition = target.position - offset;

		if (ignoreY)
		{
			newPosition.y = yPosition;
		}

		transform.position = newPosition;
	}
}
