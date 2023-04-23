using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movment : MonoBehaviour
{
    Rigidbody2D RB;
    public float MaxSpeed, CurrentSpeed;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        MaxSpeed = Random.Range(60, 150);
        CurrentSpeed = MaxSpeed;
    }


    private void FixedUpdate()
    {
        RB.velocity = Vector2.up * CurrentSpeed * Time.deltaTime;
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
