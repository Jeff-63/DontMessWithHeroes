using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public void Initialize()
    {
        ChargerPlayerUI();
    }

    public void UpdateUI(float dt)
    {
        ChargerPlayerUI();
    }

    public void ChargerPlayerUI()
    {
        GameFlow.gl.level.text = "Level : " + OmniPlayer.Instance.characterLevel.ToString();
        GameFlow.gl.hp.text = "HP : " + OmniPlayer.Instance.currentHP.ToString() + " / " + OmniPlayer.Instance.maxHP.ToString();
        GameFlow.gl.strength.text = "Strength : " + OmniPlayer.Instance.strenght.ToString();
        GameFlow.gl.endurance.text = "Endurance : " + OmniPlayer.Instance.endurance.ToString();
        GameFlow.gl.intelligence.text = "Inteligence : " + OmniPlayer.Instance.intelligence.ToString();
        GameFlow.gl.agility.text = "Agility : " + OmniPlayer.Instance.agility.ToString();
        GameFlow.gl.experience.text = "Experience : "+OmniPlayer.Instance.experience.ToString() + " / " + OmniPlayer.Instance.maxExperience.ToString();
    }
}
