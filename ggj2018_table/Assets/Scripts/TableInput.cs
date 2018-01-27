using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInput : MonoBehaviour {
	[SerializeField] bool _is_test_mode = false;
	private float _euler = 0f;
	private bool[] _buttons = new bool[3];
	public int GetEuler () {
		return (int)_euler;
	}
	public bool GetButton(int num) {
		return _buttons[num];
	}
	void Update () {
		Input.gyro.enabled = true;
		_euler = Input.gyro.attitude.eulerAngles.z;
		_buttons[0] = Input.GetKey(KeyCode.Joystick1Button0);
		_buttons[1] = Input.GetKey(KeyCode.Joystick1Button1);
		_buttons[2] = Input.GetKey(KeyCode.Joystick1Button2);
	}
}
