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
        Debug.Log("Package : " + uiPkg.ToString());
        uiLinks.hpBar.fillAmount = uiPkg.currentHP / uiPkg.maxHP;
        uiLinks.manaBar.fillAmount = uiPkg.currentMana / uiPkg.maxMana;
    }

    public class UIpkg
    {
        public float currentHP, maxHP, currentMana, maxMana;

        public UIpkg(float _currentHP, float _maxHP, float _currentMana, float _maxMana)
        {
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
