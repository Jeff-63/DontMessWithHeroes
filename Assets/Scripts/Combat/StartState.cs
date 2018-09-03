﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState
{
    BaseCharacterClass enemy, player;
    

    public void InitEnemy(CharacterClasses enemyClass) // initialise le bon type d'ennemi selon la collision
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
