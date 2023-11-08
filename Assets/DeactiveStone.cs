using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveStone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LoseCollider"))
        {
            gameObject.SetActive(false);
        }
    }

}
