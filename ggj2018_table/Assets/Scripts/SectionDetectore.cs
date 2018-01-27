using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDetectore : MonoBehaviour {
	[SerializeField] int _division = 8;
	[SerializeField] int _range = 5;
	[SerializeField] TableInput _table_input;
	private int _interval;
	private int _current_id = -1;
	public int GetCurrentId () {
		return _current_id;
	}
	public int GetDivistion () {
		return _division;
	}
	void Start () {
		_interval = 360 / _division;	
	}
	void Update () {
		var euler = _table_input.GetEuler();
		for(int id = 0; id < _division; id++) {
			int min = (_interval * id) - _range;
			if((_interval * id) - _range < euler && euler < (_interval * id) + _range) {
				_current_id = id;
				
			} else
			// 対策
			if(euler > 360 - _range) _current_id = 0;	
		}
	}
}
