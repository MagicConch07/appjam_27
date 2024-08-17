using System;
using System.Collections;
using System.Collections.Generic;
using MKDir;
using UnityEngine;
// 사람이 오는거, 대사 치거나, 아니면 바로 주문.
// 게임 매니저로 시간흐름. 일정시간 지나면 다음날.
// 돈 증가.
public class NewBehaviourScript : MonoSingleton<NewBehaviourScript>
{
    int People; // 사람 수
    float Money; // 돈
    public float P_ArrivalCycle = 0.8f; // 사람이 오는 쿨타임.
    public float Min_Money = 3000f; // 최저로 받을 수 있는 돈
    public float Max_Money = 23000f; // 최대로 받을 수 있는 돈 ( 추후 수정예정 )
    public String[] AlcoholKind = {"블랙 러시안", "준벅", "홀리갓", "킹헤븐", "갓소오", "코코맘", "호라이즌", "실버스피릿", "King Nara", "오스틴콰이엇", "고려파갈로", "열고스피릿", "레드와인", "화이트와인", "포도와인", "보드카", "데킬라"}; // 술 종류
    public String[] A_Material = {"체리", "파인애플", "샤인머스캣", "오렌지", "코코넛", "바나나", "키위", "커피", "막걸리", "위스키", "데킬라", "포도와인", "소주", "보드카"};
    String Material;
    String QuestAlcohol; // 손님이 요청할 술.
    String MakeAlcohol; // 내가 만들 술.
    bool QuestSuccess = false; // 요청 성공 여부.

    // Start is called before the first frame update
    void Start()
    {
        People = 0;
        Money = 0f;
        Debug.Log("1. 체리 | 2. 파인애플 | 3. 샤인머스캣 | 4. 오렌지 | 5. 코코넛 | 6. 바나나 | 7. 키위\nA. 커피 | B. 막걸리 | C. 위스키 | D. 데킬라 | E. 포도와인 | F. 소주 | G. 보드카");
        StartCoroutine(SpawnPeople());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Material = A_Material[0]; // 체리
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Material = A_Material[1]; // 파인애플
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Material = A_Material[2]; // 샤인머스캣
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            Material = A_Material[3]; // 오렌지
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            Material = A_Material[4]; // 코코넛
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            Material = A_Material[5]; // 바나나
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            Material = A_Material[6]; // 키위
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.A)) {
            Material = A_Material[7]; // 커피
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.B)) {
            Material = A_Material[8]; // 막걸리
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.C)) {
            Material = A_Material[9]; // 위스키
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Material = A_Material[10]; // 데킬라
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.E)) {
            Material = A_Material[11]; // 포도와인
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.F)) {
            Material = A_Material[12]; // 소주
            CheckAlcohol();
        } else if (Input.GetKeyDown(KeyCode.G)) {
            Material = A_Material[13]; // 보드카
            CheckAlcohol();
        }
    }

    IEnumerator SpawnPeople() {
        while (true) {
            yield return new WaitForSeconds(P_ArrivalCycle);
            if (!QuestSuccess) {
            People++;
            Debug.Log("새로운 손님이 오셨습니다. 현제까지 방문한 사람 수 : " + People);
            
            RandomQuest();
            QuestSuccess = true;
            }
        }
    }
    void RandomQuest() {
        int RandomAlcohol = UnityEngine.Random.Range(0, 1);
        QuestAlcohol = AlcoholKind[RandomAlcohol];
        Debug.Log("손님이 주문한 술은 " + QuestAlcohol);
    }
    void CheckAlcohol() {
        if ( AlcoholKind[0] == A_Material[7] + A_Material[13] ) {
            SuccessRequest();
        } else if ( AlcoholKind[1] == A_Material[10] + A_Material[0] + A_Material[1] ) {
            SuccessRequest();
        }

        StartCoroutine(WaitPeople());
    }
    void SuccessRequest() {
        float Get_Money = UnityEngine.Random.Range(Min_Money, Max_Money);
        Money += Get_Money;
        Debug.LogFormat("손님이 만족하셨습니다. 돈이 {0}원 만큼 증가하셨습니다. 총 돈 : {1}", Get_Money, Money);
    }
    IEnumerator WaitPeople() {
        yield return new WaitForSeconds(P_ArrivalCycle);
        QuestSuccess = false;
    }
}
