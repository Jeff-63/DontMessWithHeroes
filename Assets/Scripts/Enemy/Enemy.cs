using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    readonly float Ennemi_Speed = 5;
    Rigidbody2D rb2D;

    public void Init()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    public void UpdateEnnemi(float dt)
    {
    }
    public void FixedUpdateEnnemi(float dt)
    {

    }
    public void MoveEnnemi()
    {
    }
    public void DeathEnnemi()
    {

    }
}
