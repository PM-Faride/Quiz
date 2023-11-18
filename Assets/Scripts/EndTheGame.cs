using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndTheGame : MonoBehaviour
{
    //[SerializeField] Canvas quizCanvas;
    [SerializeField] TextMeshProUGUI scoreReport;
    ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void FinalScore()
    {
        scoreReport.text = "Congragulation!\n You got the score of " 
            + scoreKeeper.CalculateScore() + "%";
    }
}
