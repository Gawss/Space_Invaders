using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class PlayerManager : MonoBehaviour
{

    #region Controllers

    private Player m_player;
    private InputController m_inputController;

    #endregion

    void Start()
    {
        m_player = gameObject.GetComponent<Player>();
        m_inputController = gameObject.GetComponent<InputController>();
    }


    void Update()
    {
        if(GlobalManager.Instance.GameManager().startLevel){
            m_player.Move(m_inputController.GetMovementInputs());
            
            if(m_inputController.GetAttackInput() && m_player.canAttack){
                m_player.NormalAttack();
                GlobalManager.Instance.AudioManager().PlayClip( GlobalManager.Instance.AudioManager().normalAttack);
            }

            if(m_inputController.GetPauseInput() && GlobalManager.Instance.GameManager().startLevel){
                GlobalManager.Instance.GameManager().TogglePause();
            }

            int newSkin = m_inputController.GetSkinInputs();
            if(newSkin != -1){
                m_player.ChangeShip(newSkin);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            GlobalManager.Instance.GameManager().GameOver();
            player.transform.position = player.initialPosition;
            GlobalManager.Instance.AudioManager().PlayClip(GlobalManager.Instance.AudioManager().lose);
        }
    }

    #region Get&Set

    public Player player {get{return this.m_player;}}
    public InputController inputController {get{return this.m_inputController;}}

    #endregion
}
