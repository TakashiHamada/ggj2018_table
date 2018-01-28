using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {
    [SerializeField]
    Text _score_text;


    // Use this for initialization
    void Start () {
        //Debug.Log(QuizManager.GetScore());
        _score_text.text = (QuizManager.GetScore()).ToString();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
