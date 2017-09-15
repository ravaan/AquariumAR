using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadOtherScene()
    {
        Application.LoadLevel("Others");
    }
    
    public void LoadMain()
    {
        Application.LoadLevel("Main");
    }

    public void LoadComingSoon()
    {
        Application.LoadLevel("ComingSoon");
    }

    public void LoadInstructions()
    {
        Application.LoadLevel("Instructions");
    }

    public void LoadQR()
    {
        Application.LoadLevel("QR");
    }

    public void LoadOptions()
    {
        Application.LoadLevel("Options");
    }

    public void LoadCamera()
    {
        Application.LoadLevel("Camera");
    }
}
