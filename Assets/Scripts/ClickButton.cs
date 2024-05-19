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

    void Start()
    {
        buttonImage.sprite = defaultSprite; // 초기 스프라이트 설정
    }

    public void OnClick()
    {
        StartCoroutine(ChangeSpriteToClicked());
        AddGold();
        DropPrefabAtClickPosition();
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
        // 여기에 추가적인 클릭 로직을 구현할 수 있습니다.
    }

    private void DropPrefabAtClickPosition()
    {
        // 'Screen Space - Overlay' 모드에서는 카메라 변환 없이 마우스 위치를 사용
        Vector3 clickPosition = Input.mousePosition;
        clickPosition.z = 0; // 2D 환경에서 z축은 0으로 설정

        // 프리팹을 클릭한 위치에 생성
        GameObject instance = Instantiate(prefab, clickPosition, Quaternion.identity);
        instance.transform.SetParent(canvasTransform, false); // 캔버스를 부모로 설정
        instance.AddComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 추가
        Destroy(instance, 2f); // 2초 후에 프리팹 파괴
    }
    public void OnButtonClick()
    {
        Debug.Log("버튼이 클릭되었습니다 ");
    }
}