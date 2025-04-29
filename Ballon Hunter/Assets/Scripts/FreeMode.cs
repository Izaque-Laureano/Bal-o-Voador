using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeMode : MonoBehaviour
{
    public static FreeMode Instance;

    public List<string> fasesDisponiveis; // Lista de fases livres para jogar
    private int faseAtualIndex = 0;

    private void Awake()
    {
        // Singleton para acessar de qualquer lugar
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Se quiser que esse controle continue ao mudar de cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Quando escolher uma fase manualmente
    public void EscolherFase(int index)
    {
        if (index >= 0 && index < fasesDisponiveis.Count)
        {
            faseAtualIndex = index;
            SceneManager.LoadScene(fasesDisponiveis[faseAtualIndex]);
        }
        else
        {
            Debug.LogWarning("Índice de fase inválido!");
        }
    }

    // Quando terminar a fase e apertar CONTINUAR
    public void ContinuarParaProximaFase()
    {
        faseAtualIndex++;

        if (faseAtualIndex < fasesDisponiveis.Count)
        {
            SceneManager.LoadScene(fasesDisponiveis[faseAtualIndex]);
        }
        else
        {
            // Acabaram as fases
            Debug.Log("Você completou todas as fases!");
            VoltarParaMenu();
        }
    }

    // Voltar para o Menu de fases
    public void VoltarParaMenu()
    {
        SceneManager.LoadScene("FasesAdicao"); // Nome da cena de menu que lista as fases livres
    }

    public void VoltarParaMenu2()
    {
        SceneManager.LoadScene("Menu2"); // Nome da cena de menu que lista as fases livres
    }

    public void SelecionarModalidade(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
