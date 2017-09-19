using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    WebCamTexture webCamTexture;
    public Quaternion baseRotation;

    void Start()
    {
        webCamTexture = null;
        WebCamDevice[] wdcs = WebCamTexture.devices;
        for (int n = 0; n < wdcs.Length; ++n)
        {
            if (wdcs[n].isFrontFacing)
            {
                webCamTexture = new WebCamTexture(wdcs[n].name, Screen.width, Screen.height);
            }
        }
        if (webCamTexture == null)
            webCamTexture = new WebCamTexture();
        baseRotation = transform.rotation;
        webCamTexture.Play();
    }

    void Update()
    {
        GetComponent<RawImage>().texture = webCamTexture;
        transform.rotation = baseRotation * Quaternion.AngleAxis(webCamTexture.videoRotationAngle, Vector3.up);

    }
    public void onClick()
    {
        StartCoroutine(TakePhoto());
    }
    IEnumerator TakePhoto()
    {

        // NOTE - you almost certainly have to do this here:

        yield return new WaitForEndOfFrame();

        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        string your_path = "/storage/emulated/0/Dwonload";
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes(your_path + "photo.png", bytes);
    }
}