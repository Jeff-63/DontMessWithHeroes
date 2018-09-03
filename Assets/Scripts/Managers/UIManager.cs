using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{

    UILinks uiLinks;

    public UIManager()
    {
        uiLinks = GameObject.FindObjectOfType<UILinks>();
    }

    public void GetUIPkg(UIpkg uiPkg)
    {
        uiLinks.hpBar.fillAmount = uiPkg.currentHP / uiPkg.maxHP;
        uiLinks.manaBar.fillAmount = uiPkg.currentMana / uiPkg.maxMana;
    }

    public class UIpkg
    {
        public int characterLevel, experience, maxExperience, strenght, endurance, intelligence, agility, currentHP, maxHP, currentMana, maxMana;

        public UIpkg(int _characterLevel,int _experience,int _maxExperience, int _strenght, int _endurance, int _intelligence, int _agility, int _currentHP, int _maxHP, int _currentMana, int _maxMana)
        {
            characterLevel = _characterLevel;
            experience = _experience;
            maxExperience = _maxExperience;
            strenght = _strenght;
            endurance = _endurance;
            intelligence = _intelligence;
            agility = _agility;
            currentHP = _currentHP;
            maxHP = _maxHP;
            currentMana = _currentMana;
            maxMana = _maxMana;
        }
        public override string ToString()
        {
            return string.Format("HP {0}, Mana {1}", currentHP, currentMana);
        }
    }

}
