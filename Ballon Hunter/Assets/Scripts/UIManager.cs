using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public bool Soma;
    public bool Menos;

    public int MinRange, MaxRange;
    public int CurrentScore, MidleNumber ,MaxScore;
    public bool LevelDone;
    public Text CurrentScoreText, MidleNumberText , MaxScoreText;
    public static UIManager instance;
    public GameObject GameOverPanel, Passou;
    BaloonSpawn BS;

    private void Awake()
    {
        MaxScore = Random.Range(MinRange,MaxRange);
        MaxScoreText.text = MaxScore.ToString();
        BS = FindObjectOfType<BaloonSpawn>();


        if (Soma)
        {
            MidleNumber = Random.Range(2, 4);
            MidleNumberText.text = MidleNumber.ToString();
        }
        else if (Menos)
        {
            MidleNumber = Random.Range(2, 4);
            MidleNumberText.text = MidleNumber.ToString();
        }
        if (instance == null)
        {
            instance = this;

        } 


        instance = this;
      

      
    }

    // Update is called once per frame
    void Update()
    {
        if (!Soma && !Menos)
        {

            if (CurrentScore == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                Passou.SetActive(true);

            }
            else if (CurrentScore > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();

                GameOverPanel.SetActive(true);
            }
        }
      
        else if(Soma)
        {

            if (CurrentScore + MidleNumber == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                Passou.SetActive(true);

            }
            else if (CurrentScore + MidleNumber > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();

                GameOverPanel.SetActive(true);
            }


        }
        else if (Menos)
        {

            if (CurrentScore - MidleNumber == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                Passou.SetActive(true);

            }
            else if (CurrentScore - MidleNumber > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();

                GameOverPanel.SetActive(true);
            }


        }


    }


    public void SetScore(int Score)
    {
        CurrentScore += Score;
        CurrentScoreText.text = CurrentScore.ToString();
    }

}
