using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewWaypoint : MonoBehaviour
{
    GameManager GM;
    NewWayMove move;
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;
    public SpriteRenderer[] sprites; 


    private void Awake()
    {
        move = FindObjectOfType<NewWayMove>();
        GM = FindObjectOfType<GameManager>();
    }


    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(t.position, waypointSize);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount -1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount -1).position, transform.GetChild(0).position);
      
    }



    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
       if(currentWaypoint == null)
        {
            return transform.GetChild(0);   


        }

       if(currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            Debug.Log(currentWaypoint);
            string teste = currentWaypoint.ToString();


         



            if (GM.FaseAtual == 1)

            {
                if (teste.Contains("Fase 1"))
                {
                    move.moveSpeed = 0;
                    currentWaypoint.GetComponent<SpriteRenderer>().color = Color.green;
                    Invoke("level", 2f);
                }



            }





            if (GM.FaseAtual == 2)

            {
                
                if (teste.Contains("Fase 2"))
                {
                    move.moveSpeed = 0;
                    currentWaypoint.GetComponent<SpriteRenderer>().color = Color.green;
                    Invoke("level", 2f);
                }



            }

              if(GM.FaseAtual == 3)

            {

                if (teste.Contains("Fase 3"))
                {
                    move.moveSpeed = 0;

                    currentWaypoint.GetComponent<SpriteRenderer>().color = Color.green;
                    Invoke("level", 2f);


                }



            }
            
              if(GM.FaseAtual == 4)

            {

                if (teste.Contains("Fase 4"))
                {
                    move.moveSpeed = 0;

                    currentWaypoint.GetComponent<SpriteRenderer>().color = Color.green;
                    Invoke("level", 2f);


                }



            }
                      
              if(GM.FaseAtual == 5)

            {

                if (teste.Contains("Fase 5"))
                {
                    move.moveSpeed = 0;

                    currentWaypoint.GetComponent<SpriteRenderer>().color = Color.green;
                    Invoke("level", 2f);


                }

                
            }
            

            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);

        }

        else
        {
            //return null; 
              return transform.GetChild(0);
        }
    }
    private void Update()
    {
        if(GM.FaseAtual >= 2)
        {
            sprites[1].color = Color.green;
            sprites[2].color = Color.white;
            sprites[3].color = Color.white;
            sprites[4].color = Color.white;
            
        }
        if (GM.FaseAtual >= 3)
        {
            sprites[1].color = Color.green;
            sprites[2].color = Color.green;
            sprites[3].color = Color.white;
            sprites[4].color = Color.white;

        }
        if (GM.FaseAtual >= 4)
        {
            sprites[1].color = Color.green;
            sprites[2].color = Color.green;
            sprites[3].color = Color.green;
            sprites[4].color = Color.white;

        }
        if (GM.FaseAtual >= 5)
        {
            sprites[1].color = Color.green;
            sprites[2].color = Color.green;
            sprites[3].color = Color.green;
            sprites[4].color = Color.green;
            
        }
    }

    public void level()
    {
        GameObject SD = FindObjectOfType<SoundManager>().gameObject;
        Destroy(SD);
        SceneManager.LoadScene(GM.FaseAtual);
    }

}
