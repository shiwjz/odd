using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private Image buttonImage; // 버튼의 이미지 컴포넌트
    [SerializeField] private Sprite defaultSprite; // 기본 스프라이트 (이미지1)
    [SerializeField] private Sprite clickedSprite; // 클릭 시 변경될 스프라이트 (이미지2)
    [SerializeField] private GameObject prefab; // 생성할 프리팹
    [SerializeField] private Transform canvasTransform; // 캔버스의 Transform
    [SerializeField] private float speed = 8;
    private Vector3 mousePos;

    void Start()
    {
        buttonImage.sprite = defaultSprite; // 초기 스프라이트 설정
    }

    private void Update()
    {
        Get_Mose();
        Check_Transforms();
    }

    private void Get_Mose()
    {
        if(Input.GetMouseButtonDown(0))
        {
       
        }
    }

    private void Function_Instantiate()
    {
        Vector2 clickPosition = Input.mousePosition;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform as RectTransform, clickPosition, null, out localPoint);
        GameObject Inst = Instantiate(prefab, canvasTransform);
        RectTransform rectTransform = Inst.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = localPoint;
    }

    private void Check_Transforms()
    {
        for (int i = 0; i < canvasTransform.childCount; i++)
        {
            RectTransform rect = canvasTransform.GetChild(i).GetComponent<RectTransform>();
            if(rect.anchoredPosition.y < -(Screen.height + rect.rect.height)/2)
            {
                Destroy(rect.gameObject);
                continue;
            }
            rect.anchoredPosition += Vector2.down * speed;

         }
    }


    public void OnClick()
    {
        StartCoroutine(ChangeSpriteToClicked());
        AddGold();
        
    }

    private IEnumerator ChangeSpriteToClicked()
    {
        buttonImage.sprite = clickedSprite; // 클릭 시 스프라이트 변경
        yield return new WaitForSeconds(0.5f); // 0.5초 대기
        buttonImage.sprite = defaultSprite; // 원래 스프라이트로 복귀
    }

    private void AddGold()
    {
        int goldPerClick = DataController.GetInstance().GetGoldPerClick();
        DataController.GetInstance().AddGold(goldPerClick);
        Function_Instantiate(); // 돈이 추가될 때 이미지를 생성합니다.
    }


    public void OnButtonClick()
    {
        Debug.Log("버튼이 클릭되었습니다 ");
    }
}