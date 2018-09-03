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
}
