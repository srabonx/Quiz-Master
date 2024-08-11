using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI FinalScoreText;

    ScoreKeeper m_scoreKeeper;

   // bool m_playAgain = false;

    void Awake()
    {
        m_scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        FinalScoreText.text = "Congratulations!\n Your score is: " +
                                 m_scoreKeeper.CalculateScore() + "%";
    }

  /*  public void TogglePlay()
    {
        m_playAgain = !m_playAgain;
    }

    public bool IsPlayingAgain()
    {
        return m_playAgain;
    }
    */
}
