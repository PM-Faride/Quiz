using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question", fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question =  "Write your new question here...";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnsIndex;
    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswerAtIndex(int index)
    {
        return answers[index]; 
    }

    public int GetCorrectAnsIndex()
    {
        return correctAnsIndex;
    }
}
