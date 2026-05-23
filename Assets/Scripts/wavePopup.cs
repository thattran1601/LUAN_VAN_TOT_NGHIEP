using System.Collections;
using TMPro;
using UnityEngine;

public class wavePopup : MonoBehaviour
{
    public static wavePopup Intance;

    public TextMeshProUGUI WaveText;

    public CanvasGroup canvasGroup;

    private void Awake()
    {
        Intance = this;
    }
    private void Start()
    {
        canvasGroup.alpha = 0;
    }

    public IEnumerator wavepopup(int wave)
    {
        WaveData Wavecurrent = WaveManager.instance.currentmap.wave[WaveManager.instance.WaveCurrent - 1];
        if (Wavecurrent.isboss)
        {
            WaveText.text = "⚠WARNING⚠";
            canvasGroup.alpha = 1;
            WaveText.color = Color.red;

            yield return new WaitForSeconds(1.5f);

            float time = 0;

            while (time < 1)
            {
                time += Time.deltaTime;

                canvasGroup.alpha =
                    Mathf.Lerp(1, 0, time);

                yield return null;
            }

            canvasGroup.alpha = 0;
        }
        else
        {
            WaveText.text =
                "WAVE " + wave;
            WaveText.color = Color.white;
            canvasGroup.alpha = 1;

            yield return new WaitForSeconds(1.5f);

            float time = 0;

            while (time < 1)
            {
                time += Time.deltaTime;

                canvasGroup.alpha =
                    Mathf.Lerp(1, 0, time);

                yield return null;
            }

            canvasGroup.alpha = 0;
        }
    }
}