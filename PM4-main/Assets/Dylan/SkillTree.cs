using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Skill;

public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public int[] skillLevels;
    public int[] skillCaps;
    public string[] skillNames;
    public string[] skillDescriptions;

    public List<Skill> skillList;
    public GameObject skillHolder;

    public int skillPoint;
    private void Start()
    {
        skillTree.skillPoint = 0;

        skillLevels = new int[3];
        skillCaps = new[] { 5, 2, 5 };

        skillNames = new[] { "Bullet speed increase", "Health increase", "Ammo capacity increase", };
        skillDescriptions = new[]
        {
            "Increases how fast your bullets travel",
            "Increases the maxium amount of hits you can take",
            "Increase the maximum amount of ammo you can hold",
        };
        foreach (var skill in skillHolder.GetComponentsInChildren<Skill>()) skillList.Add(skill);

        for (var i = 0; i < skillList.Count; i++) skillList[i].id = i;

        UpdateAllSkillUi();
    }
    public void UpdateAllSkillUi()
    {
        foreach (var skill in skillList) skill.UpdateUI();
    }
}