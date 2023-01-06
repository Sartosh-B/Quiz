using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly;

    [Header("Buttons")]
    int correctAnswetIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correcttAnswerSprite;

    [Header("Timer")] 
    [SerializeField] Image timerImage;
    Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        //DisplayQuestion();
        GetNextQueston();
    }
    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQueston();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }
    void GetNextQueston()
    {
        SetButtonState(true);
        SetDefaultbuttonSprites();
        DisplayQuestion();
    }

    private void SetDefaultbuttonSprites()
    {        
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    public void OnAswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correcttAnswerSprite;
        }
        else
        {
            correctAnswetIndex = question.GetCorrectAnswerIndex();
            questionText.text = "Correct answer is: " + question.GetAnswer(correctAnswetIndex);
            buttonImage = answerButtons[correctAnswetIndex].GetComponent<Image>();
            buttonImage.sprite = correcttAnswerSprite;
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;          
        }
    }
}
