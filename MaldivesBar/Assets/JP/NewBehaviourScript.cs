using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 사람이 오는거. 요청사항. 돈 오르기?
public class NewBehaviourScript : MonoBehaviour
{
    int People;
    float Money;
    public float P_ArrivalCycle = 5f;
    public float Min_Money = 0f;
    public float Max_Money = 1000f;
    int Alcohol;
    int Quest;
    
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
            People++;
            Debug.Log("새로운 손님이 오셨습니다. 현제까지 방문한 사람 수 : " + People);

            float Get_Money = Random.Range(Min_Money, Max_Money);
            Money += Get_Money;
            Debug.LogFormat("손님이 만족하셨습니다. 돈이 {0}원 만큼 증가하셨습니다. 총 돈 : {1}", Get_Money, Money);
        }
    }
}
