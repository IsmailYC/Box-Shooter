using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonBehaviour : MonoBehaviour {
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CloseGame);
    }

    private void CloseGame()
    {
        Application.Quit();
    }
}
