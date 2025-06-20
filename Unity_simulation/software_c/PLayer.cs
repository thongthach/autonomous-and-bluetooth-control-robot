using UnityEngine;
using System.IO.Ports;

//using Unity.VisualScripting;
public class PLayer : MonoBehaviour
{
    private Rigidbody rb;
    public ScoreBoard sc;
    
    public GameObject e; //adding arrays for other enemies
    private bool enemyDestroy = false;
    
    [SerializeField] int isJumped = 0;
    bool isLeft,isRight = false;
    bool isGround = false;

    [SerializeField] float jumpForce = 3.0f;

    [SerializeField] float speed = 2.0f;
    //adding a flag for the money

    public float score = 0.0f;//player score when killing zoombie
    public float money = 0.0f; //player the amount of money

    [SerializeField]public int ammo = 10; //player ammo

     SerialPort btPort = new SerialPort("COM6",115200);// for current always switch to COM6 for bluetooth comm
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //for the serial port 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (!btPort.IsOpen)
          {
            btPort.Open();
              Debug.Log("Bluetooth connected!");
         }
    }
    

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("COIN"))
        {
            //score++;
            Debug.Log("IncreaseScore called!");
            Destroy(other.gameObject);
            //sc.increaseScore(1); //adding money for the player
            sc.totalMoney(1);
        }

        else if (other.gameObject.CompareTag("Ammo"))
        {

            Debug.Log("Refuel ammo");
            ammo = 10;
            if (ammo <= 10)
            {
                Destroy(other.gameObject);
            }

           
        }


            else if (other.gameObject.CompareTag("ENEMY"))
            {
                score = 0;
                Destroy(gameObject);
            }

            else if (other.gameObject.CompareTag("ground")) //if the player is on the ground then its true, if not then false
            {
                isGround = true;
                Debug.Log("Hit the ground");
            }

        Debug.Log("Score: " + score);


    }
   
    private void OnParticleCollision(GameObject other)
    {

    }


    void Update()
    {
        //check if the enemy object is being destroyed, then updated the score
        if (e == null && !enemyDestroy)// enemy has been destory and the boolean enemyDestroy is true
        {
            sc.increaseScore(1);
            enemyDestroy = true;
        
        }


        float xvalue = Input.GetAxis("Horizontal") * Time.deltaTime *speed ;
        float yvalue = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //for rotation:
        if (xvalue != 0)
        {
            Quaternion rotation = Quaternion.Euler(0, xvalue * 1.0f * Time.deltaTime, 0);

        }

        if (yvalue != 0)
        {
             Quaternion rotation = Quaternion.Euler(0, yvalue * 1.0f * Time.deltaTime, 0);
        }

        if (xvalue > 1)
        {
            isRight = true;
        }
        else if (xvalue < -1)
        {
            isLeft = true;
        }
        transform.Translate(xvalue,0.0f,yvalue);
        if (Input.GetKeyDown(KeyCode.C))
        {


            //work on later to fix 
            if (isGround) //isGround = false this time , the object is on air
            {
                Debug.Log("On air");

                if (isJumped < 2) // Allow 1 ground jump + 2 air jumps
                {
                    Debug.Log("On air");
                    rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
                    isJumped++;
                    Debug.Log(isJumped);
                }


                else
                {
                    Destroy(gameObject);
                    Debug.Log("The object is destroyed");
                }

            }
            else if (isGround == true) //the object is on the ground
            {
                isJumped = 0; //reset jump to 0
                Debug.Log(isJumped);
            }
                
            
            
           
        }
        if(Input.GetKeyDown(KeyCode.Space) && isLeft){
            
            rb.AddForce(Vector3.left * jumpForce, ForceMode.Impulse);
            //isJumped ++;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isRight){
            
            rb.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
            //isJumped ++;
        }

       
        //FOR BLUETOOTH SERIAL COMM ONLY
        if(xvalue > 0.01f)
            {
                btPort.Write("D");
                Debug.Log("Right");
               
            }
            else if(xvalue < -0.01f)
            {
                btPort.Write("A");
                Debug.Log("LEFT");
            }
            else if(yvalue > 0.01f)
            {
                btPort.Write("W");
                Debug.Log("FORWARD");
            }
            else if(yvalue < -0.01f)
            {
                btPort.Write("S");
                Debug.Log("BACKWARD");

            }
            
            else
            {
                btPort.Write("K");
                Debug.Log("Idle");
            }
    }
}
