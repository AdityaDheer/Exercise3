using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
