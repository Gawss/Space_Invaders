using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class GameManager : MonoBehaviour
{
    private bool m_startLevel;
    private int m_score;
    private bool m_isPaused;
    private bool m_isEnded;
    [SerializeField] private int m_currentLevel = 0;
    [SerializeField] private ObjectPooler m_enemiesPool;
    [SerializeField] private ObjectPooler m_bulletsPool;

    [SerializeField] private Texture2D m_cursorTexture = null;
    private CursorMode m_cursorMode = CursorMode.Auto;
    private Vector2 m_hotSpot = Vector2.zero;
    private GameObject player = null;
    private CanvasController canvasController = null;
    
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>().gameObject;
        player.GetComponent<SpriteRenderer>().enabled = false;
        canvasController = GameObject.FindObjectOfType<CanvasController>();
    }

    public void UpdateScore(int sum)
    {
        m_score += sum;
        canvasController.scoreTxt.text = m_score.ToString();
        LevelUp();
    }

    public void TogglePause(){        
        m_isPaused = !m_isPaused;
        Time.timeScale = m_isPaused?0.0f:1.0f;
        Cursor.visible = m_isPaused;
        canvasController.ShowPause(m_isPaused, player.GetComponent<Player>().currentSkin);
    }

    public void GameOver() {
        m_isEnded = true;
        m_startLevel = false;
        Time.timeScale = 0.0f;
        Cursor.visible = m_isEnded;
        canvasController.ShowGameOver(m_isEnded, player.GetComponent<Player>().currentSkin);
    }

    public void StartGame(){
        m_currentLevel=1;
        m_score = 0;
        canvasController.scoreTxt.text = m_score.ToString();
        m_startLevel = true;
        m_isEnded = false;
        canvasController.ShowGameOver(m_isEnded, player.GetComponent<Player>().currentSkin);
        Time.timeScale = 1.0f;
        Cursor.SetCursor(m_cursorTexture, m_hotSpot, m_cursorMode);
        Cursor.visible = false;
        foreach(Enemy enemy in m_enemiesPool.GetComponentsInChildren<Enemy>()){
            m_enemiesPool.ReleaseElement(enemy.gameObject);
        }
    }

    public void Play(){
        canvasController.mainMenu.SetActive(false);
        canvasController.gameUI.SetActive(true);
        player.GetComponent<SpriteRenderer>().enabled = true;
        StartGame();
    }

    public void LevelUp(){
        m_currentLevel = Mathf.FloorToInt(m_score/100);
    }

    #region Get&Set

    public bool startLevel { set {m_startLevel = startLevel;} get{return this.m_startLevel;}}
    public int currentLevel { set {m_currentLevel = currentLevel;} get{return this.m_currentLevel;}}
    public int score { set {m_score = score;} get{return this.m_score;}}
    public bool isPaused { set {m_isPaused = isPaused;} get{return this.m_isPaused;}}
    public bool isEnded { set {m_isEnded = isEnded;} get{return this.m_isEnded;}}
    public ObjectPooler enemiesPool { set {m_enemiesPool = enemiesPool;} get{return this.m_enemiesPool;}}
    public ObjectPooler bulletsPool { set {m_bulletsPool = bulletsPool;} get{return this.m_bulletsPool;}}

    #endregion
}
