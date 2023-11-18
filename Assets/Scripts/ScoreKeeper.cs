using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers;
    int askedQuestions;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public int GetAskedQuestions()
    {
        return askedQuestions;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers += 1;    
    }

    public void IncrementAskedQuestions() 
    {
        askedQuestions += 1;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt((correctAnswers / (float)askedQuestions) * 100);
    }
}
