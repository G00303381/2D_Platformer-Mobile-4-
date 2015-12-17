<<<<<<< HEAD
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5

namespace UnitySampleAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Enemy")
                Application.LoadLevel(Application.loadedLevelName);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5
