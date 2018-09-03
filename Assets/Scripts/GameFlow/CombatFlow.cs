using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flux de combat
public class CombatFlow : Flow
{

    UIManager uiManagerPlayer, uiManagerEnemy;
    BaseCharacterClass bcc;
    Player p;
    Enemy e;

    public override void InitializeFlow() //initialisation de tous éléments du flux
    {
        base.InitializeFlow();
        uiManagerPlayer = new UIManager();
        uiManagerEnemy = new UIManager();
        bcc = new BaseCharacterClass();
        p = new Player();
        e = new Enemy();
    }

    //Update de tous éléments du flux
    public override void Update(float dt)
    {
        base.Update(dt);
        uiManagerPlayer.GetUIPkg(p.bcc.CreaterUIPkg());
        uiManagerEnemy.GetUIPkg(e.bcc.CreaterUIPkg());
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
