using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Question", menuName = "Quiz Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField]
    string Question = "Enter new question here!";

    [SerializeField]
    string[] Answers = new string[4]; 

    [Range(0,4)]
    [SerializeField]
    int AnsIndex = 0;

    public string GetQuestion()
    {
        return Question;
    }

    public string GetAnswer(int index)
    {
        return Answers[index];
    }

    public int GetCorrectAnsIndex()
    {
        return AnsIndex;
    }
}

