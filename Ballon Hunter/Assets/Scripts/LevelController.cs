using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
  


    public void LoadLevel()
    {
        Time.timeScale = 1;
        int NextLevel = SceneManager.GetActiveScene().buildIndex +1;
        GameManager.GM.FaseAtual++;
        GameManager.GM.Save();
        SceneManager.LoadScene("PainelFases");
    }


    public void Menu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");

    }
   

    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void  LoadScene (int level)
    {
        if (GameManager.GM.FaseAtual <= 5) {
            SceneManager.LoadScene(level);
        }
        else{
            GameObject SD = FindObjectOfType<SoundManager>().gameObject;
            Destroy(SD);
            SceneManager.LoadScene("Final");
        }
    }


    public void resetGame()
    {
        
        GameManager.GM.FaseAtual = 1;
        
        GameManager.GM.Save();
        SceneManager.LoadScene("Menu");
    }

    public void final()
    {
        GameManager.GM.FaseAtual++;
        GameManager.GM.Save();
        SceneManager.LoadScene(7);
    }

    public void fechar()
    {
        Application.Quit();
    }

}
