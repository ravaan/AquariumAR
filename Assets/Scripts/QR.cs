using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ZXing;
using ZXing.QrCode;

public class QR : MonoBehaviour {
	//public Text text_box;
	private string text =  "";
	private WebCamTexture camTexture;
	private Rect screenRect;
    public Quaternion baseRotation;
    void Start() {
		screenRect = new Rect(0, 0, Screen.width, Screen.height);
		camTexture = new WebCamTexture();
        baseRotation = transform.rotation;
        camTexture.requestedHeight = Screen.height; 
		camTexture.requestedWidth = Screen.width;
		if (camTexture != null) {
			camTexture.Play();
		}
	}

	void Update()
	{
		if (text != "") {
            //text_box.text = text;
            //StartCoroutine(timer());
            PlayerPrefs.SetString("QRCode", text);
            Handheld.Vibrate();
            SceneManager.LoadScene("Options");
        }
	}

    //IEnumerator timer()
    //{
    //	yield return new WaitForSeconds(5);
    //	SceneManager.LoadScene ("Options");

    //}
    int count = 0;
	void OnGUI () {
		// drawing the camera on screen
		GUI.DrawTexture (screenRect, camTexture, ScaleMode.ScaleToFit);
		// do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
        if(count % 50 == 0)
        {
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                // decode the current frame
                var result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
                if (result != null)
                {
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                    text = result.Text;
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
        }
        count++;
	}
}
