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

    public Dictionary<WeaponType,TMP_Text> AmmoFields = new Dictionary<WeaponType,TMP_Text>();

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

        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        foreach (var text in texts)
        {
            switch (text.gameObject.name)
            {
                case "Ammo":
                    Ammo = text;
                    break;
                case "Weapon1":
                    AmmoFields.Add(WeaponType.Pistol, text);
                    break;
                case "Weapon2":
                    AmmoFields.Add(WeaponType.Shotgun, text);
                    break;
                case "Weapon3":
                    AmmoFields.Add(WeaponType.MachineGun, text);
                    break;
                case "Weapon4":
                    AmmoFields.Add(WeaponType.Sniper, text);
                    break;
                case "Weapon5":
                    AmmoFields.Add(WeaponType.RocketLauncher, text);
                    break;
                case "Weapon6":
                    AmmoFields.Add(WeaponType.GranadeLauncher, text);
                    break;
                case "Weapon7":
                    AmmoFields.Add(WeaponType.Laser, text);
                    break;
            }
        }

        GameEvents.AmmoChangeEvent.AddListener((currentAmmo, maxAmmo) =>
        {
            Ammo.text = $"{currentAmmo} / {maxAmmo}";
        });

        GameEvents.AmmoPlayerEvent.AddListener((type, currentAmmo, maxAmmo) =>
        {
            AmmoFields[type].text = $"{currentAmmo} / {maxAmmo}";
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
