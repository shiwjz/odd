using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeverManager : MonoBehaviour
{
    public static FeverManager Instance;

    [SerializeField] private Slider feverSlider; // 피버 게이지 슬라이더
    [SerializeField] private TextMeshProUGUI feverText; // 피버 텍스트
    [SerializeField] private int maxFeverCount = 150; // 피버 타임을 위한 최대 클릭 수
    [SerializeField] private float feverTimeDuration = 5f; // 피버 타임 지속 시간
    [SerializeField] private float decreaseRate = 1f; // 게이지 감소 속도 (초당 감소량)
    [SerializeField] private float originalGoldMultiplier = 1f;
    [SerializeField] private float feverGoldMultiplier = 2f;

    private int currentFeverCount; // 현재 클릭 수
    private bool isFeverActive; // 피버 타임 활성화 여부
    private float lastClickTime; // 마지막 클릭 시간

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        feverSlider.maxValue = maxFeverCount;
        feverSlider.value = 0;
        currentFeverCount = 0;
        isFeverActive = false;
        feverText.text = "0/" + maxFeverCount;

        feverSlider.interactable = false;
    }

    void Update()
    {
        if (!isFeverActive && currentFeverCount > 0)
        {
            if (Time.time - lastClickTime > 3f) // 3초 이상 클릭이 없으면
            {
                currentFeverCount = Mathf.Max(0, currentFeverCount - (int)(Time.deltaTime * decreaseRate));
                feverSlider.value = currentFeverCount;
                feverText.text = currentFeverCount + "/" + maxFeverCount;
            }
        }
    }

    public void RegisterClick()
    {
        if (isFeverActive) return; // 피버 타임 중에는 클릭 수를 증가시키지 않음

        lastClickTime = Time.time; // 마지막 클릭 시간 업데이트
        currentFeverCount++;
        feverSlider.value = currentFeverCount;
        feverText.text = currentFeverCount + "/" + maxFeverCount;

        if (currentFeverCount >= maxFeverCount)
        {
            StartFeverTime();
        }
    }

    private void StartFeverTime()
    {
        isFeverActive = true;
        feverText.text = "FEVER";
        StartCoroutine(FeverTimeCountdown());
        DataController.GetInstance().ResetGoldMultiplier();
        //DataController.GetInstance().SetGoldMultiplier(feverGoldMultiplier);
    }

    private IEnumerator FeverTimeCountdown()
    {
        yield return new WaitForSeconds(feverTimeDuration);

        DataController.GetInstance().ResetGoldMultiplier(); // 골드 획득량을 원래대로 리셋

        isFeverActive = false;
        currentFeverCount = 0;
        feverSlider.value = 0;
        feverText.text = "0/" + maxFeverCount;
        
    }

    public bool IsFeverActive()
    {
        return isFeverActive;
    }

    public void ResetFeverGauge()
    {
        currentFeverCount = 0;
        feverSlider.value = 0;
        feverText.text = "0/" + maxFeverCount;
        isFeverActive = false;
    }
}