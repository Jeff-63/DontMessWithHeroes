using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    readonly float Player_Speed_Test = 2;
    InputManager inputManager;
    Rigidbody2D rb2D;
    
    public void Init()
    {
        inputManager = new InputManager();
        rb2D = GetComponent<Rigidbody2D>();
    }
    public void UpdatePlayer()
    {
        InputManager.InputPkg inputPkg = inputManager.GetKeysPressed();
        Debug.Log("inputPkg: " + inputPkg);
        MovePlayer(inputPkg.directionPressed);
    }
    public void FixedUpdatePlayer()
    {

    }
    public void MovePlayer(Vector2 direction)
    {
        rb2D.velocity = direction.normalized * Player_Speed_Test; // need to test if its to slow and we need to add a player speed
    }
    public void DeathPlayer()
    {

    }
}
