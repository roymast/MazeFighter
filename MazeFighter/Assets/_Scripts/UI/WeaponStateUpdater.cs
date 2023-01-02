using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponStateUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI WeaponName;
    [SerializeField] Image WeaponSprite; 
    [SerializeField] TextMeshProUGUI Damage;
    [SerializeField] TextMeshProUGUI Bullets;
    [SerializeField] TextMeshProUGUI Clips;
    [SerializeField] IWeapon weapon;

    private void Start()
    {
        IWeapon.OnWeaponChange += OnWeaponChange;
    }

    private void OnWeaponChange(WeaponSO obj)
    {
        WeaponName.text = obj.WeaponName;
        WeaponSprite.sprite = obj.Sprite;
        GunSO gunSO = (GunSO)obj;
        if (gunSO != null)
        {
            Damage.text = gunSO.BulletDamage.ToString();
            Bullets.text = gunSO.BulletsPerMagasine.ToString();
            Clips.text = gunSO.MagasinesAmount.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {        
    }
}
