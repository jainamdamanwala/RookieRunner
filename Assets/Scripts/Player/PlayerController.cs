using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private CapsuleCollider slider;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    public float Acceleration;

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float Gravity = -20;

    public Animator animator;
    private bool isSliding = false;

    public int coinCounter;
    public int gearCounter;
    public GameObject coinDetectorObj;
    public GameObject highJumpObj;

    private bool isHighJumping = false;
    private bool HasMagnet = false;

    Transform player;

    public float MagnetTimer;
    public float HighJumpTimer;

    [HideInInspector]
    public float Score;
    [HideInInspector]
    public float HighScore;

    public Image bar;
    private float timeLeft;
    void Start()
    {
        LoadData();
        controller = GetComponent<CharacterController>();
        slider = GetComponent<CapsuleCollider>();
        player = GetComponent<Transform>();
        timeLeft = MagnetTimer;
        //coinDetectorObj.SetActive(false);
    }

    void Update()
    {

        SaveSystem.SavePlayer(this);
        if (!PlayerManager.isGameStarted)
            return;

        //Increase Speed 
        if(forwardSpeed < maxSpeed)
            forwardSpeed += Acceleration * Time.deltaTime;

        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;
        if(forwardSpeed < 25)
        {
            animator.SetFloat("animSpeed", 1f);
        }
        else if (forwardSpeed > 25)
        {
            animator.SetFloat("animSpeed", 1.25f);
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded)
        {
            if (SwipeManager.swipeUp)
                Jump();

            if (SwipeManager.swipeDown && !isSliding)
                StartCoroutine(Slide());
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
            if (SwipeManager.swipeDown && !isSliding)
            {
                StartCoroutine(Slide());
                direction.y = -8;
            }       
        }
        //Gather the inputs on which lane we should be
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;


        //transform.position = targetPosition;
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }

        //Move Player
        controller.Move(direction * Time.deltaTime);

        //ScoreSystem
        Score = player.position.z / 2;
        if(HighScore < Score)
        {
            HighScore = Score;
        }


    }
    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        coinCounter = data.coins;
        gearCounter = data.gear;
        HighScore = data.HighScore;
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            SaveSystem.SavePlayer(this);
            Debug.Log("GameOver");
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            coinCounter++;
        }
        if (other.gameObject.tag == "Gear")
        {
            gearCounter++;
        }
        if (other.gameObject.tag == "Magnet" && !HasMagnet)
        {
            StartCoroutine(ActiveCoin());
        }
        if (HasMagnet)
        {
            if (timeLeft > 0)
            {
                timeLeft -= 10 * Time.deltaTime;
                bar.fillAmount = timeLeft / MagnetTimer;
            }
            else
            {
                Debug.Log("timeOver");
            }
        }
        if (other.gameObject.tag == "Magnet" && HasMagnet)
        {
            StopCoroutine(ActiveCoin());
            StartCoroutine(ActiveCoin());
        }
        if (other.gameObject.tag == "HighJump" && !isHighJumping)
        {
            StartCoroutine(HighJump());
        }
        if (other.gameObject.tag == "HighJump" && isHighJumping)
        {
            StopCoroutine(HighJump());
            StartCoroutine(HighJump());
        }
    }
    IEnumerator HighJump()
    {
        if (isHighJumping == false)
        {
            if (forwardSpeed < 25)
            {
                jumpForce = jumpForce * 2;
                highJumpObj.SetActive(true);
                animator.SetBool("isHighJumping", true);
                isHighJumping = true;
                yield return new WaitForSeconds(HighJumpTimer);
                jumpForce = jumpForce / 2;
                highJumpObj.SetActive(false);
                animator.SetBool("isHighJumping", false);
                isHighJumping = false;
            }
            else
            {
                jumpForce = jumpForce + 4;
                highJumpObj.SetActive(true);
                animator.SetBool("isHighJumping", true);
                isHighJumping = true;
                yield return new WaitForSeconds(HighJumpTimer);
                jumpForce = jumpForce - 4;
                highJumpObj.SetActive(false);
                animator.SetBool("isHighJumping", false);
                isHighJumping = false;
            }
        }
    }

    IEnumerator ActiveCoin()
    {
        coinDetectorObj.SetActive(true);
        HasMagnet = true;
        yield return new WaitForSeconds(MagnetTimer);
        coinDetectorObj.SetActive(false);
        HasMagnet = false;
    }
    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, 0.5f, 0);
        controller.height = 0.75f;
        slider.height = 0.75f;
        slider.center = new Vector3(0, 0.5f, 0);

        yield return new WaitForSeconds(1.3f);

        controller.center = new Vector3(0,0.83f,0);
        controller.height = 1.54f;
        slider.center = new Vector3(0, 0.83f, 0);
        slider.height = 1.54f;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }
}
