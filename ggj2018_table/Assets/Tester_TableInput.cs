using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester_TableInput : MonoBehaviour {
    TableInput inputManager;
	// Use this for initialization
	void Start () {
        inputManager = this.GetComponent<TableInput>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("euler:"+inputManager.GetEuler());
        for (int i = 0; i < 4; i += 1)
        {
            if (inputManager.GetButton(i))
                Debug.Log("button " + i + "pressed");
        }
	}
}
