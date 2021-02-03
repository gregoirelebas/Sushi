﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	[SerializeField] private Transform target = null;

	private Vector3 offset = Vector3.zero;

	private void Awake()
	{
		offset = target.position - transform.position;
	}

	private void LateUpdate()
	{
		transform.position = target.position - offset;
	}
}
