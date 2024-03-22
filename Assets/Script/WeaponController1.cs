using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController1 : MonoBehaviour
{
    [SerializeField] private float shootCooldown;
    public float magazine;
    public Transform firePoint;
    public GameObject ammoType;

    public float shotSpeed;
    public float shotCounter, fireRate;
    private float cooldownTimer = Mathf.Infinity;

    private Animator playerAnim;
    public GameObject nothing;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magazine <= 0)
        {
            WeaponSwap weaponSwap = gameObject.GetComponent<WeaponSwap>();
            weaponSwap.UpdateWeapon(nothing);
            Destroy(GameObject.FindGameObjectWithTag("W1"));
            Destroy(gameObject);
        }
        if (Input.GetKey(KeyCode.J) && cooldownTimer > shootCooldown)
        {

            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shoot();
                magazine--;
            }
            playerAnim.SetTrigger("Shot");

        }
        cooldownTimer += Time.deltaTime;

    }
    void Shoot()
    {
        cooldownTimer = 0;

        int playerDir()
        {
            if (transform.root.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
        Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
        shotRB.AddForce(firePoint.right * shotSpeed * playerDir(), ForceMode2D.Impulse);
        Destroy(shot.gameObject, 0.5f);
    }
}
