using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    CombatUI cmbtUI;

    public void Init()
    {
        cmbtUI = CombatFlow.gl.CombatUiCanvas.GetComponent<CombatUI>();
        cmbtUI.Initialize();
    }

    public void Update(float dt)
    {
        cmbtUI.UpdateUI(dt);
    }

}
