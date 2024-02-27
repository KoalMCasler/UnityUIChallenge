using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour
{
    [Header("Score Variables")]
    public int Score;
    public TextMeshProUGUI ScoreObject;
    public float MaxRandom;
    public float MinRandom;
    [Header("Slider Variables")]
    public Slider redSlider;
    public Slider blueSlider;
    public Slider greenSlider;
    public Slider alphaSlider;
    public GameObject sliderImmageObject;
    public Image sliderImmage;
    [Header("Key Hider Variables")]
    public GameObject keyImmage;
    public TextMeshProUGUI ShowHideText;
    public bool keyIsHidden;
    void Start()
    {
        keyIsHidden = false;
        Score = 0;
        sliderImmage = sliderImmageObject.GetComponent<Image>();
    }
    void Update()
    {
        CheckKeyIsHidden();
        UpdateSliderColor();
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
        CheckScore();
        ScoreObject.text = string.Format("Score: {0:0,0}",Score);
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
    void UpdateSliderColor()
    {
        Color sliderColor = new Color(redSlider.value,greenSlider.value,blueSlider.value,alphaSlider.value);
        sliderImmage.color =  sliderColor;
    }
    public void ShowHideKey()
    {
        if(keyIsHidden == false)
        {
            keyIsHidden = true;
        }
        else
        {
            keyIsHidden = false;
        }
    }
    void CheckKeyIsHidden()
    {
        if(keyIsHidden == false)
        {
            keyImmage.SetActive(true);
            ShowHideText.text = "Hide Key";
        }
        else
        {
            keyImmage.SetActive(false);
            ShowHideText.text = "Show Key";
        }
    }
}
