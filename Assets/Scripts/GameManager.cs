using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public long blood;
    public long bloodIncomePerSecond;

    public TMP_Text totalBloodText;
    public TMP_Text bloodIncomeText;

    private float timePassed;
    public static GameManager instance;

    private SoundManager soundManager;

    private void Awake()
    {
        instance = this;
        UpdateText();
    }

    private void Start()
    {
        soundManager = SoundManager.instance;
    }

    private void Update()
    {
        if (timePassed >= 1f)
        {
            timePassed = 0f;
            
            AddBlood(bloodIncomePerSecond);
        }

        timePassed += Time.deltaTime;
    }

    public void AddBlood(long amount)
    {
        blood += amount;
        UpdateText();
    }

    public void AddBloodPerSecond(long amount)
    {
        bloodIncomePerSecond += amount;
        UpdateText();
    }

    public void ReduceBlood(long amount)
    {
        if (blood - amount < 0)
            return;

        blood -= amount;
        UpdateText();
    }

    public void PressHeart()
    {
        int amount = Mathf.FloorToInt(bloodIncomePerSecond + 2) / 2;
        if (amount <= 0)
            amount = 1;

        soundManager.Play("HeartBeat");
        AddBlood(amount);
    }
    
    private void UpdateText()
    {
        totalBloodText.text = $"Blood: {blood.ToString()} litres";
        bloodIncomeText.text = $"Income: {bloodIncomePerSecond.ToString()} litres";
    }
}
