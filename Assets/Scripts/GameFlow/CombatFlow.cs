using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flux de combat
public class CombatFlow : Flow{

    UIManager uiManager;
    BaseCharacterClass bcc;

    public override void InitializeFlow() //initialisation de tous éléments du flux
    {
        base.InitializeFlow();
        uiManager = new UIManager();
        bcc = new BaseCharacterClass();
    }

    //Update de tous éléments du flux
    public override void Update(float dt)
    {
        base.Update(dt);
       uiManager.GetUIPkg(bcc.CreaterUIPkg());
    }

    //FixedUpdate de tous éléments du flux
    public override void FixedUpdate(float dt)
    {
        base.FixedUpdate(dt);
    }

    //Fermeture du flux
    public override void EndFlow()
    {
        base.EndFlow();
    }
}
