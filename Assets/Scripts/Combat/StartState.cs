using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState
{


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
