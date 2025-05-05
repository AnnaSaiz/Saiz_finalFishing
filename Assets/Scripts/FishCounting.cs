using TMPro;
using UnityEngine;

public class FishCounting : MonoBehaviour
{

    public TextMeshProUGUI fishCount;
    public TextMeshProUGUI score;

    public float currentFishCount;
    public bool gotAFish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      currentFishCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gotAFish == true)
        {
            currentFishCount += 1;
            UpdateFishCount();
        }
    }

    void UpdateFishCount()
    {
        fishCount.text = currentFishCount.ToString();
    }
}
