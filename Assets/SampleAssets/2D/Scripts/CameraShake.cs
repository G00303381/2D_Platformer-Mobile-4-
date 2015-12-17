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
<<<<<<< HEAD
            camPos.x = offsetX;
            camPos.y = offsetY;
            camPos.z = 0f;
=======
            camPos.x += offsetX;
            camPos.y += offsetY;
>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5

            mainCam.transform.position = camPos;
        }
    }

    void stopShake()
    {
        CancelInvoke("startShake");
        mainCam.transform.localPosition = Vector3.zero;
    }

}
