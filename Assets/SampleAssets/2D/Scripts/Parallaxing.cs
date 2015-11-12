using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    public Transform [] backgrounds;        //list of all the background and foreground elements
    private float[] parallaxScales;         //proportion to move the backgrounds by
    public float smoothing = 1f;
    private Transform cam;                  //Reference to the main camera
    private Vector3 previousCamPos;
	

    void  Awake()
    {
        //set-up camera reference
        cam = Camera.main.transform;
    }

    // Use this for initialization
	void Start ()
    {
        //store the previous frame, at the current frames camera position
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgrounTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgrounTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
	}
}
