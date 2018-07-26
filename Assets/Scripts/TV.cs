using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class TV : MonoBehaviour
    {

        public string tvOn;
        public string tvOff;
        private bool playing;
        public Sprite image;
        private AudioSource tvAudio;

        // Use this for initialization
        void Start()
        {
            tvAudio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayStop()
        {
            if (tvAudio.isPlaying == false)
            {
                playing = true;
                tvAudio.Play();
            }
            else
            {
                tvAudio.Stop();
                playing = false;
            }
        }

        public bool IsPlaying
        {
            get { return playing; }
        }
    }
}