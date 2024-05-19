using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldObject : MonoBehaviour
{
    public int goldAmount;
    // 버튼의 Rigidbody2D 컴포넌트
    private Rigidbody2D rb; 

    void Start()
    {
        goldAmount = Random.Range(1, 100);
        GetComponentInChildren<TextMeshProUGUI>().text = goldAmount.ToString();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);

        // Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();

        // 초기에는 Rigidbody2D를 비활성화합니다.
        rb.isKinematic = true;
    }

    void OnButtonClick()
    {
        // 버튼이 눌렸을 때 Rigidbody2D를 활성화하여 중력에 의해 떨어지게 합니다.
        rb.isKinematic = false;

        // 일정 시간 후에 골드를 추가하고 오브젝트를 파괴합니다.
        Invoke("AddGoldAndDestroy", 2.0f); // 2초 후에 실행
    }

    void AddGoldAndDestroy()
    {
        DataController.GetInstance().AddGold(goldAmount);
        Destroy(gameObject);
    }
}