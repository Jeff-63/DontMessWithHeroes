using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly float Player_Speed = 5;
    InputManager inputManager;
    Rigidbody2D rb2D;
    BaseCharacterClass bcc;

    public void Init()
    {
        inputManager = new InputManager();
        rb2D = GetComponent<Rigidbody2D>();
        bcc = new BaseCharacterClass();
    }

    public void UpdatePlayer(float dt)
    {
        InputManager.InputPkg inputPkg = inputManager.GetKeysPressed();
        MovePlayer(inputPkg.directionPressed);
    }

    public void FixedUpdatePlayer()
    {

    }

    public void MovePlayer(Vector2 direction)
    {
        rb2D.velocity = direction.normalized * Player_Speed; // need to test if its to slow and we need to add a player speed
    }

    public void DeathPlayer()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ennemi")
        {
            Application.LoadLevel("CombatScene");
        }


    }
}
