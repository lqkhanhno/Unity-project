using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponToGiveP1;
    public GameObject weaponToGiveP2;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player1")
        {
            weaponToGiveP2 = weaponToGiveP1;
            WeaponSwap weaponSwap = collider.gameObject.GetComponent<WeaponSwap>();
            if (weaponSwap.activeWeapon != weaponToGiveP1)
            {
                weaponSwap.UpdateWeapon(weaponToGiveP1);
                Destroy(GameObject.FindGameObjectWithTag("W1"));
                Destroy(gameObject);
            }
        }
        else if (collider.gameObject.tag == "Player2")
        {
            weaponToGiveP1 = weaponToGiveP2;
            WeaponSwap weaponSwap = collider.gameObject.GetComponent<WeaponSwap>();
            if (weaponSwap.activeWeapon != weaponToGiveP2)
            {
                weaponSwap.UpdateWeapon(weaponToGiveP2);
                Destroy(GameObject.FindGameObjectWithTag("W2"));
                Destroy(gameObject);
            }
        }
    }
}
