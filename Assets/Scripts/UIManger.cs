using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI ScoreObject;
    public float MaxRandom;
    public float MinRandom;
    void Start()
    {
        Score = 0;
    }
    void Update()
    {
        ScoreObject.text = string.Format("Score: {0:0,0}",Score);
        CheckScore();
    }
    void CheckScore()
    {
        if(Score > 999999999)
        {
            Score = 999999999;
        }
        if(Score <= 0)
        {
            Score = 0;
        }
    }
    public void UpdateScore(int Value)
    {
        if(Value != 0)
        {
            Score += Value;
        }
        if(Value == 0)
        {
            Score = 0;
        }
    }
    public void AddRandomScore()
    {
        float RanValue = Random.Range(MinRandom, MaxRandom);
        int PassValue = (int)RanValue;
        UpdateScore(PassValue);   
    }
    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
