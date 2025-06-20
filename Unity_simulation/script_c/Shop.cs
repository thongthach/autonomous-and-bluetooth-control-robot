using UnityEngine;

public class Shop : MonoBehaviour
{
    public PLayer pl;//for the amount of money
    public GameObject gun;
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         gun.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Equip();
        }
    }
    void Equip()
    {
        if (pl.money > 1)
        {

            //if the weapon is drop, give it a new coordinate system
            gun.transform.position = player.transform.position;
            gun.transform.rotation = player.transform.rotation;

            gun.GetComponent<Rigidbody>().isKinematic = true; //the rigibody falls to the floor
            gun.GetComponent<MeshCollider>().enabled = false;
            gun.transform.SetParent(player);
 
        }
    }
}
