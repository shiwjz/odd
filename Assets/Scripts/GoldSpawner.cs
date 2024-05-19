using Unity.VisualScripting;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject goldPrefab; // 골드 오브젝트의 프리팹
    public float spawnInterval = 1.0f; // 오브젝트를 생성하는 간격 (초)
    private RectTransform canvasRectTransform;

    void Start()
    {
        InvokeRepeating("SpawnGold", spawnInterval, spawnInterval);
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }


    private void SpawnGold()
    {
        float randomX = Random.Range(0, canvasRectTransform.rect.width);
        float randomY = Random.Range(228.1f, 1549.7f);
        GameObject gold = Instantiate(goldPrefab, canvasRectTransform);
        RectTransform goldRectTransform = gold.GetComponent<RectTransform>();
        goldRectTransform.anchoredPosition = new Vector2(randomX - canvasRectTransform.rect.width / 2, randomY - canvasRectTransform.rect.height / 2);
        
    }

}
