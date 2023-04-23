using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPaineis : MonoBehaviour
{
    public GameObject audiofase;
    private void OnEnable()
    {
        audiofase.SetActive(false);
    }
}
