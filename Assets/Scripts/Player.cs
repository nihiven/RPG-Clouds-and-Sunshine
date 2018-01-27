using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character 
{
	[SerializeField]
	private Stat _health;

    [SerializeField]
    private Stat _shield;

    [SerializeField]
	private float _initHealth;

    [SerializeField]
    private float _initShield;

    // Use this for initialization
    protected override void Start () 
	{
		_health.Initialize(
            currentValue: _initHealth, 
            maxValue: _initHealth
        );

        _shield.Initialize(
            currentValue: _initShield,
            maxValue: _initShield
        );

  	    base.Start();
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		GetInput();
		base.Update();
	}

	private void GetInput()
	{
        // TODO: I think adding these creates too much velocity in the overlapping direction
		direction = Vector2.zero;

		if (Input.GetKey(KeyCode.W))
		{
			direction += Vector2.up;	
		}
		if (Input.GetKey(KeyCode.A))
		{
			direction += Vector2.left;
		}
		if (Input.GetKey(KeyCode.S))
		{
			direction += Vector2.down;
		}
		if (Input.GetKey(KeyCode.D))
		{
			direction += Vector2.right;
		}

        if (Input.GetKeyDown(KeyCode.X))
        {
            _health.CurrentValue -= 10;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _shield.CurrentValue -= 10;
        }
    }
}

