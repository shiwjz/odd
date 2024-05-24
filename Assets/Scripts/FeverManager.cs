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
    [SerializeField] private int feverGoldMultiplier = 2; // 피버 타임 동안 골드 배수
    [SerializeField] private  AudioSource feverSound; //피버 타임 소리 클립
    private int currentFeverCount; // 현재 클릭 수
    private bool isFeverActive; // 피버 타임 활성화 여부
    private float lastClickTime; // 마지막 클릭 시간
    private int originalGoldMultiplier; // 원래 골드 배수 저장
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
        if (Time.time - lastClickTime > 3f)
        {
            
            
                currentFeverCount = Mathf.Max(0, currentFeverCount - Mathf.CeilToInt(Time.deltaTime * decreaseRate));
                feverSlider.value = currentFeverCount;
                feverText.text = currentFeverCount + "/" + maxFeverCount;
            
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            StartFeverTime();
        }
    }

    public void RegisterClick()
    {
        if (isFeverActive) return; // 피버 타임 중에는 클릭 수를 증가시키지 않음

        lastClickTime = Time.time; // 마지막 클릭 시간 업데이트
        Debug.Log("Last Click Time updated to: " + lastClickTime);
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
        originalGoldMultiplier = DataController.GetInstance().GetGoldMultiplier(); // 원래 골드 배수 저장
        DataController.GetInstance().SetGoldMultiplier(feverGoldMultiplier); // 피버 타임 동안 골드 배수 적용
        StartCoroutine(FeverTimeCountdown());
        feverSound.Play();
    }

    private IEnumerator FeverTimeCountdown()
    {
        float countdown = feverTimeDuration;
        while (countdown > 0)
        {
            countdown -= Time.deltaTime;
            currentFeverCount = (int)(maxFeverCount * (countdown / feverTimeDuration));
            feverSlider.value = currentFeverCount;
            feverText.text = currentFeverCount + "/" + maxFeverCount;
            yield return null;
        }
        isFeverActive = false;
        DataController.GetInstance().SetGoldMultiplier(originalGoldMultiplier); // 피버 타임 종료 후 골드 배수를 원래대로 복구
        ResetFeverGauge();
        
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