using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    int multiplier = 1;
    static int streak = 0;
    // Use this for initialization
    void Start() {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Streak", 0);
        PlayerPrefs.SetInt("Mult", 1);
        PlayerPrefs.SetInt("PerformanceMeter", 25);
        //PlayerPrefs.SetInt("Highstreak", 0);
        PlayerPrefs.SetInt("NotesHit", 0);
        PlayerPrefs.SetInt("Start", 1);
        PlayerPrefs.SetInt("Total", 0);
        PlayerPrefs.SetInt("Accuracy", 0);
        StartCoroutine(Duration());

    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds(73);
        Win();

    }

    public void AddStreak()
    {
        if (PlayerPrefs.GetInt("PerformanceMeter") + 1 < 50)
            PlayerPrefs.SetInt("PerformanceMeter", PlayerPrefs.GetInt("PerformanceMeter") + 1);
        streak++;
        if (streak >= 32)
            multiplier = 4;
        else if (streak >= 16)
            multiplier = 3;
        else if (streak >= 8)
            multiplier = 2;
        else
            multiplier = 1;

        if (streak > PlayerPrefs.GetInt("Highstreak"))
            PlayerPrefs.SetInt("Highstreak", streak);

        PlayerPrefs.SetInt("NotesHit", PlayerPrefs.GetInt("NotesHit") + 1);

        UpdateGUI();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        ResetStreak();

    }

    public void ResetStreak()
    {
        PlayerPrefs.SetInt("PerformanceMeter", PlayerPrefs.GetInt("PerformanceMeter") - 2);
        if (PlayerPrefs.GetInt("PerformanceMeter")<0)
            Lose();
        streak = 0;
        multiplier = 1;
        UpdateGUI();

    }

    void Lose()
    {
        PlayerPrefs.SetInt("Start", 0);
        SceneManager.LoadScene(3);
    }
    public void Win()
    {
        PlayerPrefs.SetInt("Start", 0);
        PlayerPrefs.SetInt("Accuracy", PlayerPrefs.GetInt("NotesHit")/PlayerPrefs.GetInt("Total"));
        if (PlayerPrefs.GetInt("Highscore")<PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score"));
        SceneManager.LoadScene(3);
    }


    public void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Mult", multiplier);

    }

    public int GetScore(int num)
    {
        return num * multiplier;

    }

}
