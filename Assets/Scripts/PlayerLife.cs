using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG
{
    public class PlayerLife : MonoBehaviour
    {

        private int basePlayerLife;
        [SerializeField]
        private int maxPlayerLife;
        [SerializeField]
        private int currentPlayerLife;
        private Image lifeFill;
        private Text lifeText;
        [SerializeField]
        private float fillAmount;
        [SerializeField]
        private float speedLerp;

        // Use this for initialization
        void Start()
        {
            CurrentLife = MaxLife = basePlayerLife = 22;
            SearchImageFillAndText();
            //lifeFill.fillAmount = 0f;
            speedLerp = 2f;
            fillAmount = CalculateFillValue(CurrentLife);
        }

        // Update is called once per frame
        void Update()
        {
            if (lifeFill != null && lifeText != null)
                HandleHealthBar();
            else
                SearchImageFillAndText();
        }

        float CalculateFillValue(int value)
        {
            return (1.0f / (float)maxPlayerLife) * (float)value;
        }

        void SearchImageFillAndText()
        {
            GameObject lifeFillGO = GameObject.Find("lifeFill");
            GameObject lifeTextGO = GameObject.Find("lifeText");

            if (lifeFillGO != null && lifeTextGO != null)
            {
                lifeFill = lifeFillGO.GetComponent<Image>();
                lifeText = lifeTextGO.GetComponent<Text>();
                string value = "" + CurrentLife + " / " + MaxLife;
                lifeText.text = value;
            }
        }

        private void HandleHealthBar()
        {
            if (fillAmount != lifeFill.fillAmount)
            {
                lifeFill.fillAmount = Mathf.Lerp(lifeFill.fillAmount, fillAmount, Time.deltaTime * speedLerp);
                //string value = "" + CurrentLife + " / " + MaxLife;
                //lifeText.text = value;
            }
        }

        public int CurrentLife
        {
            get { return currentPlayerLife; }
            set
            {
                currentPlayerLife = Mathf.Clamp(value, 0, maxPlayerLife);
                fillAmount = CalculateFillValue(currentPlayerLife);
            }
        }

        public int MaxLife
        {
            get { return maxPlayerLife; }
            set
            {
                if (value >= basePlayerLife)
                    maxPlayerLife = value;
                else
                    maxPlayerLife = basePlayerLife;
            }
        }
    }
}