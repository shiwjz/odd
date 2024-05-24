using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickButton : MonoBehaviour
{
   
    [SerializeField] private GameObject prefab; // 생성할 프리팹
    [SerializeField] private Transform canvasTransform; // 캔버스의 Transform
    [SerializeField] private float speed = 8;
    public AudioSource tapsource;
    public Image buttonImage; // 버튼의 이미지 컴포넌트
    public Sprite image1; // 기본 이미지
    public Sprite image2; // 클릭 시 변경될 이미지

    private int currentSpriteIndex = 0; // 현재 스프라이트 인덱스

    
    

    public void OnClick()
    {
        tapsource.Play();
        AddGold();
        FeverManager.Instance.RegisterClick();
        buttonImage.sprite = image2; // 이미지 변경
        Invoke("ResetImage", 0.5f); // 0.5초 후에 이미지 리셋
    }

    private void AddGold()
    {
        int goldPerClick = DataController.GetInstance().GetGoldPerClick();
        DataController.GetInstance().AddGold(goldPerClick);
        Function_Instantiate(); // 돈이 추가될 때 이미지를 생성합니다.
    }

    private void Function_Instantiate()
    {
        Vector2 clickPosition = Input.mousePosition;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform as RectTransform, clickPosition, null, out localPoint);
        GameObject Inst = Instantiate(prefab, canvasTransform);
        RectTransform rectTransform = Inst.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = localPoint;

        
        Rigidbody2D rb = Inst.GetComponent<Rigidbody2D>();
        
        

        // 랜덤한 방향과 크기의 힘 적용
        float randomForceX = Random.Range(-5f, 5f); // X축 방향 랜덤 힘
        float randomForceY = Random.Range(5f, 10f); // Y축 방향 랜덤 힘 (위로 튀게 하기 위해)
        rb.AddForce(new Vector2(randomForceX, randomForceY)*100, ForceMode2D.Impulse);

        Destroy(Inst, 2f); // 2초 후에 오브젝트 파괴
    }
    // 버튼 클릭 시 호출될 메소드
 

    // 이미지를 원래대로 복구하는 메소드
    private void ResetImage()
    {
        buttonImage.sprite = image1; // 원래 이미지로 복구
    }


}