using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    static WebCamTexture frontCam;

    //void Start()
    //{
    //    if (backCam == null)
    //        backCam = new WebCamTexture();

    //    GetComponent<Renderer>().material.mainTexture = backCam;

    //    if (!backCam.isPlaying)
    //        backCam.Play();

    //}

    void Start()
    {
        string selectedDeviceName = "";
        WebCamDevice[] allDevices = WebCamTexture.devices;
        for (int i = 0; i < allDevices.Length; i++)
        {
            if (allDevices[i].isFrontFacing)
            {
                selectedDeviceName = allDevices[i].name;
                break;
            }
        }
        if (frontCam == null)
            frontCam = new WebCamTexture(selectedDeviceName, Screen.width, Screen.height);
        else
            print(frontCam.ToString());

        GetComponent<Renderer>().material.mainTexture = frontCam;

        if (!frontCam.isPlaying)
            frontCam.Play();
    }

    void Update()
    {

    }
}