using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG
{
    public class ChangeMap : MonoBehaviour
    {
        public string nombreEscena;
        public Vector2 coordenadasSiguienteNivel;
        //private GameObject startPoint;
        //private GameObject userInterface;
        // Use this for initialization

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("Change Map");
                DontDestroyOnLoad(collision.gameObject);
                PlayerStart ps = collision.gameObject.GetComponent<PlayerStart>();
                ps.CoorNextLevel = coordenadasSiguienteNivel;
                SceneManager.LoadScene(nombreEscena);
            }
        }
    }
}

