using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TextTyper : MonoBehaviour
{
    [SerializeField] private float GameTime = 0f;
    public float DayTime = 30f;
    int DayCount = 1;
    // Start is called be
    public TextMeshProUGUI textDisplay;  // TextMeshPro 텍스트 컴포넌트
    public TextMeshProUGUI TimeText;
    public float typingSpeed = 0.1f;  // 각 문자 사이의 시간 간격

    private string currentText = "";  // 현재 출력 중인 텍스트
    public String[] comment = {"거 죽기 딱 좋은 날씨오.", "이런 날에는 술이 딱이군요.", "오늘은 나를 위한 날 이구나.", "첫잔은 원샷!", "주인장? 늘 먹던걸로."};
    public String[] AlcoholKind1 = {"블랙 러시안", "준벅", "홀리갓", "킹헤븐", "갓소오", "코코맘", "호라이즌", "실버스피릿", "King Nara", "오스틴콰이엇", "고려파갈로", "열고스피릿", "레드와인", "화이트와인", "포도와인", "소주", "막걸리", "위스키", "데킬라", "보드카"}; // 술 종류

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeText());
    }
    void Update() {
        UpdateGameTime();
    }
    void UpdateGameTime() {
        GameTime += Time.deltaTime;
        if ( GameTime >= DayTime ) {
            NextDay();
        }
    }
    void NextDay() {
        String fullText = DayCount + "일차.";
        GameTime = 0f;
        DayCount++;
        currentText = fullText;
        TimeText.text = currentText;  // TextMeshPro 컴포넌트에 텍스트 할당
        Start();
    }

    // 코루틴으로 텍스트를 한 글자씩 출력하는 함수
    IEnumerator TypeText()
    {
        String fullText = comment[UnityEngine.Random.Range(0, comment.Length)] + "\n" + AlcoholKind1[UnityEngine.Random.Range(0, AlcoholKind1.Length)]  + " 한잔 주시오.";
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);  // 현재까지의 텍스트를 자름
            textDisplay.text = currentText;  // TextMeshPro 컴포넌트에 텍스트 할당
            yield return new WaitForSeconds(typingSpeed);  // 지정된 시간만큼 대기
        }
    }
}
