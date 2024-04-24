using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudController : MonoBehaviour
{
    //public Image ReloadCooldown;

    public CooldownController ReloadCooldown;
    public TMP_Text Ammo;

    private void Awake()
    {
        //var images = GetComponentsInChildren<Image>();

        //foreach (var image in images)
        //{
        //    if(image.name == "ReloadCooldown")
        //    {
        //        ReloadCooldown = image;
        //    }
        //}
        ReloadCooldown = GetComponentInChildren<CooldownController>(true);

        GameEvents.WeaponReloadEvent.AddListener((duration) =>
        {
            ReloadCooldown.DispatchCooldown(duration);
        });

        Ammo = GetComponentInChildren<TMP_Text>();

        GameEvents.AmmoChangeEvent.AddListener((currentAmmo, maxAmmo) =>
        {
            Ammo.text = $"{currentAmmo} / {maxAmmo}";
        });
    }

    public void WeaponReloadEventListener(float duration)
    {

    }



    private void Update()
    {
        //ReloadCooldown.fillAmount += Time.deltaTime * 0.1f;
    }
}
