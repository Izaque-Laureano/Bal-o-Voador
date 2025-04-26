using UnityEngine;
using UnityEngine.UI;

public class TrocarMenus : MonoBehaviour
{
    [Header("Botões do menu principal")]
    public GameObject[] botoesPrincipais;

    [Header("Botões do menu de opções")]
    public GameObject[] botoesOpcoes;

    public void AbrirOpcoes()
    {
        SetBotoes(botoesPrincipais, false);
        SetBotoes(botoesOpcoes, true);
    }

    public void VoltarParaMenu()
    {
        SetBotoes(botoesPrincipais, true);
        SetBotoes(botoesOpcoes, false);
    }

    private void SetBotoes(GameObject[] botoes, bool estado)
    {
        foreach (GameObject botao in botoes)
        {
            botao.SetActive(estado);
        }
    }
}
