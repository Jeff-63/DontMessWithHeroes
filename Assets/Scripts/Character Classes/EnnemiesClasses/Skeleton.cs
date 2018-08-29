using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : BaseCharacterClass
{

    public Skeleton()
    {
        characterClass = "Skeleton";
        characterClassDescription = "";// need to find skeleton enemy description

        characterLevel = 1;
        experience = 25; //enemy experience is the experience that is grant to the player if he kills it
        strenght = 12;
        endurance = 12;
        agility = 12;
        intelligence = 5;
        currentHP = 80;
        maxHP = 80;
    }
}
