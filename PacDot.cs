using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PacDot : MonoBehaviour
{
    public LayerMask Map;
    public Sprite Cherry;
    public SpriteRenderer PacDotSR;
    private BoxCollider2D PacDotCol;
    private bool valid;
    public Transform[] CherryPoints;
    // Start is called before the first frame update
    private void Awake()
    {
        valid = false;
        PacDotSR = gameObject.GetComponent<SpriteRenderer>();
        PacDotCol = gameObject.GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
        IsValid();
        DestroyPacDotInGhostHome();
        MakeitCherry();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pacman"&&valid==true)//다 만들어 지기도 전에 점수가 카운트 돼서 &&조건 추가
        {
            SFXManager.instance.PlaySFXCOin();
            GameManager.PacDotCount++;
            if (gameObject.tag == "Cherry")
            {
                GameManager.FleeTrigger = true;
            }
            Destroy(gameObject);
        }
    }

    private void IsValid()//PacDot이 맵 벽에 부딪히면 삭제해주는 모듈
    {
        int i;
        RaycastHit2D Hit;
        Vector2 PacDotPos, des;

        PacDotPos = gameObject.transform.position;
        PacDotCol.enabled = false;
        for (i = 1; i <= 4; i++)
        {
            switch (i)
            {
                case 1://PacDot으로부터 레이저를 쐈을 때, 좌 방향으로 벽이 있으면 삭제
                    des = PacDotPos + new Vector2(-0.5f, 0.0f);
                    Hit = Physics2D.Linecast(PacDotPos, des, Map);

                    if (Hit.transform != null)
                    {
                        Destroy(gameObject);
                        MapMatrix.Map[(int)PacDotPos.x, (int)PacDotPos.y] = -1;//맵행렬에서 -1로 처리하기 -1=>벽에 막혀있다.
                    }
                    break;
                case 2:
                    des = PacDotPos + new Vector2(0.5f, 0.0f);
                    Hit = Physics2D.Linecast(PacDotPos, des, Map);
                    if (Hit.transform != null)
                    {
                        Destroy(gameObject);
                        MapMatrix.Map[(int)PacDotPos.x, (int)PacDotPos.y] = -1;//맵행렬에서 -1로 처리하기 -1=>벽에 막혀있다.
                    }
                    break;
                case 3:
                    des = PacDotPos + new Vector2(0.0f, 0.5f);
                    Hit = Physics2D.Linecast(PacDotPos, des, Map);
                    if (Hit.transform != null)
                    {
                        Destroy(gameObject);
                        MapMatrix.Map[(int)PacDotPos.x, (int)PacDotPos.y] = -1;//맵행렬에서 -1로 처리하기 -1=>벽에 막혀있다.
                    }
                    break;
                case 4:
                    des = PacDotPos + new Vector2(0.0f, -0.5f);
                    Hit = Physics2D.Linecast(PacDotPos, des, Map);
                    if (Hit.transform != null)
                    {
                        Destroy(gameObject);
                        MapMatrix.Map[(int)PacDotPos.x, (int)PacDotPos.y] = -1;//Map행렬에서 -1로 처리하기 -1=>벽에 막혀있다.
                    }
                    break;

            }
        }
        PacDotCol.enabled = true;

    }
    
    private void DestroyPacDotInGhostHome()//PacDot이 Chost Home내부에 있으면 Destroy하는 모듈
    {
        Vector2 PacDotPos;
        PacDotPos = gameObject.transform.position;

        if ((PacDotPos.x >= 11.0f && PacDotPos.x <= 18.0f) && (PacDotPos.y>=15.0f&& PacDotPos.y<=19.0f))
        {
            Destroy(gameObject);
        }
    }
    private void MakeitCherry()
    {
        int i;
        for (i = 0; i < CherryPoints.Length; i++)
        {
            if (CherryPoints[i].position == gameObject.transform.position)
            {
                PacDotSR.sprite = Cherry;
                gameObject.tag = "Cherry";
                break;
            }
        }
        valid = true;
        
    }
}
