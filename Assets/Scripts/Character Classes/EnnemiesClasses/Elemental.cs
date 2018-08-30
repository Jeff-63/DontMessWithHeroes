using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : BaseCharacterClass {

    public Elemental()
    {
        characterClass = "Elemental";
        characterClassDescription = "";

        characterLevel = 1;
        experience = 25; //enemy experience is the experience that is grant to the player if he kills it
        strenght = 3;
        endurance = 10;
        agility = 7;
        intelligence = 14;
        currentHP = 80;
        maxHP = 80;
    }
}
