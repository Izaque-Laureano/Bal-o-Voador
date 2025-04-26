using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    

    public bool Soma;
    public bool Menos;
    public bool SomaSoma;
    public bool MenosMenos;
    public bool SomaMenos;
    public bool MenosSoma;
    public bool Multi;

    public int MinRange, MaxRange;
    public int CurrentScore, MidleNumber,MidleNumber2, MaxScore;
    public bool LevelDone;
    public Text CurrentScoreText, MidleNumberText,MidleNumber2Text, MaxScoreText;
    public static UIManager instance;
    public GameObject GameOverPanel, Passou;
    BaloonSpawn BS;

    [Header("Configurações do Temporizador")]
    public int totalTimeInSeconds = 60; // Tempo total do temporizador
    public Text timerText; // Texto do temporizador
    private float remainingTime;
    private bool isCountingDown = true;
    private bool isAlerting = false;

    private void Awake()
    {
        MaxScore = Random.Range(MinRange, MaxRange);
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
        else if (SomaSoma)
        {
            MidleNumber = Random.Range(2, 4);
            MidleNumberText.text = MidleNumber.ToString();
            MidleNumber2 = Random.Range(4, 8);
            MidleNumber2Text.text = MidleNumber2.ToString();
        }
        else if (MenosMenos)
        {
            MidleNumber = Random.Range(2, 4);
            MidleNumberText.text = MidleNumber.ToString();
            MidleNumber2 = Random.Range(4, 8);
            MidleNumber2Text.text = MidleNumber2.ToString();
        }
        else if (SomaMenos)
        {
            MidleNumber = Random.Range(2, 4);
            MidleNumberText.text = MidleNumber.ToString();
            MidleNumber2 = Random.Range(4, 8);
            MidleNumber2Text.text = MidleNumber2.ToString();
        }
        else if (MenosSoma)
        {
            MidleNumber = Random.Range(2, 4);
            MidleNumberText.text = MidleNumber.ToString();
            MidleNumber2 = Random.Range(4, 8);
            MidleNumber2Text.text = MidleNumber2.ToString();
        }
        else if (Multi)
        {
            MidleNumber = Random.Range(2, 4);
            MidleNumberText.text = MidleNumber.ToString();
           
        }
        if (instance == null)
        {
            instance = this;
        }

        instance = this;

        // Configurações iniciais do temporizador
        remainingTime = totalTimeInSeconds;
        UpdateTimerUI();
        GameOverPanel.SetActive(false); // Garante que o painel esteja oculto no início

     
        
    }

    void Update()
    {
        // Atualização do temporizador
        if (isCountingDown && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();

            // Efeito de alerta nos últimos 10 segundos
            if (remainingTime <= 10 && !isAlerting)
            {
                isAlerting = true;
                StartCoroutine(AlertTimerEffect());
            }
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            isCountingDown = false;
            UpdateTimerUI();
            TriggerGameOver();
        }

        // Lógica do jogo
        HandleGameLogic();

        
    }

    private void HandleGameLogic()
    {
        if (!Soma && !Menos && !SomaSoma && !MenosMenos && !SomaMenos && !MenosSoma && !Multi)
        {
            if (CurrentScore == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                SavePlayerTime();
                Passou.SetActive(true);
            }
            else if (CurrentScore > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                GameOverPanel.SetActive(true);
            }
        }
        else if (Soma)
        {
            if (CurrentScore + MidleNumber == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                SavePlayerTime();
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
                SavePlayerTime();
                Passou.SetActive(true);
            }
            else if (CurrentScore - MidleNumber > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                GameOverPanel.SetActive(true);
            }
        }
        else if (SomaSoma)
        {
            if ((CurrentScore + MidleNumber) + MidleNumber2 == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                SavePlayerTime();
                Passou.SetActive(true);
            }
            else if ((CurrentScore + MidleNumber) + MidleNumber2 > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                GameOverPanel.SetActive(true);
            }
        }
        else if (MenosMenos)
        {
            if((CurrentScore - MidleNumber) - MidleNumber2 == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                SavePlayerTime();
                Passou.SetActive(true);
            }
            else if ((CurrentScore - MidleNumber) - MidleNumber2 > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                GameOverPanel.SetActive(true);
            }
        }
        else if (SomaMenos)
        {
            if ((CurrentScore + MidleNumber) - MidleNumber2 == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                SavePlayerTime();
                Passou.SetActive(true);
            }
            else if ((CurrentScore + MidleNumber) - MidleNumber2 > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                GameOverPanel.SetActive(true);
            }
        }
        else if (MenosSoma)
        {
            if ((CurrentScore - MidleNumber) + MidleNumber2 == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                SavePlayerTime();
                Passou.SetActive(true);
            }
            else if ((CurrentScore - MidleNumber) + MidleNumber2 > MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                GameOverPanel.SetActive(true);
            }
        }
        else if (Multi)
        {
            if (CurrentScore * MidleNumber == MaxScore)
            {
                LevelDone = true;
                BS.thespawn();
                SavePlayerTime();
                Passou.SetActive(true);
            }
            else if (CurrentScore * MidleNumber  > MaxScore)
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
    public void MultiplyScore(int multiplier)
    {
        CurrentScore *= multiplier;
        CurrentScoreText.text = CurrentScore.ToString();
    }
    private string GetPhaseIdentifier()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "_Tempo";
    }

    private void UpdateTimerUI()
    {
        // Exibe o tempo restante somente em segundos
        int seconds = Mathf.CeilToInt(remainingTime);
        timerText.text = seconds.ToString();

        // Atualiza a cor do texto
        if (remainingTime <= 10)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.green;
        }
    }

    private void SavePlayerTime()
    {
        int finalTime = Mathf.CeilToInt(totalTimeInSeconds - remainingTime);
        string phaseIdentifier = GetPhaseIdentifier();
        PlayerPrefs.SetInt(phaseIdentifier, finalTime); // Salva com identificador único
        PlayerPrefs.Save();
        Debug.Log($"Tempo salvo para {phaseIdentifier}: {finalTime} segundos.");
    }

    private void TriggerGameOver()
    {
        Debug.Log("Game Over!");
        BS.thespawn();
        GameOverPanel.SetActive(true); // Mostra o painel de Game Over
    }

    private IEnumerator AlertTimerEffect()
    {
        while (remainingTime > 0 && remainingTime <= 10)
        {
            // Efeito de pulsar no texto
            timerText.fontSize = 165;
            yield return new WaitForSeconds(0.5f);
            timerText.fontSize = 155;
            yield return new WaitForSeconds(0.5f);
        }
        timerText.fontSize = 155; // Restaura o tamanho padrão
    }
}
