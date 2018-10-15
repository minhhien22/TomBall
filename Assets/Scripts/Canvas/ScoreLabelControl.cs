using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreLabelControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckScore();
	}
    void CheckScore()
    {
        if(GameManager._isScored)
        {
            Debug.Log("Here");
            transform.DOMoveX(400, 1);
            transform.position = Camera.main.ScreenToWorldPoint(transform.position);
        }
        else if(!GameManager._isScored)
        {
            transform.DOMoveX(-100, 1);
        }
    }
}
