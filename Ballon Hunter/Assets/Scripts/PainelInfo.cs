using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelInfo : MonoBehaviour
{
    public GameObject painelInfo;
    
    public void Painel()
    {
        painelInfo.SetActive(true);
    }

    public void PainelDesativo()
    {
        painelInfo.SetActive(false);
    }
}
