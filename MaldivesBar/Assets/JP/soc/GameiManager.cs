using System;
using System.Collections;
using System.Collections.Generic;
using MKDir;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
// 사람이 오는거, 대사 치거나, 아니면 바로 주문.
// 게임 매니저로 시간흐름. 일정시간 지나면 다음날.
// 돈 증가.


public class GameiManager : MonoSingleton<GameiManager>
{
    int People; // 사람 수
    float Money; // 돈
    public float[] A_Money = {11000, 18000, 17000, 21000, 5000, 13000, 16000, 15000, 23000, 14000, 7000, 8000, 7000, 6000, 6000, 4000, 3000, 7000, 8000, 7000};
    public float P_ArrivalCycle = 0.8f; // 사람이 오는 쿨타임.
    public String[] AlcoholKind = {"블랙 러시안", "준벅", "홀리갓", "킹헤븐", "갓소오", "코코맘", "호라이즌", "실버스피릿", "King Nara", "오스틴콰이엇", "고려파갈로", "열고스피릿", "레드와인", "화이트와인", "포도와인", "소주", "막걸리", "위스키", "데킬라", "보드카"}; // 술 종류
    String QuestAlcohol; // 손님이 요청할 술.
    bool QuestSuccess = false; // 요청 성공 여부.
    int DayCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        People = 0;
        Money = 0f;
        StartCoroutine(SpawnPeople());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnPeople() {
        while (true) {
            yield return new WaitForSeconds(P_ArrivalCycle);
            if (!QuestSuccess) {
            People++;
            Debug.Log("새로운 손님이 오셨습니다.");
            
            RandomQuest();
            QuestSuccess = true;
            }
        }
    }
    void RandomQuest() {
        int RandomAlcohol = UnityEngine.Random.Range(0, AlcoholKind.Length);
        QuestAlcohol = AlcoholKind[RandomAlcohol];
    }
    void SuccessRequest() {
        int RandomAlcohol = UnityEngine.Random.Range(0, AlcoholKind.Length);
        float Get_Money = A_Money[RandomAlcohol];
        Money += Get_Money;
        Debug.LogFormat("손님이 만족하셨습니다. 돈이 {0}원 만큼 증가하셨습니다. 총 돈 : {1}", Get_Money, Money);
    }
}
