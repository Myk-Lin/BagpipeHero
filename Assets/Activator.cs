using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    SpriteRenderer sr;
    public KeyCode key;
    bool active = false;
    GameObject note, gm;
    Color old;
    float distance = 0;
    int modScore;

    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GameManager");
        old = sr.color;

    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(key))
        {

            StartCoroutine(Pressed());

        }

        if (Input.GetKeyDown(key) && active)
        {
            distance = note.transform.position.y - sr.transform.position.y;
            Debug.Log(distance);
            Destroy(note);
            gm.GetComponent<GameManager>().AddStreak();
            AddScore();
            active = false;
        }
        
        else if (Input.GetKeyDown(key) && !active)
        {
            gm.GetComponent<GameManager>().ResetStreak();

        }
        

    }

    private void OnTriggerEnter2D(Collider2D col) {
        active = true;

        if (col.gameObject.tag == "Note")
            note = col.gameObject;

    }


    private void OnTriggerExit2D(Collider2D col)
    {
        active = false;

    }
    
    void AddScore()
    {
        //perfect,great,good,bad,miss
        if (distance < 0.2 && distance > -0.2)
            modScore = 100;
        else if (distance < 0.4 && distance > -0.4)
            modScore = 80;
        else if (distance < 0.6 && distance > -0.6)
            modScore = 60;
        else if (distance < 1 && distance > -1)
            modScore = 30;

        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager>().GetScore(modScore));

    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        sr.color = old;
    }


}
