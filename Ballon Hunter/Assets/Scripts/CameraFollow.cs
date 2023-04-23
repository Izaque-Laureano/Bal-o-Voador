using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   
    [SerializeField] private GameObject target;
    public Vector3 offset;


    public float xMin, xMax;
    public float yMin, yMax;


    private void LateUpdate()
    {
        transform.position = target.transform.position + offset;


        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, xMin, xMax),
            Mathf.Clamp(transform.position.y, yMin, yMax),
            -10
            );

    }


}
