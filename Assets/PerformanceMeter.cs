using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceMeter : MonoBehaviour {

    float re;
    GameObject needle;

	// Use this for initialization
	void Start () {
        needle = transform.Find("Needle").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        re = PlayerPrefs.GetInt("PerformanceMeter");

        needle.transform.localPosition = new Vector3(7, re / 25, 0);
	}
}
