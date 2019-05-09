using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButtonBehaviour : MonoBehaviour {
    public string scene;

    Button button;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);

	}

    void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
