using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonPoints : MonoBehaviour
{
    public int point;
    private Animator anim;
    public AudioSource explosion;

    [Header("BALÃO MULTIPLICADOR")]
    public bool isMultiplier = false;
    public int multiplier = 2; // valor padrão de multiplicação

    UIManager UI;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        UI = FindObjectOfType<UIManager>();

        if (UI == null)
            Debug.LogError("UIManager não encontrado na cena!");

        if (explosion == null)
            Debug.LogError("AudioSource de explosão não atribuído no Inspector!");
    }

    public void OnMouseDown()
    {
        if (UI == null || UI.LevelDone) return;

        // Ativa animação (um único frame de explosão já deve estar configurado no Animator)
        anim.SetTrigger("Explode");

        // Executa o som
        if (explosion != null)
            explosion.Play();

        // Aplica pontuação
        if (isMultiplier)
            UIManager.instance.MultiplyScore(multiplier);
        else
            UIManager.instance.SetScore(point);

        // Destroi após um curtíssimo tempo só pra dar tempo do som sair
        Destroy(gameObject, 0.15f);
    }
}
