using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitTooltipTrigger : MonoBehaviour,
    IPointerEnterHandler, 
    IPointerExitHandler
{
    public UnitData unitData;
    public Outline outline;
    private void Start()
    {
        outline.enabled = false;
    }
    public void OnPointerEnter(PointerEventData evendata)
    {
        if (UnitTooltipUI.instance == null)
        {
            Debug.LogError("Chưa có UnitTooltipUI trong scene");
            return;
        }
        outline.enabled = true;

        if (unitData == null)
        {
            Debug.LogError("Chưa gán UnitData cho button này");
            return;
        }

        UnitTooltipUI.instance.show(unitData, evendata.position);
    }
    public void OnPointerExit(PointerEventData evendata)
    {
        outline.enabled = false;
        UnitTooltipUI.instance.hide();
    }
}
