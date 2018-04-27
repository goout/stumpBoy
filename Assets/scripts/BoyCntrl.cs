using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class BoyCntrl : MonoBehaviour
{

    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;
	[SerializeField] private CircleCollider2D feetCollider = null;
    [SerializeField] private Transform groundCheck;
	[SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float jumpPower = 700f;
	[SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject DeathParticles = null;


    public enum FaceDirection { FaceLeft = -1, FaceRight = 1 };
    public static bool IsGrounded = false;
	public static bool IsDeath = false;
	public static bool IsPlatformed = false;
    public static BoyCntrl BoyInstance = null;
    public static bool InDialogue;


    private AudioSource audioSource;
    private FaceDirection facing = FaceDirection.FaceRight;
    private Transform thisTransform = null;
    private Rigidbody2D thisBody = null;
    private string jumpButton = "Jump";
    private int scene_1 = 1;
    private bool CanJump = true;
    private float jumpTimeOut = 1f;
    private Animator animator = null;
	private float horz = 0f;
    private static float _health = 100f;


    void Awake()
    {
        thisTransform = GetComponent<Transform>();
        thisBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        BoyInstance = this;
    }


    public static float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;

            if (_health <= 0)
                DeathWithParticles();
        }
    }


    public static void DeathWithParticles()
    {
        if (BoyCntrl.BoyInstance.DeathParticles != null)
        {
            Instantiate(BoyCntrl.BoyInstance.DeathParticles,
                BoyCntrl.BoyInstance.thisTransform.position,
                BoyCntrl.BoyInstance.thisTransform.rotation);
        }

        Destroy(BoyCntrl.BoyInstance.gameObject);
    }

    public void AnimatedDeath()
    {
        Destroy(BoyCntrl.BoyInstance.gameObject);
        IsDeath = false;
        SceneManager.LoadScene(scene_1);
    }


    void OnParticleCollision(GameObject other)
    {
        if (!IsDeath)
        {
            audioSource.PlayOneShot(sfxDeath);
            animator.SetBool("bdeath", true);
            animator.SetTrigger("death");
            IsDeath = true;
        }
    }


    private bool GetPlatformed()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(groundCheck.position, feetCollider.radius, groundLayer);
        if (hitCollider && hitCollider.gameObject.tag == "platform") return true;
        return false;
    }


    void FixedUpdate()
    {
        if (IsDeath) return;

        if (InDialogue)
        {
            animator.SetFloat("Speed", 0);

            return;
        }

        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, feetCollider.radius, groundLayer);

        if (!IsPlatformed)
        {
            IsPlatformed = GetPlatformed();
        }

        animator.SetBool("Ground", IsGrounded);
        animator.SetBool("Platform", IsPlatformed);

        //horz = CrossPlatformInputManager.GetAxis (horzAxis); //mobile version build don't forget

        thisBody.AddForce(Vector2.right * horz * maxSpeed);
        animator.SetFloat("Speed", Mathf.Abs(horz));

        if (CrossPlatformInputManager.GetButton(jumpButton))
            Jump();

        if ((horz < 0f && facing != FaceDirection.FaceLeft) || (horz > 0f && facing != FaceDirection.FaceRight))
            FlipDirection();

        animator.SetFloat("vSpeed", thisBody.velocity.y);
    }


    public void Move(float InputAxis)
    {
        horz = InputAxis;
    }


    private void FlipDirection()
    {
        facing = (FaceDirection)((int)facing * -1f);
        Vector3 theScale = thisTransform.localScale;
        theScale.x *= -1f;
        thisTransform.localScale = theScale;
    }


    public void Jump()
    {
        if (!IsGrounded || !CanJump || InDialogue)
        {
            return;
        }

        audioSource.PlayOneShot(sfxJump);
        thisBody.AddForce(Vector2.up * jumpPower);
        CanJump = false;
        IsPlatformed = false;
        Invoke("ActivateJump", jumpTimeOut);
    }


    private void ActivateJump()
    {
        CanJump = true;
    }


}
