using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleLobbyUI : MonoBehaviour
{
    public static CastleLobbyUI Instance;
    public GameObject PanelChonThanh;

    public Button ButtonChonPhysical;
    public TextMeshProUGUI TextButtonPhysical;

    public Button ButtonChonMagic;
    public TextMeshProUGUI TextButtonMagic;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PanelChonThanh.SetActive(false);
        RefectUI();
    }

    public void RefectUI()
    {
        int Selected = SaveGameManager.instance.LoadCastleSelected();
        TextButtonPhysical.text = Selected == 0 ?"SELECTED":"SELECT";
        TextButtonMagic.text = Selected == 1 ? "SELECTED" : "SELECT";
    }    
    public void MagicSelected()
    {
        CastleManager.Instance.SelectMagic();
        TextButtonMagic.text = "SELECTED";
        TextButtonPhysical.text = "SELECT";

    }
    public void PhysocalSelected()
    {
        CastleManager.Instance.SelectPhysical();
        TextButtonPhysical.text = "SELECTED";
        TextButtonMagic.text = "SELECT";

    }
    public void OpenPanel()
    {
        PanelChonThanh.SetActive(true);
        RefectUI();
    }

    public void ClosePanel()
    {
        PanelChonThanh.SetActive(false);
       
    }
  
}