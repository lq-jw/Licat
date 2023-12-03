using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licat_yallow_move_controller : MonoBehaviour
{
    public float speed;
    public float speed_x_constraint;
    public float moveSpeed = 0f;

    float _inputH;
    bool _inputJump;
    [SerializeField] float JumpForce = 10;
    [SerializeField] float gravityScale = 5;
    [SerializeField] float fallGravityScale = 15;
    public Transform footPoint;
    private bool touchGround = true;
    Rigidbody2D Rigidbody;
    public Animator catAni;
    public SpriteRenderer catSr;
    private PolygonCollider2D polygonCollider2D;
    private List<Vector2> points = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        polygonCollider2D = this.gameObject.GetComponent<PolygonCollider2D>();
        catAni.SetBool("is_solid", false);
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = catAni.GetBool("is_move");
        bool rightPress = Input.GetKey(KeyCode.D);
        bool leftPress = Input.GetKey(KeyCode.A);

        _inputH = Input.GetAxisRaw("Horizontal");

        if (!rightPress && !leftPress && touchGround)
        {
            moveSpeed = 0f;
        }

        if (isWalking && !rightPress || !leftPress)
        {
            catAni.SetBool("is_move", false);
            catAni.SetBool("is_liquid_move", false);
        }

        if (rightPress)
        {
            if (catSr.flipX == false)
            {
                catSr.flipX = true;
            }
            if (catAni.GetBool("is_solid") == false)
            {
                catAni.SetBool("is_liquid_move", true);
            }
            else
            {
                catAni.SetBool("is_move", true);
            }
        }
        if (leftPress)
        {
            if (catSr.flipX == true)
            {
                catSr.flipX = false;
            }
            if (catAni.GetBool("is_solid") == false)
            {
                catAni.SetBool("is_liquid_move", true);
            }
            else
            {
                catAni.SetBool("is_move", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && touchGround)
        {
            if (catAni.GetBool("is_solid") == true)
            {
                catAni.SetTrigger("is_jump");
                _inputJump = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (catAni.GetBool("is_solid") == true)
            {
                catAni.SetBool("is_solid", false);
            }
            else
            {
                catAni.SetBool("is_solid", true);
            }
        }

        PointCheck();
    }

    void PointCheck()
    {
        touchGround = Physics2D.OverlapCircle(footPoint.position, 0.5f, LayerMask.GetMask("Ground & Wall") | LayerMask.GetMask("Platform"));
    }

    void FixedUpdate()
    {
        H_moving();
        Jump();

        catSr.sprite.GetPhysicsShape(0, points);
        polygonCollider2D.SetPath(0, points);
    }

    void H_moving()
    {
        if (_inputH != 0)
        {
            Rigidbody.velocity = new Vector2(_inputH * moveSpeed, Rigidbody.velocity.y);
            if (moveSpeed <= 5) moveSpeed = moveSpeed + 0.1f;
            else if (moveSpeed <= 12)
            {
                moveSpeed = moveSpeed + 0.3f;
            }
        }
    }

    void Jump()
    {
        if (_inputJump && touchGround)
        {
            Rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            _inputJump = false;

        }
        if (Rigidbody.velocity.y > 0)
        {
            Rigidbody.gravityScale = gravityScale;
        }
        else
        {
            Rigidbody.gravityScale = fallGravityScale;
        }
    }

    public void setMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
}
