using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public class Spawner : MonoBehaviour
{
    private bool m_isEnabled = false;
    [SerializeField] private float m_spawnFrequency = 5;

    void Start()
    {
        m_isEnabled = true;
    }
    public IEnumerator SpawnEnemies(){
        
        m_isEnabled = false;
        m_spawnFrequency = Mathf.Max(0.5f, 2/(GlobalManager.Instance.GameManager().currentLevel+1));

        yield return new WaitForSeconds(m_spawnFrequency);

        int randNumber = Random.Range(0, Mathf.Min(4, GlobalManager.Instance.GameManager().currentLevel +1));
        GameObject enemy = GlobalManager.Instance.GameManager().enemiesPool.GetObjectByTag("Enemy", randNumber);
        
        Vector3 randomPosition = new Vector3(Random.Range(GlobalManager.Instance.SettingsManager().screenBorder_Left+0.5f, GlobalManager.Instance.SettingsManager().screenBorder_Right-0.5f), 0, 0);
        enemy.transform.position = transform.position + randomPosition;
        m_isEnabled = true;
    }

    #region Get&Set

    public bool isEnabled { set {m_isEnabled = isEnabled;} get{return this.m_isEnabled;}}
    public float spawnFrequency { set {m_spawnFrequency = spawnFrequency;} get{return this.m_spawnFrequency;}}

    #endregion
}
