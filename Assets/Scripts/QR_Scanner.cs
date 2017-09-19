using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ZXing;
using ZXing.QrCode;

public class QR_Scanner : MonoBehaviour
{
    private string text = "";
    WebCamTexture webCamTexture;
    public Quaternion baseRotation;
    int count = 0;
    void Start()
    {
        if (webCamTexture == null)
            webCamTexture = new WebCamTexture();
        baseRotation = transform.rotation;
        webCamTexture.Play();
    }

    void Update()
    {
        GetComponent<RawImage>().texture = webCamTexture;
        transform.rotation = baseRotation * Quaternion.AngleAxis(webCamTexture.videoRotationAngle, Vector3.up);
        if(count % 25 == 0)
        {
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(webCamTexture.GetPixels32(), webCamTexture.width, webCamTexture.height);
                if(result != null)
                {
                    Debug.Log("DCOEDE TEXT FROM QR" + result.Text);
                    text = result.Text;
                    PlayerPrefs.SetString("QRCode", text);
                    Handheld.Vibrate();
                    SceneManager.LoadScene("Options");
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
        }
        count++;
    }
}