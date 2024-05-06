using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPickups : MonoBehaviour {

    [SerializeField] private float healthUp = 0;
    [SerializeField] private float fuelUp = 0;
    [SerializeField] private int ammoUp = 0;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("player")) {

            if (healthUp > 0) {
                if (collision.gameObject.TryGetComponent(out PlayerMain player)) {
                    player.UpdateHealth(healthUp);
                    GameUIManager.ShowNotification("Health Up!");
                }
            } else if (ammoUp > 0) {
                if (collision.gameObject.TryGetComponent(out PlayerMain player)) {
                    GameUIManager.ShowNotification("Ammo Up!");
                    player.UpdateAmmo(ammoUp);
                }
            } else if (fuelUp > 0) {
                if (collision.gameObject.TryGetComponent(out PlayerMain player)) {
                    GameUIManager.ShowNotification("Fuel Up!");
                    player.UpdateFuel(fuelUp);
                }
            }

            Destroy(gameObject);
        }
    }

}
