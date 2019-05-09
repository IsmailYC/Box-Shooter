using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonBehaviour : MonoBehaviour {
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PauseGame);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
