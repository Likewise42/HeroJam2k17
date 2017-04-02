using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MoveControls : MonoBehaviour {

    public float moveSpeed;
    private float inputDirection; //X Value of moveVector
    private float verticalVelocity; //Y Value of moveVector
    public float jump;
    private float gravity;
    public bool dashPower;
    public float dashTimer;
    public float dashLimit;
    public float dashWaitLimit;
    public float dashingTimer;
    public bool dashReady;
    public bool dashReplenish;
    public bool dashing;
    public bool dead;
    public bool haveCoin;
    public float coinCooldown;
    public float coinCooldownMax;
    public bool facingRight;
    public GameObject coin;
    private Vector3 moveVector;
    private CharacterController controller;
    private float time;
    public GameObject particles;

    public Animator animator;
    public AnimatorControllerParameter Acontroller;

    private int dashHash;
    private int throwHash;
    private int runHash;
    private int jumpHash;
    private int idleHash;
    private int entryHash;


	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        gravity = 1.0f;
        jump = 20;
        dashTimer = 0.0f;
        dashReady = true;
        dashing = false;
        dashReplenish = false;
        dashPower = true;
        haveCoin = true;

        animator = (Animator) GetComponent<Animator>();

        dashHash = Animator.StringToHash("Dash");
        throwHash = Animator.StringToHash("Throwing");
        runHash = Animator.StringToHash("Running");
        jumpHash = Animator.StringToHash("Jump");
        idleHash = Animator.StringToHash("Idle");
        entryHash = Animator.StringToHash("Entry");

        animator.SetTrigger("GO");
    }
	
	// Update is called once per frame
	void Update () {
        inputDirection = Input.GetAxis("Horizontal") * moveSpeed;

        //animator.SetFloat("Speed", inputDirection);

        if(inputDirection > 0)
        {
            facingRight = true;
        }else if(inputDirection < 0)
        {
            facingRight = false;
        }

        //Switching Powers
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(dashPower)
            {
                dashPower = false;
            }
            else
            {
                dashPower = true;
            }
        }

        //Jump Power
        if(!dashPower)
        {
            jump = 30;
        }
        else
        {
            jump = 20;
        }

        //Dash Power
        if (dashPower)
        {
            if (Input.GetKey(KeyCode.LeftShift) && dashReady) //They want to dash and can
            {
                dashing = true;
                verticalVelocity = 0;
            }

            if (dashing) //The Dash lasts for a certain amount of time
            {
                animator.SetTrigger(dashHash);
                inputDirection *= 4.5f;
                dashingTimer += Time.deltaTime;
                dashReady = false;
            }

            if (dashingTimer >= dashLimit) //Their dash time is up
            {
                dashing = false;
                dashReplenish = true;
                dashingTimer -= dashLimit;
            }

            if (dashReplenish) //Dash power needs to be replenished
            {
                dashTimer += Time.deltaTime;
            }

            if (dashTimer >= dashWaitLimit && controller.isGrounded) //Their dash is replenished
            {
                dashReplenish = false;
                dashReady = true;
                dashTimer -= dashWaitLimit;
            }
        }

        if (controller.isGrounded) //They are on the ground
        {
            verticalVelocity = 0;

            if(Input.GetAxis("Horizontal") == -1) //Going Left
            {
                transform.forward = new Vector3(-1, 0, 0);
                facingRight = false;
            }
            if (Input.GetAxis("Horizontal") == 1) //Going Right
            {
                transform.forward = new Vector3(1, 0, 0);
                facingRight = true;
            }

            if (Input.GetKey(KeyCode.W)) //Jumping
            {
                verticalVelocity = jump;
            }
        }
        else if(!dashing)
        {
            verticalVelocity -= gravity; //Gravity Stuff
        }

        if (haveCoin)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                throwCoin();
            }
        }
        else
        {
            coinCooldown += Time.deltaTime;

            if(coinCooldown > coinCooldownMax)
            {
                haveCoin = true;
            }
        }

        if (!dead)
        {
            moveVector = new Vector3(inputDirection, verticalVelocity, 0);
            controller.Move(moveVector * Time.deltaTime);
        }


        if (dead && (time < 3))
        {
            transform.FindChild("Main_Character_Test_4:LizCharacter_Final_03_low:Liz_low").gameObject.SetActive(false);
            particles.transform.position = transform.position;
            particles.SetActive(true);
            time += Time.deltaTime;
            if (time > 0.5)
            {
                particles.SetActive(false);
            }
            if (time > 3)
            {
                SceneManager.UnloadSceneAsync("coinUI");
                SceneManager.LoadScene("gameOver", LoadSceneMode.Additive);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.tag == "Enemy")
        {
            dead = true;
        }
    }

    public bool getDirection()
    {
        return facingRight;
    }

    void throwCoin()
    {

        if (haveCoin)
        {
            Vector3 coinVec = gameObject.transform.position;
            Quaternion coinRot = gameObject.transform.rotation;

            if (facingRight)
            {
                coinVec.x += 1.5f;
            }else
            {
                coinVec.x -= 1.5f;
            }
            

            Instantiate(coin, coinVec, coinRot);

            coinCooldown = 0;
            haveCoin = false;
        } else
        {

        }

        
    }
}
