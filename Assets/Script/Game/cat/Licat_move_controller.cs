using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Licat_move_controller : MonoBehaviour
{
    public float speed;   //�t��
    public float moveSpeed;

    float _inputH;                    //�����k��J
    private bool isMoving = false;
    private bool isMoving_R = false;

    bool _inputJump;                                  //--���D����
    [SerializeField] float JumpForce = 10;            //--
    [SerializeField] float gravityScale = 5;          //--
    [SerializeField] float fallGravityScale = 15;     //--

    public Transform footPoint;                       //�T�{������l
    private bool touchGround = true;                  //�T�{������l

    Rigidbody2D Rigidbody;

    public Animator catAni;                              //�]�w�ʵe
    public SpriteRenderer catSr;
    public GameObject licat_yallow_prefab;
    public GameObject licat_blue_prefab;
    public GameObject licat;
    public Animator blue_Ani;
    public Animator yallow_Ani;
    private bool FaceRight;
    private PolygonCollider2D polygonCollider2D;         //--
    public BoxCollider2D LeftBoxCollider2D;
    public BoxCollider2D RightBoxCollider2D;


    private List<Vector2> points = new List<Vector2>();  //�I���ܤ�

    public GameObject splitController;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        polygonCollider2D = this.gameObject.GetComponent<PolygonCollider2D>();
        licat_yallow_prefab.SetActive(false);
        licat_blue_prefab.SetActive(false);
        licat_yallow_prefab.GetComponent<Licat_yellow_move_controller>().enabled = false;
        licat_blue_prefab.GetComponent<Licat_blue_move_controller>().enabled = false;
        catAni.SetBool("is_faceRight", true);
    }

    // Update is called once per frame
    void Update()
    {
        //bool isMoving = false;
        bool isWalking = catAni.GetBool("is_move");
        bool rightPress = Input.GetKey(KeyCode.D);
        bool leftPress = Input.GetKey(KeyCode.A);

        _inputH = Input.GetAxisRaw("Horizontal");

        if (!rightPress && !leftPress && touchGround && _inputH == 0)
        {
            Rigidbody.velocity = new Vector2(_inputH * 0, Rigidbody.velocity.y);
            moveSpeed = 0f;
            isMoving = false;
            isMoving_R = false;

            catAni.SetBool("is_move", false);
            catAni.SetBool("is_move_R", false);
            catAni.SetBool("is_liquid_move", false);
            catAni.SetBool("is_liquid_move_R", false);
        }

        if (isWalking && !rightPress || !leftPress && _inputH == 0)
        {
            //catAni.SetBool("is_move", false);
            //catAni.SetBool("is_move_R", false);
            //catAni.SetBool("is_liquid_move", false);
            //catAni.SetBool("is_liquid_move_R", false);
            
        }

        if (rightPress || _inputH == 1)    //�V�k���ʵe
        {
            FaceRight = true;
            catAni.SetBool("is_faceRight", true);
            if (catAni.GetBool("is_solid") == true)
            {
                if (isMoving_R == false)
                {
                    catAni.Play("_N_R_move_0");
                    catAni.SetBool("is_move_R", true);
                    isMoving_R = true;
                }
                else if (isMoving_R == true)
                {
                    catAni.SetBool("is_move_R", true);
                }
            }
            else if (catAni.GetBool("is_solid") == false)
            {
                if (isMoving_R == false)
                {
                    catAni.Play("_L_R_move_0");
                    catAni.SetBool("is_liquid_move_R", true);
                    isMoving_R = true;
                }
                else if (isMoving_R == true)
                {
                    catAni.SetBool("is_liquid_move_R", true);
                }
            }
        }

        if (leftPress || _inputH == -1)         //�V�����ʵe
        {
            FaceRight = false;
            catAni.SetBool("is_faceRight", false);
            if (catAni.GetBool("is_solid") == true)
            {
                if (isMoving == false)
                {
                    print("is_move  false");
                    catAni.Play("_N_L_move_0");
                    catAni.SetBool("is_move", true);
                    isMoving = true;
                }
                else if (isMoving == true)
                { 
                    print("is_move  true");
                    catAni.SetBool("is_move", true);
                }
            }
            else if (catAni.GetBool("is_solid") == false)
            {
                if (isMoving == false)
                {
                    catAni.Play("_L_L_move_0");
                    catAni.SetBool("is_liquid_move", true);
                    isMoving = true;
                }
                else if (isMoving == true)
                {
                    catAni.SetBool("is_liquid_move", true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && touchGround)      //���ʵe
        {
            if (catAni.GetBool("is_solid") == true)
            {
                print("jump");
                if (FaceRight == false)
                {
                    catAni.SetTrigger("is_jump");
                    //catAni.Play("_N_L_jump");
                    _inputJump = true;
                }
                else
                {
                    catAni.SetTrigger("is_jump_R");
                    //catAni.Play("_N_R_jump");
                    _inputJump = true;
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.R) && catAni.GetBool("is_solid") == false)      //�����A�ĦX�ʵe
        {
            if (catAni.GetBool("is_split") == true)
            {
                catAni.SetBool("is_split", false);

                licat_yallow_prefab.GetComponent<Licat_yellow_move_controller>().enabled = false;
                licat_blue_prefab.GetComponent<Licat_blue_move_controller>().enabled = false;
                licat_yallow_prefab.SetActive(false);
                licat_blue_prefab.SetActive(false);
            }
            else
            {
                catAni.SetBool("is_split", true);
                Invoke("ActCherController", 1.3f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))        //�ܧΰʵe
        {
            if (catAni.GetBool("is_solid") == true)
            {
                catAni.SetBool("is_solid", false);
            }
            else if (catAni.GetBool("is_solid") == false)
            {
                catAni.SetBool("is_solid", true);
            }
        }

        PointCheck();
    }

    void ActCherController()
    {
        licat.GetComponent<Licat_move_controller>().enabled = false;
        licat_yallow_prefab.transform.position = new Vector3((licat.transform.position.x) - 2, licat.transform.position.y, 3);
        licat_blue_prefab.transform.position = new Vector3((licat.transform.position.x) + 2, licat.transform.position.y, 3);
        //licat.transform.position = new Vector3((licat_blue_prefab.transform.position.x) + 10, licat_blue_prefab.transform.position.y, 3);

        licat_yallow_prefab.SetActive(true);
        licat_blue_prefab.SetActive(true);
        blue_Ani.SetBool("is_solid", false);
        yallow_Ani.SetBool("is_solid", false);
        
        licat_yallow_prefab.GetComponent<Licat_yellow_move_controller>().enabled = false;
        licat_blue_prefab.GetComponent<Licat_blue_move_controller>().enabled = true;

        //licat.GetComponent<Licat_move_controller>().enabled = false;
        catSr.enabled = false;
        polygonCollider2D.enabled = false;
        LeftBoxCollider2D.enabled = false;
        RightBoxCollider2D.enabled = false;

        splitController.SetActive(true);
        splitController.GetComponent<Split_controller>().enabled = true;
    }

    void PointCheck()
    {
        touchGround = Physics2D.OverlapCircle(footPoint.position, 0.5f, LayerMask.GetMask("Ground & Wall") | LayerMask.GetMask("Platform"));
    }

    void FixedUpdate()
    {
        Moving();
        Jump();
        catSr.sprite.GetPhysicsShape(0, points);
        polygonCollider2D.SetPath(0, points);         //�]�w�I����
    }

    void Moving()
    {
        if (_inputH != 0)
        {
            Rigidbody.velocity = new Vector2(_inputH * moveSpeed, Rigidbody.velocity.y);
            if (moveSpeed <= 5) moveSpeed = moveSpeed + 0.2f;
            else if (moveSpeed <= 10)
            {
                moveSpeed = moveSpeed + 0.3f;
            }
        }


        if (Input.GetKey(KeyCode.D))
        {
            Rigidbody.velocity = new Vector2(_inputH * moveSpeed, Rigidbody.velocity.y);
            if (moveSpeed <= 5) moveSpeed = moveSpeed + 0.2f;
            else if (moveSpeed <= 10)
            {
                moveSpeed = moveSpeed + 0.3f;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Rigidbody.velocity = new Vector2(_inputH * moveSpeed, Rigidbody.velocity.y);
            if (moveSpeed <= 5) moveSpeed = moveSpeed + 0.2f;
            else if (moveSpeed <= 10)
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
