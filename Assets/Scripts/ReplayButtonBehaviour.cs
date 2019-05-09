using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour {
    Button button;
    string scene;
    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ReloadScene);
        scene= SceneManager.GetActiveScene().name;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(name);
    }
}
