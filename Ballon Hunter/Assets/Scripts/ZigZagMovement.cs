using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : MonoBehaviour
{
    public float verticalSpeed = 2f;           // velocidade para cima
    public float horizontalAmplitude = 1f;     // até onde ele vai pros lados
    public float horizontalFrequency = 2f;     // quantas vezes por segundo ele oscila

    private Vector3 startPos;
    private float elapsedTime = 0f;

    // Altura máxima antes de destruir o balão (ajuste conforme sua câmera/cena)
    public float maxY = 8.0f;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Acumula o tempo real de vida do balão
        elapsedTime += Time.deltaTime;

        float horizontalOffset = Mathf.Sin(elapsedTime * horizontalFrequency) * horizontalAmplitude;
        float verticalOffset = verticalSpeed * elapsedTime;

        transform.position = new Vector3(startPos.x + horizontalOffset, startPos.y + verticalOffset, startPos.z);

        // Se ultrapassar o limite vertical, destrói o balão
        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
    }

    /*
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    */
}
