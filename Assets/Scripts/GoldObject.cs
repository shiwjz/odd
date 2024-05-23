using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GoldObject : MonoBehaviour
{
    public int goldAmount;
    private Rigidbody2D rb;
    

    void Start()
    {
        // 씬 이름을 확인하여 샵이나 세팅 씬에서만 골드 오브젝트 생성
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Menu")
        {
            goldAmount = Random.Range(1, 100);
            GetComponentInChildren<TextMeshProUGUI>().text = goldAmount.ToString();
            GetComponent<Button>().onClick.AddListener(OnButtonClick);

            rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;

            // 3초 후에 오브젝트를 파괴합니다.
            Invoke("DestroyObject", 3.0f); // 3초 후에 실행
        }
        else
        {
            // 다른 씬에서는 골드 오브젝트 생성하지 않음
            Destroy(gameObject);
        }
    }

    void OnButtonClick()
    {
        // 골드를 추가하고 오브젝트를 즉시 파괴합니다.
        DataController.GetInstance().AddGold(goldAmount);
        rb.isKinematic = false; // 떨어지는 모션 유지
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

}