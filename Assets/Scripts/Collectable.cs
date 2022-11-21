using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void Start()
    {
        // let the GameManager know there's one more collectable on the game
        GameManager.Instance.increaseTotalCollectableItens();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.increaseCollectableScore();
            Destroy(gameObject);
        }
    }

}
