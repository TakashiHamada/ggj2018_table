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
	[SerializeField] Text _count_down_text;
	void Start () {
		HideAll();
		// test
		ShowIntroduction(1,1,0,1,0,-4);
		
	}
	void Update () {
		// SetCountDown(1.234f);
	}
	public void SetCountDown (float num) {
		_count_down_text.text = num.ToString("N1");
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

			_point_number.text = "=" + order.ToString();

		} else {

			_drag_display.SetActive(true);

			if(b_0 == 1) InstantiateSprite(_symbols[0], _drag_symbole_box.transform);
			if(b_1 == 1) InstantiateSprite(_symbols[1], _drag_symbole_box.transform);;
			if(b_2 == 1) InstantiateSprite(_symbols[2], _drag_symbole_box.transform);;
			if(b_3 == 1) InstantiateSprite(_symbols[3], _drag_symbole_box.transform);;

			_drag_number.text = order > 0 ? order.ToString() : (order * -1).ToString();

			for(int id = 0; id < 2; id++) {
				if(order < 0) {
					_drag_arrows[id].transform.localScale *= -1f;
				}
			}
		}
	}
	private void InstantiateSprite (Sprite sprite, Transform parent) {
		var obj = new GameObject();
		obj.transform.parent = parent;
		obj.name = "CreatedSprite";
		var image = obj.AddComponent<Image>();
		image.sprite = sprite;
	}
	private void HideAll() {
		foreach ( Transform n in _drag_symbole_box.transform ) GameObject.Destroy(n.gameObject);
		foreach ( Transform n in _point_symbole_box.transform ) GameObject.Destroy(n.gameObject);

		_drag_display.SetActive(false);
		_point_display.SetActive(false);
	}
}
