using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState
{
    BaseCharacterClass enemy, player;


    public void InitEnemy(CharacterClasses enemyClass) // initialise le bon type d'ennemi selon la collision
    {
        if (enemy.characterClass == CharacterClasses.Orc) // ne sinitialise pas avec lennemi par defaut --- 

        #region probleme lorsque lon rentre en combat
       // NullReferenceException: Object reference not set to an instance of an object
       //  StartState.InitEnemy(CharacterClasses enemyClass)(at Assets / Scripts / Combat / StartState.cs:12)
       //  CombatStateMachine.Update()(at Assets / Scripts / Combat / CombatStateMachine.cs:38)
            #endregion
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
    public bool PlayerGoesFirst(Enemy enemy, Player player) // determine qui attaque en premier
    {
        bool playerGoesFirst = false;

        if (enemy.bcc.agility <= player.bcc.agility)
        {
            playerGoesFirst = true;
        }

        return playerGoesFirst;
    }

}
