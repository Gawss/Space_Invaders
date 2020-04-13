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

    void Awake(){
        CalculateScreenDimensions();
    }

    /* 
        Screen Dimensions are used as limit for movement of:
        player, bullets, enemies and background
    */
    private void CalculateScreenDimensions(){
        m_screeDimension = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        m_screenBorder_Left = -m_screeDimension.x;
        m_screenBorder_Right = m_screeDimension.x;
        m_screenBorder_Top = m_screeDimension.y;
        m_screenBorder_Bottom = -m_screeDimension.y;
    }

    #region Get&Set

    public Vector3 screenDimension { set {m_screeDimension = screenDimension;} get{return this.m_screeDimension;}}
    public float screenBorder_Left { get {return this.m_screenBorder_Left;}}
    public float screenBorder_Right { get {return this.m_screenBorder_Right;}}
    public float screenBorder_Top { get {return this.m_screenBorder_Top;}}
    public float screenBorder_Bottom { get {return this.m_screenBorder_Bottom;}}

    #endregion
}
