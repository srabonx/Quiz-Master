using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int CorrectAnswer = 0;
    int QuestionsSeen = 0;

    public int GetCorrectAnswers()
    {
        return CorrectAnswer;
    }

    public void IncreamentCorrectAnswer()
    {
        CorrectAnswer++;
    }
    
    public int GetQuestionsSeen()
    {
        return QuestionsSeen;
    }

    public void IncreamentQuestionsSeen()
    {
        QuestionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(CorrectAnswer / (float)QuestionsSeen * 100);
    }

}
