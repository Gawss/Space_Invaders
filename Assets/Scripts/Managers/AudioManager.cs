using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_lose = null;
    [SerializeField] private AudioClip m_normalAttack = null;
    [SerializeField] private AudioClip m_enemyDeath = null;
    [SerializeField] private AudioClip m_shield = null;

    private AudioSource m_audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayClip(AudioClip audio_){
        m_audioSource.clip = audio_;
        m_audioSource.Play();
    }

    #region Get&Set

    public AudioSource audioSource {get{return this.m_audioSource;}}
    public AudioClip lose {get{return this.m_lose;}}
    public AudioClip normalAttack {get{return this.m_normalAttack;}}
    public AudioClip enemyDeath {get{return this.m_enemyDeath;}}
    public AudioClip shield {get{return this.m_shield;}}

    #endregion
}
