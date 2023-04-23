using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Waypoints : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints;
    public int CurrentMaxWay;
    public int index = 0;
    Rigidbody2D RB;
    public float distance = 0f;
    [SerializeField] float MaxSpeed, CurrentSpeed;
    private Vector2 direction;
    GameManager GM;

    
    private void Awake()
 


    {
        GM = FindObjectOfType<GameManager>();

        RB = GetComponent<Rigidbody2D>();
        CurrentSpeed = MaxSpeed;

        switch (GM.FaseAtual)
        {
            case 1:
                {
                    CurrentMaxWay = 8;
                    
                }
                break;
            case 2:
                {
                    CurrentMaxWay = 12;
                }
                break;
            case 3:
                {
                    CurrentMaxWay = 18;
                }
                break;
            case 4:
                {
                    CurrentMaxWay = 23;
                }
                break;
            
        }




    }



    private void FixedUpdate()
    {
        Move();
    }




    private void Move()
    {
        //DIRE��O QUE O PLAYER SEGUE
        direction = ((Vector2)waypoints[index].position - RB.position).normalized;
        //MOVE-SE PARA O PONTO
        RB.MovePosition(RB.position + direction * CurrentSpeed * Time.deltaTime);

        //UMA DIST�NCIA DE CHECAGEM PARA ELE SABER QUE EST� NO LOCAL CORRETO, NA VERDADE ISSO � MAIS PARA EVITAR BUGS
        
        if(Vector3.Distance(transform.position, waypoints[index].position) <= distance)
        {
            //AQUI ELE PEGA O PR�XIMO PONTO, QUANDO A DIST�NCIA QUE FOI DITA ACIMA � ALCAN�ADA
            index++;

            if(index >= CurrentMaxWay)
            {
                index = CurrentMaxWay;
                CurrentSpeed = 0;
                Debug.Log("Cheguei nesse carlho");
                /*Aqui ele chega no ultimo way setado por n�s*/
            }
        }



    }


}
