using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class PlayerStart : MonoBehaviour
    {

        //private GameObject startPoint;
        [SerializeField]
        private Vector2 coorSiguienteNivel;

        private void Start()
        {
            //Debug.Log("Cambiar start point");
            //transform.position = coorSiguienteNivel;
        }

        public void ChangePosition()
        {
            transform.position = coorSiguienteNivel;
            Debug.Log("Cambiar start point");
        }

        public Vector2 CoorNextLevel
        {
            get { return coorSiguienteNivel; }
            set { coorSiguienteNivel = value; }
        }
    }
}
