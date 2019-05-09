using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButtonBehaviour : MonoBehaviour {
    public Sprite onSprite;
    public Sprite offSprite;

    Image image;
    Button button;
    bool status;
    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleAudio);
        status = PlayerPrefsManager.GetAudio();
        SetSprite();
    }

    private void ToggleAudio()
    {
        status = !status;
        PlayerPrefsManager.SetAudio(status);
        SetSprite();
    }

    private void SetSprite()
    {
        if (status)
            image.sprite = onSprite;
        else
            image.sprite = offSprite;
    }
}
