using TMPro;
using UnityEngine;

public class UnitTooltipUI : MonoBehaviour
{
    public static UnitTooltipUI instance;
    public RectTransform tooltipRect;
    public TextMeshProUGUI text;
    public Vector2 offright = new Vector2(180, 0);
    public Vector2 offleft=new Vector2(-180,0);
    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }
    public void show(UnitData unit,Vector2 mouse)
    {
        gameObject.SetActive(true);
        Vector2 finalPosition = mouse;
        if(mouse.x<Screen.width/2f)
        {
            finalPosition += offright;
        }
        else
        {
            finalPosition += offleft;
        }
        UnitRuntimeData runtime = UnitOwnedManager.Instance.GetRuntime(unit.Id);
        int hp = UnitStatCalculator.getHp(unit, runtime.Level);
        int dame = UnitStatCalculator.getDame(unit, runtime.Level);
        tooltipRect.position = finalPosition;
        text.text= unit.name +"\n"+
           "HP: "+ hp+"\n"+
           "Damage: " + dame+"\n"+
            "Cooldown: " + unit.Cooldown+"s"+"\n"+
            "Cost: " + unit.cost+"\n";
    }    
    public void hide()
    {
        gameObject.SetActive(false);
    }    
}
