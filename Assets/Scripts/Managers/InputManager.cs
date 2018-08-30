using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager{

    public InputPkg GetKeysPressed()
    {
        InputPkg toRet = new InputPkg();

        float x = Input.GetAxis("Horizontal"); //récupération du déplacement Horizontal
        float y = Input.GetAxis("Vertical"); //récupération du déplacement Vertical
        bool spacePressed = Input.GetAxis("Jump") > 0; //Appuie sur la bar d'espace ?
        bool runButtonPressed = Input.GetAxis("Fire3") > 0; //Appuie sur la touche shift gauche ?

        //remplissage du package
        toRet.directionPressed = new Vector2(x, y);
        toRet.spaceBarPressed = spacePressed;
        toRet.runButtonPressed = runButtonPressed;

        return toRet;
    }

    //package contenant les informations des touches pressées
    public class InputPkg
    {
        public Vector2 directionPressed; //Direction
        public bool spaceBarPressed; //Appuie sur la barre d'espace
        public bool runButtonPressed; //Appuie sur la touche shift gauche

         public override string ToString() //surcharge de ToString()
         {
             return "direction pressed : " + directionPressed + ", spacebar pressed : " + spaceBarPressed + ", run button pressed : " + runButtonPressed;
         }
    }
}
