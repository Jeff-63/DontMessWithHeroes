using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flux de combat
public class CombatFlow : Flow{

    UIManager uiManager;

    public override void InitializeFlow() //initialisation de tous éléments du flux
    {
        base.InitializeFlow();
        uiManager = new UIManager();
    }

    //Update de tous éléments du flux
    public override void Update(float dt)
    {
        base.Update(dt);
        uiManager.GetUIPkg()
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
