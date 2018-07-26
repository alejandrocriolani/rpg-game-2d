using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RPG
{
    public class DialogueBox : MonoBehaviour
    {
        private GameObject dialogueBox;
        public Sprite playerPicture;
        private Image dialoguePicture;
        private Sprite npcPicture;
        private Text dialogueText;
        private Dialogo dialogo;
        private DialogueSystem ds;
        private PlayerMovement pm;
        private TV tvScript;

        // Use this for initialization
        void Start()
        {
            pm = GetComponentInParent<PlayerMovement>();
            SearchDialogueBox();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "aldeano")
                AldeanoEnter(collision);
            if (collision.tag == "tv")
                TvEnter(collision);
            //if (collision.tag == "cartel")
            //    CartelEnter(collision);

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "aldeano")
                AldeanoStay(collision);
            if (collision.tag == "cartel")
                CartelStay(collision);
            if (collision.tag == "tv")
                TvStay(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "aldeano")
                AldeanoExit(collision);
            if (collision.tag == "cartel")
                CartelExit();
            if (collision.tag == "tv")
                TvExit();
        }

        void AldeanoEnter(Collider2D collision)
        {
            Aldeano aldeanoScript = collision.GetComponent<Aldeano>();
            if (aldeanoScript == null) Debug.Log("Aldeano Script = null");
            npcPicture = aldeanoScript.image;
            dialogo = aldeanoScript.Conversacion;
            ds = new DialogueSystem(dialogo.oradores, dialogo.conversaciones, dialogo.ordOradores);
        }

        void AldeanoStay(Collider2D collision)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                pm.AlowMove = false;
                dialogueBox.SetActive(true);
                if (!ds.FinDelMensaje())
                {
                    if (ds.ObtenerEmisor() == "Yo")
                        dialoguePicture.sprite = playerPicture;
                    else
                        dialoguePicture.sprite = npcPicture;
                    dialogueText.text = ds.ObtenerEmisor() + ": " + ds.ObtenerMensaje();
                    ds.SiguienteMensaje();
                }
                else
                {
                    dialogueBox.SetActive(false);
                    ds.Restart();
                    pm.AlowMove = true;
                }
            }
        }

        void AldeanoExit(Collider2D collision)
        {
            dialogueBox.SetActive(false);
            dialoguePicture.sprite = playerPicture;
        }

        public void SearchDialogueBox()
        {
            if (dialogueBox == null)
            {
                dialogueBox = GameObject.Find("DialogueBox");

                if (dialogueBox != null)
                {
                    dialogueBox.SetActive(false);
                    dialogueText = dialogueBox.GetComponentInChildren<Text>();
                    Image[] imgs = dialogueBox.GetComponentsInChildren<Image>();

                    foreach (Image img in imgs)
                    {
                        if (img.name == "NPCBoxGround")
                            dialoguePicture = img;
                    }
                }
            }
            Debug.Log(dialogueBox);
        }

        void CartelEnter(Collider2D collision)
        {
            Debug.Log("Cartel detectado");
            Cartel cartel = collision.GetComponent<Cartel>();
            dialoguePicture.sprite = cartel.image;
            dialogueText.text = cartel.text;
        }

        void CartelStay(Collider2D collision)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Cartel cartel = collision.GetComponent<Cartel>();
                dialoguePicture.sprite = cartel.image;
                dialogueText.text = cartel.text;
                Debug.Log("Ver cartel / Dejar de ver cartel");
                if (pm.AlowMove == true)
                {
                    pm.AlowMove = false;
                    dialogueBox.SetActive(true);
                }
                else
                {
                    pm.AlowMove = true;
                    dialogueBox.SetActive(false);
                }
            }
        }

        void CartelExit()
        {
            dialogueBox.SetActive(false);
            dialoguePicture.sprite = playerPicture;
        }

        void TvEnter(Collider2D collision)
        {
            tvScript = collision.GetComponent<TV>();
            dialoguePicture.sprite = tvScript.image;
            //dialogueText.text = tvScript.tvOn;
        }

        void TvStay(Collider2D collision)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                tvScript.PlayStop();
                if (tvScript.IsPlaying == true)
                    dialogueText.text = tvScript.tvOn;
                else
                    dialogueText.text = tvScript.tvOff;
                dialogueBox.SetActive(true);
            }
        }

        void TvExit()
        {
            dialogueBox.SetActive(false);
        }
    }
}

