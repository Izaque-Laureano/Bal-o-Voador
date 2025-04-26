using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonPoints : MonoBehaviour
{
    public int point;
    private Animator anim;
    public AudioSource explosion;

    [Header("BAL�O MULTIPLICADOR")]
    public bool isMultiplier = false;
    public int multiplier = 2; // valor padr�o de multiplica��o

    UIManager UI;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        UI = FindObjectOfType<UIManager>();

        if (UI == null)
            Debug.LogError("UIManager n�o encontrado na cena!");

        if (explosion == null)
            Debug.LogError("AudioSource de explos�o n�o atribu�do no Inspector!");
    }

    public void OnMouseDown()
    {
        if (UI == null || UI.LevelDone) return;

        // Ativa anima��o (um �nico frame de explos�o j� deve estar configurado no Animator)
        anim.SetTrigger("Explode");

        // Executa o som
        if (explosion != null)
            explosion.Play();

        // Aplica pontua��o
        if (isMultiplier)
            UIManager.instance.MultiplyScore(multiplier);
        else
            UIManager.instance.SetScore(point);

        // Destroi ap�s um curt�ssimo tempo s� pra dar tempo do som sair
        Destroy(gameObject, 0.15f);
    }
}
