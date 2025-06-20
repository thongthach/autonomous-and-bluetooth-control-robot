using UnityEngine;

public class WALL : MonoBehaviour
{
    //[SerializeField] float speed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<MeshRenderer>().material.color = Color.black;
        Debug.Log("Hit onto something");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
