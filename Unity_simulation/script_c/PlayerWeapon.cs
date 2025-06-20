using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    public Level_controller lc;

    public PLayer player; // obtain the player ammo, if ammo=0, disable the firing particle.
   
    bool isFiring = false;
    bool previousState = false;
    private int bulletused = 0;
    [SerializeField] GameObject laser;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void OnFire(InputValue value)
    {

        isFiring = value.isPressed;
      

    }
    private void Firing()
    {
        var emission = laser.GetComponent<ParticleSystem>().emission;
        bool firePressed = isFiring && !previousState;


        //put this in the comment, using it later
        /*
        if (!lc.currentstate && player.ammo > 0 && bulletused < 10)
        {
            if (firePressed)
            {


                emission.enabled = isFiring;
                player.ammo--;
                bulletused++;
                if (player.ammo < 0)
                {
                    player.ammo = 0;
                }

            }
            else
            {
                emission.enabled = false;
            }


        }
        else
        {


            emission.enabled = false;
            Debug.Log("Out of ammo");

        }

        previousState = isFiring;
        */

        //use this one below for temporary:
        if (!lc.currentstate)
        {
            emission.enabled = isFiring;

        }
        else
        {
            emission.enabled = false;
        }

        
        
        /*if (!firePressed)
        {
            var emission = laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
            

        }*/



    }
    

    public void Update()
    {
       
        
        Firing();
        
            
    }
}
