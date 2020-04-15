using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float speed = 0.05f;

    #if !UNITY_EDITOR && UNITY_WEBGL
        void Start(){
            WebGLInput.captureAllKeyboardInput = true;
        }
    #endif

    public Vector2 GetMovementInputs()
    {
        Vector3 direction = Vector3.zero;
        if (SystemInfo.supportsAccelerometer)
        {
            direction.x = -Input.acceleration.y;
            direction.z = Input.acceleration.x;

            direction *= (Time.deltaTime * speed);
            return new Vector2(direction.x, direction.z);
        }
        direction.x =  Input.GetAxis("Horizontal");
        direction.y =  Input.GetAxis("Vertical");
        return new Vector2(direction.x, direction.y);
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
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
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
