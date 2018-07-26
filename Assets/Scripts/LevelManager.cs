using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class LevelManager : MonoBehaviour
    {
        private GameObject player;

        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
            PlayerStart ps = player.GetComponent<PlayerStart>();
            DialogueBox db = player.GetComponent<DialogueBox>();
            db.SearchDialogueBox();
            ps.ChangePosition();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
