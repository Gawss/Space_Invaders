using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Text m_scoreTxt;
    [SerializeField] private Text m_finalScoreTxt;
    [SerializeField] private GameObject m_pauseMenu;
    [SerializeField] private GameObject m_gameOverMenu;
    [SerializeField] private GameObject m_shipPicker = null;
    [SerializeField] private List<Color32> m_backgroundColors = null;
    [SerializeField] private GameObject m_mainMenu = null;
    [SerializeField] private GameObject m_gameUI = null;

    public void ShowGameOver(bool show, int color_){
        m_gameOverMenu.GetComponentInChildren<Image>().color = m_backgroundColors[color_];
        m_gameOverMenu.SetActive(show);
        m_finalScoreTxt.text = "Final Score: " + m_scoreTxt.text;
    }

    public void ShowPause(bool show, int color_){
        m_pauseMenu.GetComponentInChildren<Image>().color = m_backgroundColors[color_];
        m_pauseMenu.SetActive(show);        
    }

    public void EnableShipPicker(bool enable){
        m_shipPicker.SetActive(enable);
    }

    #region Get&Set

    public Text scoreTxt { set {m_scoreTxt = scoreTxt;} get{return this.m_scoreTxt;}}
    public Text finalScoreTxt { set {m_finalScoreTxt = finalScoreTxt;} get{return this.m_finalScoreTxt;}}
    public GameObject pauseMenu { set {m_pauseMenu = pauseMenu;} get{return this.m_pauseMenu;}}
    public GameObject gameOverMenu { set {m_gameOverMenu = gameOverMenu;} get{return this.m_gameOverMenu;}}
    public GameObject mainMenu { get{return this.m_mainMenu;}}
    public GameObject gameUI { get{return this.m_gameUI;}}

    #endregion
}
