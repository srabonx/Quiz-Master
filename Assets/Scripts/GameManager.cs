using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    QuizManager m_quizManager;
    EndScreen m_endScreen;

    void Awake()
    {
        m_quizManager = FindObjectOfType<QuizManager>();
        m_endScreen = FindObjectOfType<EndScreen>();

    }

    void Start()
    {      
        m_quizManager.gameObject.SetActive(true);
        m_endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if(m_quizManager.IsComplete)
        {
            m_quizManager.gameObject.SetActive(false);
            m_endScreen.gameObject.SetActive(true);
            m_endScreen.ShowFinalScore();
        }
    }

    public void OnReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
