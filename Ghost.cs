using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform[] WayPoints,ReturnPoints,TraversePoints;
    
    private int cur=0;
    private Rigidbody2D GhostRB;
    private Animator GhostAnim;
    private bool IsHome;
    private bool IsAlive;
    private bool bIsReached;

    public float Speed;
    // Start is called before the first frame update
    private void Awake()
    {
        bIsReached = false;
        IsAlive = true;
        IsHome = true;
        GhostRB = gameObject.GetComponent<Rigidbody2D>();
        GhostAnim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GhostMove_Near_Home(IsHome,IsAlive);

        if (gameObject.tag == "Ghost")
        {
            GhostMove_Outside_Home(IsHome, IsAlive);
        }
        else if (gameObject.tag == "Traverse_Ghost")
        {
            GhostTraverse(IsHome,IsAlive);
        }
        ReturnHome(IsHome,IsAlive);
    }

    private void GhostTraverse(bool home_trigger,bool alive_trigger)
    {
        if (home_trigger == false && alive_trigger == true)
        {
            if(GameManager.FleeMode==true) GhostAnim.SetBool("Flee", true);
            else GhostAnim.SetBool("Flee", false);

            Vector2 GhostPos = gameObject.transform.position;
            Vector2 DesPos = TraversePoints[cur].position;
            Vector2 Delta, Dir;
            // Waypoint not reached yet? then move closer
            if (GhostPos != DesPos)
            {
                Delta = Vector2.MoveTowards(GhostPos, DesPos, Speed);
                GhostRB.MovePosition(Delta);
            }
            // Waypoint reached, select next one
            else cur = (cur + 1) % TraversePoints.Length;



            // Animation
            Dir = DesPos - GhostPos;
            GhostAnim.SetFloat("DirX", Dir.x);
            GhostAnim.SetFloat("DirY", Dir.y);
        }
    }
    private void GhostMove_Near_Home(bool home_trigger,bool alive_trigger)
    {
        if (home_trigger == true&&alive_trigger==true)
        {
            Vector2 GhostPos = gameObject.transform.position;
            Vector2 DesPos = WayPoints[cur].position;
            Vector2 Delta, Dir;
            // Waypoint not reached yet? then move closer
            if (GhostPos != DesPos)
            {
                Debug.Log(gameObject.tag+":" + cur);
                Delta = Vector2.MoveTowards(GhostPos, DesPos, Speed);
                GhostRB.MovePosition(Delta);
            }
            // Waypoint reached, select next one
            else cur++;


            if (cur == WayPoints.Length)
            {
                cur = 0;
                IsHome = false;
            }
            // Animation
            Dir = DesPos - GhostPos;
            GhostAnim.SetFloat("DirX", Dir.x);
            GhostAnim.SetFloat("DirY", Dir.y);
        }
    }
    private void GhostMove_Outside_Home(bool home_trigger,bool alive_trigger)
    {
        if (home_trigger == false && alive_trigger == true)
        {
            //GhostMove();
            if (GameManager.FleeMode == false)
            {
                GhostAnim.SetBool("Flee", false);
                Ghost_Move(TrackTarget(Pacman.instance.transform));
            }
            else
            {
                GhostAnim.SetBool("Flee", true);
                int i;
                int[] dir_x = new int[4] { -1, 1, 0, 0 };
                int[] dir_y = new int[4] { 0, 0, 1, -1 };
                Vector2 PacmanPos = Pacman.instance.transform.position;
                Transform tmp = new GameObject().GetComponent<Transform>();

                tmp.position = new Vector2((int)29 - (int)PacmanPos.x, (int)32 - (int)PacmanPos.y);//맵 내부에서 팩맨과 가운데 지점과 점대칭인 지점으로 적은 도망간다
                i = 0;
                while (MapMatrix.Map[(int)tmp.position.x, (int)tmp.position.y] == -1)
                {
                    Debug.Log("점 대칭 지점을 못 찾았습니다!");//점대칭인 부분이 벽으로 막혀있을 땐, 점 대칭 지점을 보정한다
                    if (MapMatrix.Map[(int)tmp.position.x + dir_x[i], (int)tmp.position.y + dir_y[i]] == 0)
                    {
                        tmp.position = new Vector2((int)tmp.position.x + (int)dir_x[i], (int)tmp.position.y + (int)dir_y[i]);
                        Debug.Log("점 대칭 지점을 보정했습니다!");
                    }
                    i++;
                }
                Ghost_Move(TrackTarget(tmp));
            }
        }

    }
    private Vertex TrackTarget(Transform target)
    {
        Queue VertexQueue = new Queue();
        VisitedMatrix Visit = new VisitedMatrix();
        Vertex GhostVertex = new Vertex(gameObject.transform.position);
        Vertex CurVertex,TmpVertex;

        int nodes_left_in_layer = 1;
        int nodes_in_next_layer = 0;
        int i;
    
        int[] dir_x = new int[4] {-1,1,0,0 };
        int[] dir_y = new int[4] { 0, 0, 1, -1 };

        int src_x, src_y;//ghost의 위치
        int des_x, des_y;//pacman의 위치
        int cur_x, cur_y;//현재 vertex의 위치
        int tmp_x, tmp_y;//다음 vertex의 위치

        src_x = (int)GhostVertex.VertexPos.x;
        src_y = (int)GhostVertex.VertexPos.y;
        des_x = (int)target.position.x;
        des_y = (int)target.position.y;
        
        VertexQueue.Enqueue(GhostVertex);
        Visit.Visited[src_x, src_y] = 1;

        while (VertexQueue.size() > 0)
        {
            CurVertex = VertexQueue.Dequeue();
            cur_x = (int)CurVertex.VertexPos.x;
            cur_y = (int)CurVertex.VertexPos.y;

            if (cur_x==des_x&&  cur_y==des_y)
            {
                Debug.Log(CurVertex.VertexPos);
                return CurVertex;
                
            }

            //이웃 조사
            for (i = 0; i < 4; i++)
            {
                TmpVertex = new Vertex(new Vector2(cur_x+dir_x[i],cur_y+dir_y[i]));
                tmp_x = (int)TmpVertex.VertexPos.x;
                tmp_y = (int)TmpVertex.VertexPos.y;

                if (Visit.Visited[tmp_x, tmp_y] == 1) continue;
                if (MapMatrix.Map[tmp_x, tmp_y] == -1) continue;

                TmpVertex.PreVertexAddr = CurVertex;//현재 vertex와 연결하기
                VertexQueue.Enqueue(TmpVertex);

                Visit.Visited[tmp_x, tmp_y] = 1;
                nodes_in_next_layer++;
            }
            //이웃조사 
            nodes_left_in_layer--;

            if (nodes_left_in_layer == 0)
            {
                nodes_left_in_layer = nodes_in_next_layer;
                nodes_in_next_layer = 0;

            }
        }

        Debug.Log("Can't find Target!");
        return null;
        

        
    }
    
    private void Ghost_Move(Vertex start)
    {
        Stack VertexStack = new Stack();
        Vector2 CurPos,NextStep;
        Vector2 delta, dir;
        Vertex i;
        i = start;

        if (i == null) Debug.Log("ErroR!!");

        while (true)
        {
            VertexStack.Push(i);
            if (i.PreVertexAddr == null) break;
            else i = i.PreVertexAddr;
        }
        CurPos=VertexStack.Pop().VertexPos;
        NextStep = VertexStack.Pop().VertexPos;

        delta = Vector2.MoveTowards(CurPos, NextStep, Speed);
        GhostRB.MovePosition(delta);
        Debug.Log("Move!");
        dir = NextStep - CurPos;


        GhostAnim.SetFloat("DirX", dir.x);
        GhostAnim.SetFloat("DirY", dir.y);

    }

    private void ReturnHome(bool home_trigger,bool alive_trigger)
    {
        if (home_trigger == false&&alive_trigger==false)
        {
            Vector2 GhostPos = new Vector2((int)gameObject.transform.position.x, (int)gameObject.transform.position.y);
            Vector2 Delta,DesPos,Dir;


            if (GhostPos != (Vector2)ReturnPoints[0].position && bIsReached == false)
            {
                Ghost_Move(TrackTarget(ReturnPoints[0]));

            }
            else
            {
                bIsReached = true;

                DesPos = ReturnPoints[cur].position;
                // Waypoint not reached yet? then move closer
                if (GhostPos != DesPos)
                {
                    Delta = Vector2.MoveTowards(GhostPos, DesPos, Speed);
                    GhostRB.MovePosition(Delta);
                }
                // Waypoint reached, select next one
                else cur++;


                if (cur == ReturnPoints.Length)
                {
                    cur = 0;
                    GameManager.ReturnedGhostCount++;
                    SFXManager.instance.PlaySFXGhostReturn();
                    IsHome = true;
                }
                // Animation
                Dir = DesPos - GhostPos;
                GhostAnim.SetFloat("DirX", Dir.x);
                GhostAnim.SetFloat("DirY", Dir.y);
            }
            
            
                        
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pacman"&&IsAlive==true)
        {
            if (GameManager.FleeMode == false)
            {
                SFXManager.instance.PlaySFXPacmanDie();
                Destroy(collision.gameObject);
                
            }
            else//FleeMode이면
            {
                SFXManager.instance.PlaySFXGhostDie();
                GameManager.GhostCount--;
                Speed = 0.1f;
                IsAlive = false;//죽은 상태가 된다
            }
        }
    }
}
