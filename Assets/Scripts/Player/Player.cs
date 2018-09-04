using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    readonly float Player_Speed = 150;
    InputManager inputManager;
    Rigidbody2D rb2D;
    Animator anim;
    public BaseCharacterClass bcc;
    bool isWarrior = true; // choix qui sera fait au main menu --- test value en attendant
    bool isWalking = false;
    bool isIdle = true;

    Enemy enemy;
    public CharacterClasses enemyType;

    public void Init()
    {
        inputManager = new InputManager();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //classe du player selon le choix .... pour linstant 1 = guerrier, 2 = mage;

        if (isWarrior)
        {
            bcc = new Warrior();
        }
        else
        {
            bcc = new WizardClass();
        }

        if (bcc != null && OmniPlayer.Instance != null)
        {
             bcc.characterLevel = OmniPlayer.Instance.characterLevel;
             bcc.experience = OmniPlayer.Instance.experience;
             bcc.maxExperience = OmniPlayer.Instance.maxExperience;
             bcc.strenght = OmniPlayer.Instance.strenght;
             bcc.endurance = OmniPlayer.Instance.endurance;
             bcc.intelligence = OmniPlayer.Instance.intelligence;
             bcc.agility = OmniPlayer.Instance.agility;
             bcc.currentHP = OmniPlayer.Instance.currentHP;
             bcc.maxHP = OmniPlayer.Instance.maxHP;
             bcc.currentMana = OmniPlayer.Instance.currentMana;
             bcc.maxMana = OmniPlayer.Instance.maxMana;
        }

    }

    public void UpdatePlayer(float dt)
    {
        InputManager.InputPkg inputPkg = inputManager.GetKeysPressed();

        MovePlayer(inputPkg.directionPressed, dt);

    }

    public void FixedUpdatePlayer()
    {

    }

    public void MovePlayer(Vector2 direction, float dt)
    {
        rb2D.velocity = direction.normalized * (Player_Speed*dt); 

        if (rb2D.velocity.x != 0 || rb2D.velocity.y != 0)
        {
            if (!isWalking)
            {
                anim.SetTrigger("Walk");
                isWalking = true;
                isIdle = false;
            }
        }
        else
        {
            if(!isIdle)
            {
                anim.SetTrigger("Idle");
                isWalking = false;
                isIdle = true;
            }
        }
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

            SavePlayer();
            SceneManager.LoadScene("CombatScene");

        }
        else
        {
            enemyType = CharacterClasses.NA;
        }

        return enemyType;
    }

    public void SavePlayer()
    {
        OmniPlayer.Instance.characterLevel = bcc.characterLevel;
        OmniPlayer.Instance.experience = bcc.experience;
        OmniPlayer.Instance.maxExperience = bcc.maxExperience;
        OmniPlayer.Instance.strenght = bcc.strenght;
        OmniPlayer.Instance.endurance = bcc.endurance;
        OmniPlayer.Instance.intelligence = bcc.intelligence;
        OmniPlayer.Instance.agility = bcc.agility;
        OmniPlayer.Instance.currentHP = bcc.currentHP;
        OmniPlayer.Instance.maxHP = bcc.maxHP;
        OmniPlayer.Instance.currentMana = bcc.currentMana;
        OmniPlayer.Instance.maxMana = bcc.maxMana;
    }
}
