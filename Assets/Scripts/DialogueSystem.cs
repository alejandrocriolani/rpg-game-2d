using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class DialogueSystem
    {

        private string[] m_emisores;
        private string[] m_mensajes;
        private int[] m_ordenEmisor;
        private int mensajeActual;

        public DialogueSystem(string[] emisores, string[] mensajes, int[] ordenEmisor)
        {
            int menLen, ordEmLen;
            menLen = mensajes.Length; ordEmLen = ordenEmisor.Length;
            //Debug.Log("" + menLen + " " + ordEmLen);
            if (menLen == ordEmLen)
            {
                m_emisores = emisores;
                m_mensajes = mensajes;
                m_ordenEmisor = ordenEmisor;
                mensajeActual = 0;
            }
        }

        public bool FinDelMensaje()
        {
            return (mensajeActual == (m_ordenEmisor.Length));
        }

        public void SiguienteMensaje()
        {
            if (FinDelMensaje())
                return;
            mensajeActual++;
        }

        public string ObtenerMensaje()
        {
            if (!FinDelMensaje())
                return m_mensajes[mensajeActual];
            return "";
        }

        public string ObtenerEmisor()
        {
            if (!FinDelMensaje())
                return m_emisores[m_ordenEmisor[mensajeActual]];
            return "";
        }

        public void Restart()
        {
            mensajeActual = 0;
        }
    }
}
