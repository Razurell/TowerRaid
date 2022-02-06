using UnityEngine.UI;
using UnityEngine;

namespace YsoCorp {

    public  class MenuLose : AMenu {

        public Button bRetry;
        public Transform players;
        public grapleGun grapleGunn;

        void Start() {
            this.bRetry.onClick.AddListener(() => {
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
