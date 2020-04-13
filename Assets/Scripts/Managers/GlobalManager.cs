using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{
    public class GlobalManager : MonoBehaviour
    {
        /* Singleton to allow communication between Managers */
        private static GlobalManager instance;
        public static GlobalManager Instance { get { return instance; }}

        #region Managers

        private SettingsManager settingsManager;
        private GameManager gameManager;
        private AudioManager audioManager;

        #endregion

        
        private void Awake()
        {
            // Only one GlobalManager can exist on scene
            if (instance == null) {
                instance = this;
            } else {
                Destroy(this.gameObject);
                return;
            }
            DontDestroyOnLoad(this.gameObject);

            // Get Managers from this object
            settingsManager = GetComponent<SettingsManager>();
            gameManager = GetComponent<GameManager>();
            audioManager = GetComponent<AudioManager>();
        }

        #region Get&Set

        public SettingsManager SettingsManager() { return this.settingsManager;}
        public GameManager GameManager() { return this.gameManager;}
        public AudioManager AudioManager() { return this.audioManager;}

        #endregion
    }
}
