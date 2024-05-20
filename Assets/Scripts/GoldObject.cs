using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldObject : MonoBehaviour
{
    public int goldAmount;
    private Rigidbody2D rb;

    void Start()
    {
        goldAmount = Random.Range(1, 100);
        GetComponentInChildren<TextMeshProUGUI>().text = goldAmount.ToString();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // 3초 후에 오브젝트를 파괴합니다.
        Invoke("DestroyObject", 3.0f); // 3초 후에 실행
    }

    void OnButtonClick()
    {
        rb.isKinematic = false;
        Invoke("AddGoldAndDestroy", 2.0f);
    }

    void AddGoldAndDestroy()
    {
        DataController.GetInstance().AddGold(goldAmount);
        Destroy(gameObject);
    }

   
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}