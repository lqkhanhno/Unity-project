using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWPController : MonoBehaviour
{
    [SerializeField] private float shootCooldown;

    public Transform firePoint;
    public GameObject ammoType;
    public float shotSpeed;
    public float shotCounter, fireRate;
    private float cooldownTimer = Mathf.Infinity;
    public GameObject nothing;
    public float magazine;

    private Animator playerAnim;
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
            Destroy(GameObject.FindGameObjectWithTag("W2"));
            Destroy(gameObject);
        }
        if (Input.GetKey(KeyCode.Keypad1) && cooldownTimer > shootCooldown)
        {
            playerAnim.SetBool("Shot", true);
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shoot();
                magazine--;

            }
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
                return 1;
            }
            else
            {
                return -1;
            }
        }
        playerAnim.SetBool("Shot", false);

        GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
        Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
        shotRB.AddForce(firePoint.right * shotSpeed * playerDir(), ForceMode2D.Impulse);
        Destroy(shot.gameObject, 0.5f);
    }
}
