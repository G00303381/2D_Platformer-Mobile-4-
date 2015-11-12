using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

    public int offsetX = 2;
    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;
    public bool reverseScale = false;

    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

	// Use this for initialization
	void Start ()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hasALeftBuddy == false || hasARightBuddy == false)
        {
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
            float edgeVisiblePosRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePosLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

            if (cam.transform.position.x >= edgeVisiblePosRight - offsetX && hasARightBuddy == false)
            {
                makeNewBuddy(1);
                hasARightBuddy = true;
            }

            else if (cam.transform.position.x <= edgeVisiblePosLeft + offsetX && hasALeftBuddy == false)
            {
                makeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }
	}

    void makeNewBuddy(int direction) 
    {
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * direction, 
            myTransform.position.y, myTransform.position.z);
       Transform newBuddy =  (Transform)Instantiate(myTransform, newPosition, myTransform.rotation);

        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;

        if (direction > 0)
        {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
        }

        else
        {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }


}
