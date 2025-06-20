using UnityEngine;

public class Second_gun : MonoBehaviour
{
    [SerializeField] public GameObject _object;
    public Transform player;
    public GameObject gun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _object.SetActive(false);
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision other) 
        
    
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                _object.SetActive(true);
            }
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



    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            DropWeapon();
        }
        
    }
}
