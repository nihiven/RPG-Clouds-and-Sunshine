﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	[SerializeField]
	private float speed;
	protected Vector2 direction;

	// Use this for initialization
	protected virtual void Start () 
	{
		direction = Vector2.up;
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
		Move ();
	}

	public void Move()
	{
		transform.Translate (direction * speed * Time.deltaTime);
	}
}
