using UnityEngine;
using UnityEngine.UI;

public class TrocarMenus : MonoBehaviour
{
    [Header("Bot�es do menu principal")]
    public GameObject[] botoesPrincipais;

    [Header("Bot�es do menu de op��es")]
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
