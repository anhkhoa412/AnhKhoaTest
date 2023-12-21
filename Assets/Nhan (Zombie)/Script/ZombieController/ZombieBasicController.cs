using UnityEngine;

public class ZombieBasicController : MonoBehaviour
{
    public bool isCollidePlayer = false;
    public bool isDeath = false;
    private bool isSlowSpeed = false;
    private bool isLowed = false;

    Animator anim;
    [SerializeField] float maxSpeed;
    [SerializeField] float currentSpeed;
    public GameObject currentPlant;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (currentPlant == null)
        {
            isCollidePlayer = false;
        }

        if (!isCollidePlayer && !isDeath)
        {
            anim.SetBool("Run", true);
            ZombieMovement();
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    public void ZombieMovement() 
    {
        if (isSlowSpeed && !isLowed)
        {
            //was slow 30% by bullet Plant (Snow Pew)
            isSlowSpeed = false;
            isLowed = true;
            currentSpeed = 0.7f * maxSpeed;
        }
        else if (!isSlowSpeed && !isLowed) 
        {
            currentSpeed = maxSpeed ;   
        }
        
        Vector3 currentPosition = transform.position;
        float newPositionX = currentPosition.x + currentSpeed * Time.deltaTime;
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

    public void Death()
    {
        //anim.SetTrigger("Death");
        isDeath = true;
    }

    private void OnTriggerEnter(Collider zombie)
    {
        if (zombie.gameObject.CompareTag("BulletSnowPea"))
        {
            isSlowSpeed = true;
            Invoke("ExitTimeSlow", 3f);
            //After 3 seconds, time slow end
        }
    }

    void ExitTimeSlow()
    {
        isSlowSpeed = false;
        isLowed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plant") || collision.gameObject.CompareTag("Chomper"))
        {
           currentPlant = collision.gameObject;
            isCollidePlayer = true;
            //anim.SetBool("attack", true);
        }

        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Chomper"))
        {
            Destroy(gameObject, 1f);
            isCollidePlayer = true;
        }
    }

    //is called by GameObject Bullet Snow Pea while colliding zombie
    /*public void SlowSpeedZombie()
    {
        isSlowSpeed = true;
        Invoke("ExitTimeSlow", 3f);
    }
    
    //is called by Plant Chomper (swallow zombie)
     public void EffectOfChomper() 
    {
        Destroy(gameObject,1f);
    }
     */
}
