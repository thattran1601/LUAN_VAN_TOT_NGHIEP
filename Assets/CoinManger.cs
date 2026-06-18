using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManger : MonoBehaviour
{
    public static CoinManger Instance;

    public TextMeshProUGUI TextCoin;
    public TextMeshProUGUI TextCoinGUI;
    public int Coin;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        LoadCoin();
        UpdateUICoin();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadCoin();

        GameObject obj = GameObject.Find("TextCoin");
        if (obj != null)
        {
            TextCoin = obj.GetComponent<TextMeshProUGUI>();
        }

        UpdateUICoin();
    }

    private void LoadCoin()
    {
        Coin = SaveGameManager.instance.GetCoin();
    }

    public bool HasCoin(int amount)
    {
        return SaveGameManager.instance.GetCoin() >= amount;
    }

    public void AddCoin(int amount)
    {
        SaveGameManager.instance.AddCoin(amount);
        LoadCoin();
        UpdateUICoin();
    }

    public bool RemoveCoin(int amount)
    {
        bool success = SaveGameManager.instance.SpendCoin(amount);

        if (!success)
        {
            Debug.Log("Không đủ vàng");
            return false;
        }

        LoadCoin();
        UpdateUICoin();

        Debug.Log("Đã trừ coin: " + amount + " | Coin còn lại: " + Coin);

        return true;
    }

    public void UpdateUICoin()
    {
        if (TextCoin != null)
        {
            TextCoin.text = Coin.ToString();
            TextCoinGUI.text = Coin.ToString();
        }
    }
}