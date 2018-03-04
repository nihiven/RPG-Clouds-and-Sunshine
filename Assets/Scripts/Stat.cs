using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

	private Image _content;
	private float _currentFill;
	private float _currentValue;
	public float MaxValue
	{
		get;
		set;
	}

	public float CurrentValue
	{
		get 
		{ 
			return _currentValue; 
		}
		set 
		{ 
			if (value > MaxValue)
				_currentValue = MaxValue;
			else if (value < 0)
				_currentValue = 0;
			else
				_currentValue = value;
			_currentFill = CurrentValue / MaxValue;
		}
	}

	// Use this for initialization
	void Start () 
	{
		_content = GetComponent<Image> ();
	}

	public void Initialize(float currentValue, float maxValue)
	{
		MaxValue = maxValue;
		CurrentValue = currentValue;
	}

	// Update is called once per frame
	void Update () 
	{
		_content.fillAmount = _currentFill;
	}
}
