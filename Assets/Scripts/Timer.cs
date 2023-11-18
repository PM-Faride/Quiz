using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float showingQuestion = 30f;
    [SerializeField] float showingAnswerTime = 10f;

    public float timerFraction;
    public bool loadNextQuestion = false;
    public bool isReadingTheQuestion = true;
    float currentTimer;

    void Start()
    {
        currentTimer = showingQuestion;
    }

    void Update()
    {
        UpdateTimer();   
    }

    public void CancelTimer()
    {
        currentTimer = 0;
    }

    void UpdateTimer()
    {
        currentTimer -= Time.deltaTime;
        if(currentTimer > 0)
        {
            if (isReadingTheQuestion)
            {
                timerFraction = currentTimer / showingQuestion;
            }
            else
            {
                //currentTimer = showingQuestion;
                timerFraction = currentTimer / showingAnswerTime;
            }
        }
        else
        {
            if (isReadingTheQuestion)
            {
                currentTimer = showingAnswerTime;
            }
            else
            {
                currentTimer = showingQuestion;
                loadNextQuestion = true;
            }
            isReadingTheQuestion = !isReadingTheQuestion;
        }
    }
}
