using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseCharacterClass {

    public Ghost()
    {
        characterClass = "Ghost";
        characterClassDescription = "";// need to find ghost enemy description

        characterLevel = 1;
        experience = 25; //enemy experience is the experience that is grant to the player if he kills it
        strenght = 3;
        endurance = 10;
        agility = 10;
        intelligence = 14;
        currentHP = 80;
        maxHP = 80;
    }
}
