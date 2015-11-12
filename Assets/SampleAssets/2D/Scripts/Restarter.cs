using UnityEngine;

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
}
