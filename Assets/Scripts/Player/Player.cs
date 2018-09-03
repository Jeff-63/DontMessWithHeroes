using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly float Player_Speed = 5;
    InputManager inputManager;
    Rigidbody2D rb2D;
    public BaseCharacterClass bcc;
    bool isWarrior = true; // choix qui sera fait au main menu --- test value en attendant

    Enemy enemy;
    public CharacterClasses enemyType;

    public void Init()
    {
        inputManager = new InputManager();
        rb2D = GetComponent<Rigidbody2D>();
        //classe du player selon le choix .... pour linstant 1 = guerrier, 2 = mage;
        if (isWarrior)
        {
            bcc = new Warrior();
        }
        else
        {
            bcc = new WizardClass();
        }

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

    private CharacterClasses OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ennemi")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemyType = enemy.GetEnemyClass(enemy);

            Application.LoadLevel("CombatScene");

        }
        else
        {
            enemyType = CharacterClasses.NA;
        }

        return enemyType;
    }
}
