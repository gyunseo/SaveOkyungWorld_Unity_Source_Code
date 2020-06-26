using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour{

    public static Pacman instance;//싱글톤
    public float Speed = 0.4f;
    public Joystick FixedJoyStick;//조이 스틱
    private Vector2 des = Vector2.zero;//0으로 초기화
 
    
    private Rigidbody2D PacmanRB;
    private Collider2D PacmanCol;
    private RaycastHit2D Hit;
    private Animator PacmanAnim;

    private void Awake()
    {
        Pacman.instance = this;
    }
    // Start is called before the first frame update
    void Start(){

        PacmanAnim = gameObject.GetComponent<Animator>();
        PacmanCol = gameObject.GetComponent<Collider2D>();
        PacmanRB = gameObject.GetComponent<Rigidbody2D>();
        des = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate(){
        PacmanMove();
    }

    private void PacmanMove(){

        Vector2 CurPos,delta,dir;

        CurPos = gameObject.transform.position;
        delta = Vector2.MoveTowards(CurPos,des,Speed);

        PacmanRB.MovePosition(delta);

        CurPos = gameObject.transform.position;
        if (CurPos == des){

            if (Input.GetKey(KeyCode.UpArrow) && IsValid(Vector2.up)){
                des = CurPos + Vector2.up;

            }
            if (Input.GetKey(KeyCode.DownArrow) && IsValid(Vector2.down))
            {
                des = CurPos + Vector2.down;

            }
            if (Input.GetKey(KeyCode.LeftArrow) && IsValid(Vector2.left))
            {
                des = CurPos + Vector2.left;

            }
            if (Input.GetKey(KeyCode.RightArrow) && IsValid(Vector2.right))
            {
                des = CurPos + Vector2.right;

            }

            Debug.Log("x: "+FixedJoyStick.Horizontal+"y: "+FixedJoyStick.Vertical);
            //조이스틱 부분
            if (FixedJoyStick.Vertical != 0 || FixedJoyStick.Horizontal != 0)
            {
               
                if (FixedJoyStick.Vertical >= 0.5f && IsValid(Vector2.up))
                {
                    des = CurPos + Vector2.up;

                }
                if (FixedJoyStick.Vertical <= -0.5f && IsValid(Vector2.down))
                {
                    des = CurPos + Vector2.down;

                }
                if (FixedJoyStick.Horizontal <= -0.5f && IsValid(Vector2.left))
                {
                    des = CurPos + Vector2.left;

                }
                if (FixedJoyStick.Horizontal >= +0.5f && IsValid(Vector2.right))
                {
                    des = CurPos + Vector2.right;

                }
            }
            //버튼 부분
            if (UpBtn.instance.buttonDown == true&&IsValid(Vector2.up))
            {
                Debug.Log("Up!");
                des = CurPos + Vector2.up;
            }
            if (DownBtn.instance.buttonDown == true && IsValid(Vector2.down))
            {
                Debug.Log("Down!");
                des = CurPos + Vector2.down;
            }
            if (RightBtn.instance.buttonDown == true && IsValid(Vector2.right))
            {
                Debug.Log("Right!");
                des = CurPos + Vector2.right;
            }
            if (LeftBtn.instance.buttonDown == true && IsValid(Vector2.left))
            {
                Debug.Log("Left!");
                des = CurPos + Vector2.left;
            }


        }


        dir = des - CurPos;

        PacmanAnim.SetFloat("DirX",dir.x);
        PacmanAnim.SetFloat("DirY", dir.y);
    }

    private bool IsValid(Vector2 dir){

        Vector2 CurPos;
        bool res;

        CurPos = gameObject.transform.position;
        Hit = Physics2D.Linecast(CurPos + dir, CurPos);

        res = Hit.collider == PacmanCol;
        return res;

    }
 


}
