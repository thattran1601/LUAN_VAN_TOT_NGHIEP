using UnityEngine;

public class AnimtionGacha : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenAnimator()
    {
        animator.SetBool("open", true);
    }

    public void ShowReward()
    {
        GachaUI.instance.ShowReward();
    }

    public void CloseAnimator()
    {
        animator.SetBool("open", false);
    }
}