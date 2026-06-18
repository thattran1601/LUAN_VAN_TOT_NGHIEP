using UnityEngine;

public class ManagerLimit : MonoBehaviour
{
    public static ManagerLimit instance;
    public Transform GioiHanChuyenDong;
    public Transform PositionUntil;
    private void Awake()
    {
        instance = this;
    }

}
