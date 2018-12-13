using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    bool start = false;

    //Position Tracking
    float songPosition;
    float songPosInBeats;
    float secPerBeat;
    float dsptimesong;

    //Song Notes
    float bpm = 127;
    float[] notes = { 2.5f, 3.0f, 4.0f, 5.0f, 6.5f, 8.0f, 9.0f, 9.5f, 10.5f, 11.0f,
        15.0f, 16.0f, 17.0f, 18.0f, 19.0f, 20.5f, 22.0f, 23.5f, 24.0f, 24.5f

    };

int nextIndex = 0;

    GameObject g;

    // Use this for initialization
    void Start()
    {
        g = GameObject.Find("Spawner");
        secPerBeat = 60f / bpm;

    }

    // Update is called once per frame
    void Update() {

        if (PlayerPrefs.GetInt("Start") == 1 && !start)
        {
            dsptimesong = (float)AudioSettings.dspTime;

            //Start the Song
            GetComponent<AudioSource>().Play();
            start = true;
        }
        else
        {

            songPosition = (float)(AudioSettings.dspTime - dsptimesong);
            songPosInBeats = songPosition / secPerBeat;

            if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats)
            {
                g.GetComponent<Generation>().SpawnGoodies();

                nextIndex++;
            }
        }

    }





}