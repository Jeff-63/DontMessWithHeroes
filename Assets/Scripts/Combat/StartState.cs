using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState
{
    BaseCharacterClass enemy, player;


    public void PrepareBattle()
    {

    }
    public void InitEnemy(CharacterClasses enemyClass)
    {
        if (enemy.characterClass == CharacterClasses.Orc)
        {
            enemy = new Orc();
        }
        else if (enemy.characterClass == CharacterClasses.Elemental)
        {
            enemy = new Elemental();
        }
        else
        {
            enemy = new Boss();
        }
    }
    public bool PlayerGoesFirst() // determine qui attaque en premier
    {
        bool playerGoesFirst = false;

        if (enemy.agility <= player.agility)
        {
            playerGoesFirst = true;
        }


        return playerGoesFirst;
    }

}
