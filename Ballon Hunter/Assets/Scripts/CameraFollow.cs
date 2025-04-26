using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public Vector3 offset;

    public float xMin, xMax;
    public float yMin, yMax;

    private bool isPanelActive = false; // Verifica se um painel está ativo
    private Vector3 initialPosition;    // Guarda a posição inicial da câmera

    private void Start()
    {
        initialPosition = transform.position; // Salva a posição inicial
    }

    private void LateUpdate()
    {
        if (isPanelActive)
            return; // Se um painel estiver ativo, a câmera não segue o personagem

        transform.position = target.transform.position + offset;

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, xMin, xMax),
            Mathf.Clamp(transform.position.y, yMin, yMax),
            -10
            );
    }

    public void SetPanelActive(bool active)
    {
        isPanelActive = active;

        if (active)
            transform.position = initialPosition; // Retorna à posição original quando um painel abre
    }
}
