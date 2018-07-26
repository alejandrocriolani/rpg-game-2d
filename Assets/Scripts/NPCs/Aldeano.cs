using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace RPG
{
    public class Aldeano : NpcBase
    {

        public string ficheroDialogo;
        private FileStream file;
        private XmlSerializer xmlSerializer;
        private Dialogo dialogo;

        // Use this for initialization
        protected override void Start()
        {
            string dialoguePath = Application.dataPath;
            dialoguePath = dialoguePath + "/Dialogos/" + ficheroDialogo;
            file = new FileStream(dialoguePath, FileMode.Open, FileAccess.Read);
            xmlSerializer = new XmlSerializer(typeof(Dialogo));
            dialogo = (Dialogo)xmlSerializer.Deserialize(file);
            //Debug.Log(dialoguePath);
        }

        // Update is called once per frame
        protected override void Update()
        {

        }

        public Dialogo Conversacion
        {
            get { return dialogo; }
        }
    }
}

