using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonPoints : MonoBehaviour
{
    public int point;
    Animator anim;
    public AudioSource explosion;

    [Header("NOME DA ANIM DESTRUIR")]
    public string AnimatorName;
    UIManager UI;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        UI = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
          
    }


    
    public void OnMouseDown()
    {
        if (!UI.LevelDone)
        {
            anim.Play(AnimatorName);

        }
    }

    public void Destruir()
    {
        explosion.Play();
        UIManager.instance.SetScore(point);
        Invoke("destruir2", 0.08f);

    }

    public void destruir2()
    {
        Destroy(gameObject);
    }
}
