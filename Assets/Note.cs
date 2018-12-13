using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    //public int lifetime = 8;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Use this for initialization
    void Start () {
        rb.velocity = new Vector2(0, -speed);
        //Destroy(gameObject, lifetime);
    }
	
	// Update is called once per frame
	void Update () {


    }

}
