using UnityEngine;
using System.Collections;

public class GyroCamera : MonoBehaviour {
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;

    Gyroscope gyro;

    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.gm.gameState == GameManager.GameState.play)
            transform.Rotate(-XSensitivity*Input.gyro.rotationRateUnbiased.x, -YSensitivity*Input.gyro.rotationRateUnbiased.y, 0);
	}
}
