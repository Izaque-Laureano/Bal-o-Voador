using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource audio;
    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
    }
}
