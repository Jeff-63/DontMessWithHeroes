using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : BaseCharacterClass
{

    public Orc()
    {
        characterClass = "Orc";
        characterClassDescription = "";

        characterLevel = 1;
        experience = 25; //enemy experience is the experience that is grant to the player if he kills it
        strenght = 12;
        endurance = 12;
        agility = 9;
        intelligence = 5;
        currentHP = 80;
        maxHP = 80;
    }
}
