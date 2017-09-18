using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class QR_Success : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetString("QRCode") != "")
        {
            text.enabled = true;
            text.text = "Scan Result: " + PlayerPrefs.GetString("QRCode");
            StartCoroutine(timer());
        }
	}
	
    IEnumerator timer()
    {
        yield return new WaitForSeconds(3);
        text.enabled = false;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
