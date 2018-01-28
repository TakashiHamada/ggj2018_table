using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {
    [SerializeField]
    Text _score_text;

    [SerializeField]
    float timer = 10.0f;

    // Use this for initialization
    void Start () {
        //Debug.Log(QuizManager.GetScore());
        _score_text.text = (QuizManager.GetScore()).ToString();
        
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
