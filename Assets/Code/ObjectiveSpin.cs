using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[SerializeField] int spinSpeed = 10;
//[SerializeField] int bounceSpeed = 10;

public class ObjectiveSpin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, Time.deltaTime * 25, 0f, Space.Self);

        //float y = Mathf.Sin(Time.deltaTime * 10);
        //transform.position = new Vector3(0, y, 0);
    }
}
