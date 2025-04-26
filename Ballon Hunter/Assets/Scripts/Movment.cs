using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movment : MonoBehaviour
{
    Rigidbody2D RB;
    public float MaxSpeed, CurrentSpeed;
    // Altura máxima antes de destruir o balão
    public float maxY = 8.0f;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        MaxSpeed = Random.Range(60, 150);
        CurrentSpeed = MaxSpeed;
    }


    private void FixedUpdate()
    {
        RB.velocity = Vector2.up * CurrentSpeed * Time.deltaTime;

        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
