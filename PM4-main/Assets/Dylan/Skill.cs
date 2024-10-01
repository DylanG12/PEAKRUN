using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static SkillTree;
using static Shooting;

public class Skill : MonoBehaviour
{
    public int id;

    public TMP_Text TitleText;
    public TMP_Text DescriptionText;

    public void UpdateUI()
    {
        TitleText.text = $"{skillTree.skillLevels[id]}/{skillTree.skillCaps[id]}\n{skillTree.skillNames[id]}";
        DescriptionText.text = $"{skillTree.skillDescriptions[id]}\nCost: {skillTree.skillPoint}/1 SP";

        
    }

    public void Buy()
    {
        if (skillTree.skillPoint < 1 || skillTree.skillLevels[id] >= skillTree.skillCaps[id]) return;
        skillTree.skillPoint -= 1;
        skillTree.skillLevels[id]++;
        skillTree.UpdateAllSkillUi();
        
        if (id == 0)
        {
            shoot.timeBetweenFiring -= 0.1f;
        }
        else if (id == 2)
        {
            shoot.totalMaxAmmo += 3;
        }
        else if (id == 3)
        {

        }
    }
 }
