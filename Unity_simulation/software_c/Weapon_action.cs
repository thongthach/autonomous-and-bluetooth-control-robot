using UnityEngine;
using UnityEngine.UI;

public class Weapon_action : MonoBehaviour
{
    public GameObject gun;
    public Transform player; //transform the gun weapon according to the position of the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gun.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            DropWeapon();
        }
    }
    public void DropWeapon()
    {
        player.DetachChildren();
        //if the weapon is drop, give it a new coordinate system
        gun.transform.eulerAngles = new Vector3(gun.transform.position.x, gun.transform.position.z, gun.transform.position.y);
        gun.GetComponent<Rigidbody>().isKinematic = false; //the rigibody falls to the floor
        gun.GetComponent<MeshCollider>().enabled = true;


    }
}
