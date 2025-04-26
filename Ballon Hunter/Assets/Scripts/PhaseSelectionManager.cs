using System.Collections.Generic;
using UnityEngine;

public class PhaseSelectionManager : MonoBehaviour
{
    [System.Serializable]
    public class PhaseData
    {
        public string phaseIdentifier; // Identificador único da fase, ex.: "Fase1_Tempo"
        public GameObject phaseButton; // Botão ou elemento que representa a fase
        public GameObject oneStarSprite; // Sprite para 1 estrela
        public GameObject twoStarsSprite; // Sprite para 2 estrelas
        public GameObject threeStarsSprite; // Sprite para 3 estrelas
        public GameObject oneSTarSpritePainel; //sprite para a 1 estrela painel
        public GameObject twoStarSpritePainel; //sprite para a 2 estrela painel
        public GameObject threeStarSpritePainel; // sprite para a 3 estrela painel
    }

    public List<PhaseData> phases; // Lista de fases configuradas no Inspector

    void Start()
    {
        foreach (var phase in phases)
        {
            // Recupera o tempo salvo para a fase
            int savedTime = PlayerPrefs.GetInt(phase.phaseIdentifier, -1);

            // Ativa as estrelas com base no tempo salvo
            if (savedTime != -1)
            {
                ActivateStarsBasedOnTime(phase, savedTime);
            }
        }
    }

    private void ActivateStarsBasedOnTime(PhaseData phase, int savedTime)
    {
        // Esconde todas as estrelas primeiro
        phase.oneStarSprite.SetActive(false);
        phase.twoStarsSprite.SetActive(false);
        phase.threeStarsSprite.SetActive(false);
        phase.oneSTarSpritePainel.SetActive(false);
        phase.twoStarSpritePainel.SetActive(false);
        phase.threeStarSpritePainel.SetActive(false);

        // Define as estrelas com base no tempo
        if (savedTime >= 35) //  3 estrelas
        {
            phase.oneStarSprite.SetActive(true);
            phase.twoStarsSprite.SetActive(true);
            phase.threeStarsSprite.SetActive(true);

            phase.oneSTarSpritePainel.SetActive(true);
            phase.twoStarSpritePainel.SetActive(true);
            phase.threeStarSpritePainel.SetActive(true);
        }
        else if (savedTime > 20) // Tempo médio, 2 estrelas
        {
            phase.oneStarSprite.SetActive(true);
            phase.twoStarsSprite.SetActive(true);
            phase.threeStarsSprite.SetActive(false);

            phase.oneSTarSpritePainel.SetActive(true);
            phase.twoStarSpritePainel.SetActive(true);
            phase.threeStarSpritePainel.SetActive(false);
        }
        else // Tempo longo, 1 estrela
        {
            phase.oneStarSprite.SetActive(true);
            phase.twoStarsSprite.SetActive(false);
            phase.threeStarsSprite.SetActive(false);

            phase.oneSTarSpritePainel.SetActive(true);
            phase.twoStarSpritePainel.SetActive(false);
            phase.threeStarSpritePainel.SetActive(false);
        }
    }
}
