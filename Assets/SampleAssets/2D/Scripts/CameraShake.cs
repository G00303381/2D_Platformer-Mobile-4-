using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    public Camera mainCam;

    float shakeAmount = 0f;
    
    void Awake()
    {

        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    public void shake(float amnt, float length)
    {
        shakeAmount = amnt;
        InvokeRepeating("startShake", 0, 0.01f);
        Invoke("stopShake", length);

    }

    void startShake()
    {
        Vector3 camPos = mainCam.transform.position;

        if (shakeAmount > 0)
        {
            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void stopShake()
    {
        CancelInvoke("startShake");
        mainCam.transform.localPosition = Vector3.zero;
    }

}
