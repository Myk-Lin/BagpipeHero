using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BF : MonoBehaviour {

    public void LoadScene(int a)
    {
        SceneManager.LoadScene(a);

    }

    public void Quit()
    {
        Application.Quit();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
