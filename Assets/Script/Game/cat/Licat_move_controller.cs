using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Licat_move_controller : MonoBehaviour
{

    public float speed;   //速度
    public float moveSpeed;

    float _inputH;                    //接左右輸入
    float _inputV;                    //接上下輸入
    [SerializeField] float meowCouter = 0f;                // 貓叫偵測
    [SerializeField] bool isMeow = false;
    private bool isMoving = false;
    private bool isMoving_R = false;

    private bool _inputKbdSpace, _inputKbdW, _inputKbdA, _inputKbdS, _inputKbdD, _inputLKbdC, _inputUKbdC, _inputKbdQ, _inputKbdE, _inputKbdR, _inputKbdF;
    // ^ 接鍵盤輸入（是KeyDown，只偵測按下去，沒有偵測長按）
    private bool _inputHddX, _inputHddY, _inputHddA, _inputHddB, _inputLHddLB, _inputUHddLB;

    bool _inputJump;                                  //--跳躍相關
    bool _inputGetDownPlatform;                       //--
    [SerializeField] float JumpForce = 10;            //--
    [SerializeField] float gravityScale = 5;          //--
    [SerializeField] float fallGravityScale = 15;     //--

    public Transform footPoint;                       //確認站的位子
    private bool touchGround = true;                  //確認站的位子
    private bool touchPlatform = true;

    Rigidbody2D Rigidbody;

    public Animator catAni;                              //設定動畫
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


    private List<Vector2> points = new List<Vector2>();  //碰撞變化

    public GameObject splitController;

    private string SceneName;

    private string touchByLicat;
    private string touchByLicat_beforeGetDown;
    private bool isGetDownPlatform = true;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        polygonCollider2D = this.gameObject.GetComponent<PolygonCollider2D>();

        licat_yallow_prefab.SetActive(false);
        licat_blue_prefab.SetActive(false);
        licat_yallow_prefab.GetComponent<Licat_yellow_move_controller>().enabled = false;
        licat_blue_prefab.GetComponent<Licat_blue_move_controller>().enabled = false;

        catAni.SetBool("is_faceRight", false);

        SceneName = SceneManager.GetActiveScene().name;
        print("SceceName  " + SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        UserInputCheck();
        CatMove(); //控制走、跳、跳下、貓叫
        if (SceneName != "Level_0")
        {
            CatTransformSplit(); //控制變態、分裂
        }
        PointCheck();
    }

    private void UserInputCheck()
    {
        // string[] inputType={W,A,S,D,Q,E,R,F,C,Space}
        // 雖說知道這裡要用 for + 字串陣列啦，但好懶
        _inputKbdW = Input.GetKeyDown(KeyCode.W);
        _inputKbdA = Input.GetKeyDown(KeyCode.A);
        _inputKbdS = Input.GetKeyDown(KeyCode.S);
        _inputKbdD = Input.GetKeyDown(KeyCode.D);
        _inputKbdQ = Input.GetKeyDown(KeyCode.Q);
        _inputKbdE = Input.GetKeyDown(KeyCode.E);
        _inputKbdR = Input.GetKeyDown(KeyCode.R);
        _inputKbdF = Input.GetKeyDown(KeyCode.F);
        _inputLKbdC = Input.GetKey(KeyCode.C);
        _inputUKbdC = Input.GetKeyUp(KeyCode.C);
        _inputKbdSpace = Input.GetKeyDown(KeyCode.Space);

        _inputHddX = Input.GetButtonDown("X");
        _inputHddY = Input.GetButtonDown("Y");
        _inputHddA = Input.GetButtonDown("A");
        _inputHddB = Input.GetButtonDown("B");
        _inputLHddLB = Input.GetButton("LB");
        _inputUHddLB = Input.GetButtonUp("LB");
    }

    private void CatMove()
    {
        _inputH = Input.GetAxisRaw("Horizontal");
        _inputV = Input.GetAxisRaw("Vertical");

        bool isWalking = catAni.GetBool("is_move");
        bool rightPress = Input.GetKey(KeyCode.D);
        bool leftPress = Input.GetKey(KeyCode.A);

        if (!rightPress && !leftPress && touchGround && _inputH == 0)   //讓貓的動畫跟移動停下來
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

        if (isWalking && !rightPress || !leftPress && _inputH == 0)   //讓貓的動畫跟移動停下來、缺一不可
        {
            catAni.SetBool("is_move", false);
            catAni.SetBool("is_move_R", false);
            catAni.SetBool("is_liquid_move", false);
            catAni.SetBool("is_liquid_move_R", false);

        }

        if (rightPress || _inputH == 1)    //向右走動畫
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

        if (leftPress || _inputH == -1)         //向左走動畫
        {
            FaceRight = false;
            catAni.SetBool("is_faceRight", false);
            if (catAni.GetBool("is_solid") == true)
            {
                if (isMoving == false)
                {
                    catAni.Play("_N_L_move_0");
                    catAni.SetBool("is_move", true);
                    isMoving = true;
                }
                else if (isMoving == true)
                {
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

        if (_inputKbdS || _inputV == -1 && isGetDownPlatform == true) //從浮空走道下來
        {
            if (touchPlatform == true)
            {
                touchByLicat_beforeGetDown = touchByLicat;
                StartCoroutine(GetDownPlatform());
                isGetDownPlatform = false;
            }
        }

        if (touchGround && (_inputKbdSpace || _inputHddA))      //跳動畫
        {
            if (catAni.GetBool("is_solid") == true)
            {
                AudioManager.instance.PlaySE("cat_jump");
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
        if (_inputLKbdC || _inputLHddLB || _inputUKbdC || _inputUHddLB)
        {
            meowCouter += Time.deltaTime;
            if (!isMeow && (_inputUKbdC || _inputUHddLB))
            {
                Debug.Log("meowS");
                AudioManager.instance.PlaySE("cat_meow_s");
                meowCouter = 0f;
            }
            else if (meowCouter > 0.25)
            {
                if (!isMeow)
                {
                    Debug.Log("meowL");
                    AudioManager.instance.PlaySE("cat_meow_l");
                    isMeow = true;
                }
                if (_inputUKbdC || _inputUHddLB)
                {
                    meowCouter = 0f;
                    isMeow = false;
                }
            }
        }
    }

    private void CatTransformSplit()
    {
        if ((_inputKbdR || _inputHddB) && catAni.GetBool("is_solid") == false)      //分裂，融合動畫
        {
            if (!catAni.GetBool("is_split"))
            {
                catAni.SetBool("is_split", true);
                Invoke("ActCherController", 0.5f);
            }
        }

        if (_inputKbdQ || _inputHddY)        //變形動畫
        {
            if (catAni.GetBool("is_solid") == true)
            {
                if (!catAni.GetBool("is_faceRight"))
                {
                    catAni.SetBool("is_solid", false);
                    catAni.Play("_N_L_convert");
                }
                else if (catAni.GetBool("is_faceRight"))
                {
                    catAni.SetBool("is_solid", false);
                    catAni.Play("_N_R_convert");
                }
            }
            else if (catAni.GetBool("is_solid") == false)
            {
                if (!catAni.GetBool("is_faceRight"))
                {
                    catAni.SetBool("is_solid", true);
                    catAni.Play("_L_L_convert");
                }
                else if (catAni.GetBool("is_faceRight"))
                {
                    catAni.SetBool("is_solid", true);
                    catAni.Play("_L_R_convert");
                }
            }
        }
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

        licat.SetActive(false);

        splitController.SetActive(true);
        splitController.GetComponent<Split_controller>().enabled = true;
    }

    void PointCheck()
    {
        touchGround = Physics2D.OverlapCircle(footPoint.position, 0.2f, LayerMask.GetMask("Ground & Wall") | LayerMask.GetMask("Platform"));
        touchPlatform = Physics2D.OverlapCircle(footPoint.position, 0.5f, LayerMask.GetMask("Platform"));
    }

    IEnumerator GetDownPlatform()
    {
        if (FaceRight)
        {
            if (catAni.GetBool("is_solid") == true)
            {
                catAni.Play("_N_R_move_1");
                catAni.SetBool("is_move_R", true);
                _inputGetDownPlatform = true;
            }
            else if (catAni.GetBool("is_solid") == false)
            {
                catAni.Play("_L_R_move_1");
                catAni.SetBool("is_liquid_move_R", true);
                _inputGetDownPlatform = true;
            }
        }
        else if (!FaceRight)
        {
            if (catAni.GetBool("is_solid") == true)
            {
                catAni.Play("_N_L_move_1");
                catAni.SetBool("is_move", true);
                _inputGetDownPlatform = true;
            }
            else if (catAni.GetBool("is_solid") == false)
            {
                catAni.Play("_L_L_move_1");
                catAni.SetBool("is_liquid_move", true);
                _inputGetDownPlatform = true;
            }
        }

        yield return new WaitForSeconds(0.1f);

        polygonCollider2D.enabled = false;
        LeftBoxCollider2D.enabled = false;
        RightBoxCollider2D.enabled = false;

        yield return new WaitForSeconds(0.2f);

        polygonCollider2D.enabled = true;
        LeftBoxCollider2D.enabled = true;
        RightBoxCollider2D.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touchByLicat = collision.gameObject.name;

        if (touchByLicat_beforeGetDown != touchByLicat)     // 判斷貓是否落地（給落下的功能用）
        {
            isGetDownPlatform = true;
        }
    }

    void FixedUpdate()
    {
        Moving();
        Jump();
        catSr.sprite.GetPhysicsShape(0, points);
        polygonCollider2D.SetPath(0, points);         //設定碰撞體
    }

    void Moving()  //實際的左右移動
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

    void Jump()    //實際的跳
    {
        if (touchPlatform && _inputGetDownPlatform)
        {
            Rigidbody.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
            _inputGetDownPlatform = false;
        }
        else if (touchGround && _inputJump)
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

    public void setMoveSpeed(float newMoveSpeed)  //改變貓的速度
    {
        moveSpeed = newMoveSpeed;
    }
}
