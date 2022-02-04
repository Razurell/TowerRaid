using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YsoCorp
{
    public class GameUI : MonoBehaviour
    {
        public Button grappleBtn;

        void Start()
        {
            this.grappleBtn.onClick.AddListener(() =>
            {
                //this.ycManager.settingManager.Show();
            });
        }

        void Update()
        {

        }
    }
}
