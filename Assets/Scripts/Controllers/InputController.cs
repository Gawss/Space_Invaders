using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float inputValue_horizontal;
    private float inputValue_vertical;

    public Vector2 GetMovementInputs()
    {
        inputValue_horizontal =  Input.GetAxis("Horizontal");
        inputValue_vertical =  Input.GetAxis("Vertical");
        
        return new Vector2(inputValue_horizontal, inputValue_vertical);
    }

    public bool GetAttackInput()
    {
        if(Input.GetButton("Fire1")){
            return true;
        }
        return false;
    }

    public bool GetPauseInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            return true;
        }
        return false;
    }

    public int GetSkinInputs(){
        
        int keyPressed = -1;
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            keyPressed = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            keyPressed = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            keyPressed = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            keyPressed = 3;
        }
        return keyPressed;
    }
}
