using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {
    public GameObject description;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowDescription()
    {
        //GameObject.Find("Description_Big").GetComponent().enabled = true;
        //GameObject.FindWithTag("Description").SetActive(true);
        print("hey");
        description.SetActive(true);
        StartCoroutine(timer());

    }
    
    IEnumerator timer()
    {
        yield return new WaitForSeconds(5);

        //GameObject.Find("Description_Big").GetComponent(Renderer).enabled = false;
        //GameObject.FindWithTag("Description").SetActive(false);
        description.SetActive(false);
    }
}
