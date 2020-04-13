using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class CanvasManager : MonoBehaviour
{
    private CanvasController canvasController;
    private Player player;

    void Start()
    {
        canvasController = GetComponent<CanvasController>();
        player = GameObject.FindObjectOfType<Player>();
        canvasController.scoreTxt.text = "0";
        canvasController.pauseMenu.SetActive(false);
        canvasController.gameOverMenu.SetActive(false);
    }
}