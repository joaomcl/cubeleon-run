using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player player;
    
    void Start()
    {
        player = GetComponent<Player>();
        transform.Rotate(Vector3.forward * 3);
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.playerFailed)
            player.rigidBody.velocity = new Vector3(0, player.rigidBody.velocity.y, Mathf.Max(player.forwardSpeed, player.rigidBody.velocity.z));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (player.canJump)
                player.rigidBody.velocity = new Vector3(0, player.jumpSpeed, player.rigidBody.velocity.z);

        if (Input.GetKeyDown(KeyCode.X))
            if (!player.canJump)
                player.swapColor();

        if (Input.GetKeyDown(KeyCode.Return))
            GameManager.Instance.failed();
    }

}
