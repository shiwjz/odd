using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoImages : MonoBehaviour
{
    [SerializeField] private Image[] images; // 자동으로 변경될 이미지 컴포넌트 배열
    [SerializeField] private Sprite[] defaultSprites; // 기본 스프라이트 배열
    [SerializeField] private Sprite[] clickedSprites; // 클릭 시 변경될 스프라이트 배열
    private float changeInterval = 2f; // 이미지 변경 간격 (초)
    void Start()
    {
        // 초기 스프라이트 설정
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = defaultSprites[i];
        }

        // 자동 이미지 변경 시작
        StartCoroutine(AutoChangeImage());
    }

    private IEnumerator AutoChangeImage()
    {
        while (true)
        {
            // 모든 이미지를 'clicked' 상태로 변경
            for (int i = 0; i < images.Length; i++)
            {
                images[i].sprite = clickedSprites[i];
            }
            yield return new WaitForSeconds(changeInterval); // 2초 대기

            // 모든 이미지를 'default' 상태로 변경
            for (int i = 0; i < images.Length; i++)
            {
                images[i].sprite = defaultSprites[i];
            }
            yield return new WaitForSeconds(changeInterval); // 2초 대기
        }
    }
}