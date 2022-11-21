using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            GameManager.Instance.succeeded();
        }
    }
}
