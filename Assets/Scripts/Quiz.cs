using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using System.Linq;
//using System.;
//using Unity.Mathematics;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionTxt;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestionSO;

    [Header("Buttons")]
    [SerializeField] GameObject[] answerBtns;
    [SerializeField] Sprite defaultSpriteForButton;
    [SerializeField] Sprite correctAnsSprite;
    bool hasAnsweredEarly = false;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Score")]
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreTxt;


    [Header("ProgressSlider")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    void Start()
    {
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
        NextQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.timerFraction;
        if (timer.loadNextQuestion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            NextQuestion();
            timer.loadNextQuestion = false;
        }

        else if(!timer.isReadingTheQuestion && !hasAnsweredEarly)
        {
            SetButtonState(false);
            DisplayAnswer(-1);
        }
        //else
    }

    void NextQuestion()
    {
        if(questions.Count > 0)
        {
            hasAnsweredEarly = false;
            SetButtonState(true);
            SetDefaultSpriteButtons();
            ChooseTheQuestion();
            DisplayQuestion();
            progressBar.value++;
        }
    }

    void ChooseTheQuestion()
    {
        int index = UnityEngine.Random.Range(0, questions.Count);
        currentQuestionSO = questions[index];
        if (questions.Contains(currentQuestionSO))
        {
            questions.Remove(currentQuestionSO);
        }
    }

    void DisplayQuestion()
    {
        //FindObjectOfType<Timer>().isReadingTheQuestion = true;
        scoreKeeper.IncrementAskedQuestions();
        questionTxt.text = currentQuestionSO.GetQuestion();
        for (int i = 0; i < answerBtns.Length; i++)
        {
            TextMeshProUGUI buttonText = answerBtns[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestionSO.GetAnswerAtIndex(i);
        }
    }
    public void CheckTheAnswer(int btnIndex)
    {
        hasAnsweredEarly = true;
        timer.CancelTimer();
        DisplayAnswer(btnIndex);
        scoreTxt.text = "Score: " + scoreKeeper.CalculateScore() + "%";
        SetButtonState(false);
    }

    void DisplayAnswer(int index)
    {
        int correctAnsIndex = currentQuestionSO.GetCorrectAnsIndex();
        Image btnImage;

        //FindObjectOfType<Timer>().isReadingTheQuestion = false;
        if (index == correctAnsIndex)
        {
            questionTxt.text = "Correct";
            btnImage = answerBtns[index].GetComponent<Image>();
            btnImage.sprite = correctAnsSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            string correctAnsText = currentQuestionSO.GetAnswerAtIndex(correctAnsIndex);
            questionTxt.text = "Sorry, the correct answer was;\n" + correctAnsText;
            btnImage = answerBtns[correctAnsIndex].GetComponent<Image>();
            btnImage.sprite = correctAnsSprite;
        }
    }

    void SetButtonState(bool state)
    {
        Button btn;
        for (int i = 0; i < answerBtns.Length; i++)
        {
            btn = answerBtns[i].GetComponent<Button>();
            btn.interactable = state;
        }
    }

    void SetDefaultSpriteButtons()
    {
        Image btnImg;
        for (int i = 0; i < answerBtns.Length; i++)
        {
            btnImg = answerBtns[i].GetComponent<Image>();
            btnImg.sprite = defaultSpriteForButton;
        }
    }
}
