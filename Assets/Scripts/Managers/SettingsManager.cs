using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    #region Screen Variables
    private Vector3 m_screeDimension;
    private float m_screenBorder_Left;
    private float m_screenBorder_Right;
    private float m_screenBorder_Top;
    private float m_screenBorder_Bottom;

    #endregion

    #if !UNITY_EDITOR && UNITY_WEBGL

    void Awake(){
        CalculateScreenDimensions();
    }

    /* 
        Screen Dimensions are used as limit for movement of:
        player, bullets, enemies and background
    */
    private void CalculateScreenDimensions(){
        GameObject[] borders = GameObject.FindGameObjectsWithTag("Border");
        foreach(GameObject border in borders){
            if(border.name == "Left") m_screenBorder_Left = border.transform.position.x;
            if(border.name == "Right") m_screenBorder_Right = border.transform.position.x;
            if(border.name == "Top") m_screenBorder_Top = border.transform.position.y;
            if(border.name == "Bottom") m_screenBorder_Bottom = border.transform.position.y;
        }
    }
    #endif

    #if UNITY_EDITOR
    
    void Awake(){
        CalculateScreenDimensions();
    }

    private void CalculateScreenDimensions(){
        m_screeDimension = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        m_screenBorder_Left = -m_screeDimension.x;
        m_screenBorder_Right = m_screeDimension.x;
        m_screenBorder_Top = m_screeDimension.y;
        m_screenBorder_Bottom = -m_screeDimension.y;
    }

    #endif

    #region Get&Set

    public float screenBorder_Left { get {return this.m_screenBorder_Left;}}
    public float screenBorder_Right { get {return this.m_screenBorder_Right;}}
    public float screenBorder_Top { get {return this.m_screenBorder_Top;}}
    public float screenBorder_Bottom { get {return this.m_screenBorder_Bottom;}}

    #endregion
}
