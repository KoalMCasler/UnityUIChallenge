using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
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
    [Header("Progress Slider Variables")]
    public Slider totalProgress;
    public TextMeshProUGUI totalProgressText;
    public Slider questItems;
    public TextMeshProUGUI questItemText;
    public Slider enemiesDefeated;
    public TextMeshProUGUI enemiesDefetedText;
    public Animator progressAnim;
    public float ProgressValue;
    public int questItemsCount;
    public int enemiesDefeatedCount;
    [Header("ResolutuionDropdown Variables")]
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    void Start()
    {
        ResolutionsLoop();
        keyIsHidden = false;
        Score = 0;
        sliderImmage = sliderImmageObject.GetComponent<Image>();
    }
    void Update()
    {
        UpdateProgress();
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
    public void AddQuestItem()
    {
        if(questItemsCount < 4)
        {
            questItemsCount += 1;
            ProgressValue += 12.5f;
            if(questItemsCount > 4)
            {
                questItemsCount = 4;
            }
            questItems.value = questItemsCount;
            questItemText.text = string.Format("{0}/4",questItemsCount);
        }
    }
    public void DefeatEnemy()
    {
        if(enemiesDefeatedCount < 10)
        {
            enemiesDefeatedCount += 1;
            ProgressValue += 5;
            if(enemiesDefeatedCount > 10)
            {
                enemiesDefeatedCount = 10;
            }
            enemiesDefeated.value = enemiesDefeatedCount;
            enemiesDefetedText.text = string.Format("{0}/10",enemiesDefeatedCount);
        }
    }
    void UpdateProgress()
    {
        totalProgress.value = ProgressValue;
        totalProgressText.text = string.Format("{0}%",ProgressValue);
        if(ProgressValue >= 100)
        {
            progressAnim.SetBool("ProgressIsFull", true);
        }
    }
    public void ResetProgress()
    {
        progressAnim.SetBool("ProgressIsFull", false);
        ProgressValue = 0;
        enemiesDefeatedCount = 0;
        questItemsCount = 0;
        enemiesDefeated.value = enemiesDefeatedCount;
        enemiesDefetedText.text = string.Format("{0}/50",enemiesDefeatedCount);
        totalProgress.value = ProgressValue;
        totalProgressText.text = string.Format("{0}%",ProgressValue);
        questItems.value = questItemsCount;
        questItemText.text = string.Format("{0}/4",questItemsCount);
    }
    void ResolutionsLoop()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> Options = new List<string>();

        int CurrentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string Option = string.Format("{0} X {1}", resolutions[i].width, resolutions[i].height);
            Options.Add(Option);

            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(Options);
        resolutionDropdown.value = CurrentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }
}
