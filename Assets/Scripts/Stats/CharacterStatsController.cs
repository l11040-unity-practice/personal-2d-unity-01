using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsController : MonoBehaviour
{
    [SerializeField] private CharacterStat BaseStat;
    public CharacterStat CurrentStat { get; private set; }
    public List<CharacterStat> Stats = new List<CharacterStat>();

    private void Awake()
    {
        UpdateStat();
    }

    private void UpdateStat()
    {
        CurrentStat = new CharacterStat { };

        CurrentStat.StatsChangeType = BaseStat.StatsChangeType;
        CurrentStat.MaxHealth = BaseStat.MaxHealth;
        CurrentStat.Speed = BaseStat.Speed;
    }

}