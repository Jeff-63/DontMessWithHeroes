using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState
{
    BaseCharacterClass enemy;


    //  public void InitEnemy(CharacterClasses enemyClass) // initialise le bon type d'ennemi selon la collision
    //  {
    //      if (enemy.characterClass == CharacterClasses.Orc) // ne sinitialise pas avec l'ennemi par defaut --- 
    //      {
    //          enemy = new Orc();
    //      }
    //      else if (enemy.characterClass == CharacterClasses.Elemental)
    //      {
    //          enemy = new Elemental();
    //      }
    //      else
    //      {
    //          enemy = new Boss();
    //      }
    //  }
    public bool PlayerGoesFirst(int enemyAgi, int playerAgi) // determine qui attaque en premier
    {
        bool playerGoesFirst = false;
   
            if (enemyAgi <= playerAgi)
            {
                playerGoesFirst = true;
            }

        return playerGoesFirst;
    }

}
