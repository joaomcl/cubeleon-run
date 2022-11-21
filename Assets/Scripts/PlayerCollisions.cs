using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum DomainColor
{
    None,
    Red,
    Blue
}

public class PlayerCollisions : MonoBehaviour
{

    Player player;
    PlayerController playerController;
    DomainColor currentDomainColor = DomainColor.None;

    void Start()
    {
        player = GetComponent<Player>();
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
            currentDomainColor = DomainColor.Red;
        else if (other.CompareTag("Blue"))
            currentDomainColor = DomainColor.Blue;

        if (other.CompareTag("Jumpable"))
        {
            player.canJump = true;

            if (!checkColorsMatch())
                GameManager.Instance.failed();
            else
                player.canJump = true;
        }

        if (other.CompareTag("GameOverZone"))
            GameManager.Instance.failed();

        if (other.CompareTag("RingRed"))
            if (!player.isRed)
                GameManager.Instance.failed();

        if (other.CompareTag("RingBlue"))
            if (player.isRed)
                GameManager.Instance.failed();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jumpable"))
            player.canJump = false;

        if (other.CompareTag("Red"))
            currentDomainColor = DomainColor.None;
        else if (other.CompareTag("Blue"))
            currentDomainColor = DomainColor.None;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("bateu");
        if (collision.collider.CompareTag("RingRed"))
            GameManager.Instance.failed();

        if (collision.collider.CompareTag("RingBlue"))
            GameManager.Instance.failed();
    }

    /** só deve ser chamada quando entra na zona de pulo */
    private bool checkColorsMatch()
    {
        return player.isRed
            ? currentDomainColor == DomainColor.Red
            : currentDomainColor == DomainColor.Blue;
    }
}
