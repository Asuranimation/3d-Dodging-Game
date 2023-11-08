using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScorring : MonoBehaviour
{
    public event Action onTriggerScorring;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stone"))
        {
            onTriggerScorring?.Invoke();
        }
    }
}
