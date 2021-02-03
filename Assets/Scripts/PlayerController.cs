using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;

	private void Update()
	{
		Vector3 position = transform.position;

		position.x += moveSpeed * Time.deltaTime;

		transform.position = position;
	}
}
