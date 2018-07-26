using System;

namespace RPG
{
    [Serializable]
    public class Dialogo
    {
        private string m_ocfVersion;
        private int m_cantOradores;
        private string[] m_oradores;
        private int m_cantConv;
        private int[] m_quienDialoga;
        private string[] m_conversaciones;

        public Dialogo()
        {
            m_cantConv = 0;
            m_cantOradores = 0;
        }

        public string ocfVersion
        {
            get { return m_ocfVersion; }
            set { m_ocfVersion = value; }
        }

        public string[] oradores
        {
            get { return m_oradores; }
            set
            {
                m_oradores = value;
                m_cantOradores = value.Length;
            }
        }

        public int cantOradores
        {
            get { return m_cantOradores; }
        }

        public int[] ordOradores
        {
            get { return m_quienDialoga; }
            set { m_quienDialoga = value; }
        }

        public string[] conversaciones
        {
            get { return m_conversaciones; }
            set
            {
                m_conversaciones = value;
                m_cantConv = value.Length;
            }
        }

        public int cantConversaciones
        {
            get { return m_cantConv; }
        }

    }
}


