using UnityEngine.UI;
using UnityEngine;

namespace YsoCorp {

    public  class MenuWin : AMenu {

        public Button bNext;
        public Transform players;
        public grapleGun grapleGunn;

        void Start() {
            this.bNext.onClick.AddListener(() => {
                this.game.state = Game.States.Home;
                Transform spot = this.game.map.GetStartingPos();
                this.players.position = spot.position;
                this.players.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                this.grapleGunn.StopGrapple();
                this.ycManager.adsManager.ShowInterstitial(() => {
                    this.game.state = Game.States.Home;
                });
            });
        }

    }

}
