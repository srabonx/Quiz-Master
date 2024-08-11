using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField]
    float TimeToAnswer = 10f;
    
    [SerializeField]
    float TimeToReview = 5f;

    float m_timerValue;

    public bool isAnweringQuestion = false;

    public bool LoadNextQuestion = false;

    public float FillAmount;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateTimer();
    }


    void UpdateTimer()
    {
        m_timerValue -= Time.deltaTime;

        if(isAnweringQuestion)
        {
            if(m_timerValue <= 0)
            {
                isAnweringQuestion = false;
                m_timerValue = TimeToReview;
            }
            
            FillAmount = m_timerValue / TimeToAnswer;

        }
        else
        {
            if(m_timerValue <= 0)
            {
                isAnweringQuestion = true;
                m_timerValue = TimeToAnswer;
                LoadNextQuestion = true;
            }

            FillAmount = m_timerValue / TimeToReview;
        }

    }

    public void CancelTimer()
    {
        m_timerValue = 0;
    }

}
