using UnityEngine;
using System.Collections;

namespace RPG
{
    public class DontDestroy : MonoBehaviour
    {

        private static bool exist = false;

        // Use this for initialization
        void Start()
        {
            if (!exist)
            {
                exist = true;
                DontDestroyOnLoad(transform.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}


