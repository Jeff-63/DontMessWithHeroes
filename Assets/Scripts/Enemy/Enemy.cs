using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    readonly float Ennemi_Speed = 5;
    Rigidbody2D rb2D;
    public BaseCharacterClass bcc;
    bool isOrc = true; // les orcs et elementaux seront random --- test value en attendant
    bool isBoss = false;
    int orc = 1;
    int elemental = 2;
    int random;
    CharacterClasses enemyClass;

    public void Init()
    {
        rb2D = GetComponent<Rigidbody2D>();
        int random = Random.Range(orc, elemental);
        // peut etre utiliser un switch pour code plus propre
        if (random == orc)
        {
            bcc = new Orc();
        }
        else
        {
            bcc = new Elemental();
        }
        if (isBoss == true)
        {
            bcc = new Boss();
        }


    }
    public void UpdateEnnemi(float dt)
    {
        SaveEnemy();
    }
    public void FixedUpdateEnnemi(float dt)
    {

    }
    public void MoveEnnemi()
    {
    }
    public CharacterClasses GetEnemyClass(Enemy enemy)
    {
        enemyClass = this.bcc.characterClass;

        return enemyClass;
    }
    public void DeathEnnemi()
    {

    }
    public void SaveEnemy()
    {
        OmniEnemy.Instance.characterLevel = bcc.characterLevel;
        OmniEnemy.Instance.experience = bcc.experience;
        OmniEnemy.Instance.maxExperience = bcc.maxExperience;
        OmniEnemy.Instance.strenght = bcc.strenght;
        OmniEnemy.Instance.endurance = bcc.endurance;
        OmniEnemy.Instance.intelligence = bcc.intelligence;
        OmniEnemy.Instance.agility = bcc.agility;
        OmniEnemy.Instance.currentHP = bcc.currentHP;
        OmniEnemy.Instance.maxHP = bcc.maxHP;
        OmniEnemy.Instance.currentMana = bcc.currentMana;
        OmniEnemy.Instance.maxMana = bcc.maxMana;
    }
}
