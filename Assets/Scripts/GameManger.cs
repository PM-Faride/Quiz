using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    Quiz quiz;
    EndTheGame endgame;

    void Awake()
    {
        endgame = FindObjectOfType<EndTheGame>();
        quiz = FindObjectOfType<Quiz>();
    }

    void Start()
    {
        endgame.gameObject.SetActive(false);
        quiz.gameObject.SetActive(true);
    }

    void Update()
    {
        if(quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endgame.FinalScore();
            endgame.gameObject.SetActive(true);
        }
    }

    public void OnReloadTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
