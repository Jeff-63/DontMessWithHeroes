using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager
{
    CombatUI cmbtUI;

    public void Init()
    {
        cmbtUI = CombatFlow.cl.cUI;
        cmbtUI.Initialize();
    }

    public void Update(float dt)
    {
        cmbtUI.UpdateUI(dt);
    }

}
