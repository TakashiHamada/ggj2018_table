using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {
	[SerializeField] Sprite[] _symbols;
	[SerializeField] GameObject _drag_display;
	[SerializeField] Text _drag_number;
	[SerializeField] GameObject[] _drag_arrows;
	[SerializeField] GameObject _drag_symbole_box;
	[SerializeField] GameObject _point_display;
	[SerializeField] Text _point_number;
	[SerializeField] Image _point_symbole_box;
	void Start () {
		HideAll();
		// test
		ShowIntroduction(1,1,0,1,0,-4);
		
	}
	void Update () {
		
	}
	public void ShowIntroduction(int type, int b_0, int b_1, int b_2, int b_3, int order){
		HideAll();
		if(type == 0) {
			int target_id = -1;
			if(b_0 == 1) target_id = 0;
			else if(b_1 == 1) target_id = 1;
			else if(b_2 == 1) target_id = 2;
			else if(b_3 == 1) target_id = 3;

			_point_display.SetActive(true);
			_point_symbole_box.sprite = _symbols[target_id];
			// Instantiate(_symbols[target_id], _point_symbole_box.transform);

			_point_number.text = "=" + order.ToString();

		} else {

			_drag_display.SetActive(true);
			
			if(b_0 == 1) Instantiate(_symbols[0], _point_symbole_box.transform);
			if(b_1 == 1) Instantiate(_symbols[1], _point_symbole_box.transform);
			if(b_2 == 1) Instantiate(_symbols[2], _point_symbole_box.transform);
			if(b_3 == 1) Instantiate(_symbols[3], _point_symbole_box.transform);

			_drag_number.text = order > 0 ? order.ToString() : (order * -1).ToString();

			for(int id = 0; id < 2; id++) {
				if(order < 0) {
					_drag_arrows[id].transform.localScale *= -1f;
				}
				// _drag_arrows[id].transform.localScale * -1;
			}

		}
	}
	private void HideAll() {
		foreach ( Transform n in _drag_symbole_box.transform ) GameObject.Destroy(n.gameObject);
		foreach ( Transform n in _point_symbole_box.transform ) GameObject.Destroy(n.gameObject);

		_drag_display.SetActive(false);
		_point_display.SetActive(false);
	}
}
