using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GoldSpawner goldSpawner; // GoldSpawner 스크립트를 할당할 변수

    void Start()
    {
        // GoldSpawner 스크립트를 찾아 할당
        goldSpawner = FindObjectOfType<GoldSpawner>();
        if (goldSpawner == null)
        {
            Debug.LogError("GoldSpawner 스크립트를 찾을 수 없습니다.");
        }
    }

    // 버튼을 누를 때 호출되는 함수
    public void OnButtonClick()
    {
        // 골드 오브젝트 생성을 막기 위해 canSpawnGold 상태를 업데이트
        if (goldSpawner != null)
        {
            goldSpawner.canSpawnGold = false;
        }
    }
}