using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 코루틴 및 CSV 파일 TextAsset 입력 예제
public class Demo01 : MonoBehaviour {
    [SerializeField] TMP_Text text;
    [SerializeField] TextAsset csvAsset;

    List<string> scripts = new List<string>(); // 스크립트 데이터를 저장할 리스트입니다.
    int position = 0; // 현재 대사의 출력 위치입니다.
    bool isPrinting = false; // 현재 대사가 출력중인지 확인합니다.
    Coroutine coroutine; // 현재 대사를 출력하는 코루틴을 저장합니다.

    void Start() {
        ReadData(); // 먼저 파일을 읽어옵니다.
    }

    void Update() {
        if (Input.anyKeyDown) { // 만약 아무 키나 눌렀을 때
            if (!isPrinting) { // 만약 출력 중이 아니라면
                if (position < scripts.Count) PrintText(); // 다음 대사가 있다면 출력합니다.
                else Application.Quit(); // 없다면 게임을 종료합니다?
            } else { // 출력 중이라면
                StopCoroutine(coroutine); // 출력 중인 코루틴을 멈추고
                isPrinting = false; // 출력 중이 아님을 표시하고
                text.text = scripts[position]; // 대사는 한 번에 전부 보여줍니다.
            }
        }
    }

    void ReadData() {
        string[] datas = csvAsset.text.Split(new char[] { '\n' }); // 한 줄씩 배열로 저장합니다.
        foreach (string data in datas) {
            // csv 파일은 쉼표로 구분하기에 한 줄마다 쉼표를 기준으로 잘라 배열로 저장합니다.
            string[] lines = data.Split(new char[] { ',' }); 
            // 대사에 쉼표를 출력하기 위해 입력한 '-'를 모두 ','로 바꿔준 뒤 저장합니다.
            scripts.Add(lines[1].Replace('-', ','));
        }
        // 대사를 모두 읽어왔다면 첫 번째 대사 출력을 시작합니다.
        PrintText();
    }

    void PrintText() {
        // 대사 출력을 시작합니다.
        coroutine = StartCoroutine(PrintText(scripts[position++]));
    }

    IEnumerator PrintText(string script) {
        isPrinting = true; // 출력 중임을 알립니다.
        for (int i = 1; i <= script.Length; i++) { // 대사의 글자 수만큼 반복합니다.
            text.text = script.Substring(0, i); // 대사를 한 글자씩 나타나게끔 출력합니다.
            yield return new WaitForSeconds(0.1f); // 0.1초만큼 기다렸다가 반복문을 실행합니다. 코루틴문에서 필수적으로 들어가야하는 구문입니다.
        }
        isPrinting = false; // 출력이 끝났음을 알립니다.
    }
}
