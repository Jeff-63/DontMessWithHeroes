using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardClass : BaseCharacterClass {

	public WizardClass()
    {
        characterClass = CharacterClasses.Wizard;
        characterClassDescription = "Wizards are considered to be spellcasters who wield powerful spells, but are often physically weak as a trade-off.";

        characterLevel = 1;
        experience = 0;
        maxExperience = 100;
        strenght = 5;
        endurance = 12;
        intelligence = 17;
        agility = 9;
        currentHP = 100;
        maxHP = 100;
    }
}
