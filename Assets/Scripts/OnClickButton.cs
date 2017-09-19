using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnClickButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadOtherScene()
    {
        SceneManager.LoadScene("Others");
    }
    
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadComingSoon()
    {
        SceneManager.LoadScene("ComingSoon");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadQR()
    {
        SceneManager.LoadScene("QR");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadCamera()
    {
        SceneManager.LoadScene("Camera");
    }
    public void LoadCameraTest()
    {
        SceneManager.LoadScene("test");
    }
    public void LoadQRTest()
    {
        SceneManager.LoadScene("test 1");
    }
}
