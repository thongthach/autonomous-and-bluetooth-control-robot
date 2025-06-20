using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY : MonoBehaviour
{
    public ScoreBoard sc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public NavMeshAgent agent;
    public Transform player;
    [SerializeField] GameObject explosion; //assign the gameobject
                                           // [SerializeField] GameObject explode; //assign the gameobject

    public void OnParticleCollision(GameObject other) //getting hit by the ammo
    {
        var emission = explosion.GetComponent<ParticleSystem>().emission;
        emission.enabled = true;

        //instantiate the vfx explosion, the enemy position, and the rotation
        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(this.gameObject);

        //adding score for the player
        sc.increaseScore(1);
    }
   
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        agent.SetDestination(player.position);
       
    }


}

