using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuizManager : MonoBehaviour
{

    [Header("Questions")]
    [SerializeField]
    TextMeshProUGUI QuestionText;

    [SerializeField]
    QuestionSO CurrentQuestion;
    
    [SerializeField]
    List<QuestionSO> QuestionList = new List<QuestionSO>();

    [Header("Answers")]
    [SerializeField]
    GameObject[] AnswerButtons;

    int CorrectAnswerIndex;
    bool m_answered = true;



    [Header("Button Colors")]
    [SerializeField]
    Sprite DefaultAnsSprite;

    [SerializeField]
    Sprite CorrectAnsSprite;

    [Header("Timer")]
    [SerializeField]
    Image TimerImage;
    Timer m_timer;

    [Header("Scoring")]
    [SerializeField]
    TextMeshProUGUI ScoreText;
    ScoreKeeper m_scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField]
    Slider ProgressBar;

    public bool IsComplete = false;

    void Awake()
    {
        m_timer = FindObjectOfType<Timer>();
        m_scoreKeeper = FindObjectOfType<ScoreKeeper>();
        ProgressBar.maxValue = QuestionList.Count;
        ProgressBar.value = 0;
    }

    void Update()
    {
        TimerImage.fillAmount = m_timer.FillAmount;
        if(m_timer.LoadNextQuestion)
        {
            
            if(ProgressBar.value == ProgressBar.maxValue)
            {
                IsComplete = true;
                return;
            }

            GetNextQuestion();
            m_timer.LoadNextQuestion = false;
        }

        if(!m_timer.isAnweringQuestion && !m_answered)
        {
            DisplayCorrectAnswer();
            SetButtonState(false);
        }
    }

    private void DisplayQuestion()
    {
        QuestionText.text = CurrentQuestion.GetQuestion();

        CorrectAnswerIndex = CurrentQuestion.GetCorrectAnsIndex();

        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = CurrentQuestion.GetAnswer(i);
        }

        m_answered = false;

        m_scoreKeeper.IncreamentQuestionsSeen();
    }

    void GetNextQuestion()
    {
        if(QuestionList.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
            ProgressBar.value++;
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0,QuestionList.Count);
        CurrentQuestion = QuestionList[index];

        if(QuestionList.Contains(CurrentQuestion))
            QuestionList.Remove(CurrentQuestion);
    }

    public void OnAnswerSelect(int index)
    {

        if(CorrectAnswerIndex == index)
        {
            QuestionText.text = "Correct!";

            Image buttonImage = AnswerButtons[index].GetComponent<Image>();
            
            buttonImage.sprite = CorrectAnsSprite;

            m_scoreKeeper.IncreamentCorrectAnswer();
        }
        else
        {
           DisplayCorrectAnswer();
        }   

        SetButtonState(false);
        m_timer.CancelTimer();
        m_answered = true;
        ScoreText.text = "Score: " + m_scoreKeeper.CalculateScore() + "%";
    }

    private void DisplayCorrectAnswer()
    {
            QuestionText.text = "Wrong! The Correct answer is: \n"+
                                (CorrectAnswerIndex + 1).ToString() +": "+ 
                                CurrentQuestion.GetAnswer(CorrectAnswerIndex);

            Image buttonImage = AnswerButtons[CorrectAnswerIndex].GetComponent<Image>();
            
            buttonImage.sprite = CorrectAnsSprite;
    }

    private void SetButtonState(bool state)
    {
        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            Button button = AnswerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void SetDefaultButtonSprite()
    {
        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            Image buttonImage = AnswerButtons[i].GetComponent<Image>();
            buttonImage.sprite = DefaultAnsSprite;
        }
    }

}
