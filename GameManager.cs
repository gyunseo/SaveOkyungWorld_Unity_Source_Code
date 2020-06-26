using System.Collections;
using System.Collections.Generic;
using UnityEngine;//김상협 왔다감


public class GameManager : MonoBehaviour
{
    public MapMatrix Map_Matrix = new MapMatrix();
    public static bool FleeTrigger,FleeMode;
    public static GameManager instance;
    public GameObject PacDot;
    public static int GhostCount;
    public static int ReturnedGhostCount;
    public static int PacDotCount;
    public static bool Victory;//게임 승리 조건
    public static bool Defeat;//게임 패배 조건
    public GameObject PauseManager;
    // Start is called before the first frame update

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        ReturnedGhostCount = 0;
        GhostCount = 3;//고스트가 죽을 때마다, 차감

        Victory = false;
        Defeat = false;
        PacDotCount = 0;
        FleeTrigger = false;
        FleeMode = false;
        Map_Matrix.ClearMatrix();//매트릭스 0으로 초기화
    }
    void Start()
    {
        
        SpawnPacDot();//PacDot생성, 생성과 동시에 벽이 있는 부분은 -1로 처리가 됨
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckFleeTrigger();
        Victory = UpdateVictory();
        Defeat = UpdateDefeat();
    }

    private void SpawnPacDot()//PacDot을 Spawn하는 모듈
    {
        int i, j;
        int cherry_trigger;
        cherry_trigger = Random.Range(0,2);

        Vector2 SpawnPos;//Instantiate되는 좌표를 담는 변수
        for (i = 1; i < 32; i++)
        {
            for (j = 1; j < 29; j++)
            {
                SpawnPos = new Vector2((float)j, (float)i);
                Instantiate(PacDot, SpawnPos, Quaternion.identity);
                
            }
        }
    }
    private bool UpdateVictory()
    {
        if (PacDotCount >= 320)
        {
            Time.timeScale = 0f;
            PauseManager.SetActive(true);
            BGMManager.instance.PlayVictoryBGM();
            return true;
        }
        else if (GhostCount <= 0 && ReturnedGhostCount>=3)
        {
            Time.timeScale = 0f;
            PauseManager.SetActive(true);
            BGMManager.instance.PlayVictoryBGM();
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool UpdateDefeat()
    {
        if (Pacman.instance==null)
        {
            Time.timeScale = 0f;
            PauseManager.SetActive(true);
            BGMManager.instance.PlayDefeatBGM();
            Debug.Log("!!No Pacman!!");
            return true;
        }
        else if (Timer.time <= 0)
        {
            Time.timeScale = 0f;
            PauseManager.SetActive(true);
            BGMManager.instance.PlayDefeatBGM();
            Debug.Log("!!No Time!!");
            return true;
        }
        
        else
        {
            return false;
        }
    }
    private void CheckFleeTrigger()
    {
        if (FleeTrigger == true&&FleeMode==false)//&&FleeMode는 플리 모드가 진행중 일 때, 한번 더 먹어도 소용이 없다는 걸 제한을 걸어주기 위해
        {
            GameManager.FleeTrigger = false;
            StartCoroutine("PlayFleeMode");
        }
    }
    public void ResetGame()
    {
        GhostCount = 3;//고스트가 죽을 때마다, 차감
        ReturnedGhostCount = 0;
        Victory = false;
        Defeat = false;
        PacDotCount = 0;
        FleeTrigger = false;
        FleeMode = false;

        SpawnPacDot();
    }
    IEnumerator PlayFleeMode()
    {
        BGMManager.instance.PlayFleeBGM();
        FleeMode = true;
        yield return new WaitForSeconds(7.0f);
        FleeMode = false;
        BGMManager.instance.PlayIdleBGM();
    }
}
