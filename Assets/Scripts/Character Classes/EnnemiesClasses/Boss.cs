using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : BaseCharacterClass {

    public Boss()
    {
        characterClass = "Boss";
        characterClassDescription = "";// need to find skeleton enemy description

        characterLevel = 5;
        experience = 500; //enemy experience is the experience that is grant to the player if he kills it
        strenght = 20;
        endurance = 20;
        agility = 12;
        intelligence = 14;
        currentHP = 300;
        maxHP = 300;
    }
}

