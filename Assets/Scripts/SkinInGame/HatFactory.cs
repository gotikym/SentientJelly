using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HatFactory", menuName = "Gameplay/HatFactory")]
public class HatFactory : ScriptableObject
{
    [SerializeField] private Hat _croneHat;
    [SerializeField] private Hat _wizardHat;
    [SerializeField] private Hat _newYearsHat;
    [SerializeField] private Hat _cookingHat;
    [SerializeField] private Hat _magicHat;
    [SerializeField] private Hat _policeCap;
    [SerializeField] private Hat _sombrero;
    [SerializeField] private Hat _uncleSamHat;
    [SerializeField] private Hat _workHelmet;
    [SerializeField] private Hat _fbiCap;
    [SerializeField] private Hat _beerCap;
    [SerializeField] private Hat _shiba;
    [SerializeField] private Hat _husky;
    [SerializeField] private Hat _graduationCap;
    [SerializeField] private Hat _jesterHat;

    public Hat Get(HatSkins skinType, Transform spawnPosition)
    {
        Hat hat = Instantiate(GetPrefab(skinType), spawnPosition);

        return hat;
    }

    private Hat GetPrefab(HatSkins skinType)
    {
        return skinType switch
        {
            HatSkins.Crone => _croneHat,
            HatSkins.Wizard => _wizardHat,
            HatSkins.NewYears => _newYearsHat,
            HatSkins.CookingHat => _cookingHat,
            HatSkins.MagicHat => _magicHat,
            HatSkins.PolicCap => _policeCap,
            HatSkins.Sombrero => _sombrero,
            HatSkins.UncleSamHat => _uncleSamHat,
            HatSkins.WorkHelmet => _workHelmet,
            HatSkins.FBICap => _fbiCap,
            HatSkins.BeerCap => _beerCap,
            HatSkins.Shiba => _shiba,
            HatSkins.Husky => _husky,
            HatSkins.GraduationCap => _graduationCap,
            HatSkins.JesterHat => _jesterHat,
            _ => throw new ArgumentException(nameof(skinType)),
        };
    }
}