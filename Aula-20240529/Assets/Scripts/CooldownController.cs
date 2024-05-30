using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    protected Image CooldownImage;

    private void Awake()
    {
        CooldownImage = GetComponent<Image>();
        CooldownImage.fillAmount = 0;
        CooldownImage.fillOrigin = (int)Image.Origin360.Top;
        CooldownImage.gameObject.SetActive(false);
    }

    public void DispatchCooldown(float duration)
    {
        CooldownImage.gameObject.SetActive(true);
        StartCoroutine(RunCooldown(duration));
    }

    IEnumerator RunCooldown(float duration)
    {
        float ratio = 0;
        float totalDuration = duration;
        
        while (duration >= 0)
        {
            duration -= Time.deltaTime;
            ratio = duration / totalDuration;
            CooldownImage.fillAmount = 1f - ratio;
            yield return new WaitForEndOfFrame();
        }

        CooldownImage.gameObject.SetActive(false);
    }
}
