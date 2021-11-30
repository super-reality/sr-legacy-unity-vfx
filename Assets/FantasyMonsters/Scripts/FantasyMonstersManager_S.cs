using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.FantasyMonsters.Scripts;

public class FantasyMonstersManager_S : MonoBehaviour
{
    public List<GameObject> monstersList = new List<GameObject>();

    GameObject currentMonster;

    private void Start()
    {
        if (monstersList[0])
            currentMonster = monstersList[0];
    }

    /// <summary>
    /// Change the monsters using the id in the parameter
    /// </summary>
    /// <param name="id"></param>
    public void ChangeMonsters(int id)
    {
        if (monstersList[id])
        {
            if (currentMonster)
            {
                currentMonster.SetActive(false);
                currentMonster = monstersList[id];
                currentMonster.SetActive(true);
            }
        }
    }

    public void ChangeAnimationState(int id)
    {
        if (currentMonster)
            currentMonster.GetComponent<Monster>().ChangeState(id);
    }

    public void CallAttack()
    {
        if (currentMonster)
            currentMonster.GetComponent<Monster>().Attack();
    }

    public void CallDeath()
    {
        if (currentMonster)
            currentMonster.GetComponent<Monster>().Die();
    }

    public void ChangeColor(Color32 newColor)
    {
        currentMonster.transform.GetChild(0).GetComponent<SpriteRenderer>().color = newColor;

        foreach(Transform obj in currentMonster.transform.GetChild(0).transform)
        {
            if (obj.transform.GetComponent<SpriteRenderer>())
                obj.transform.GetComponent<SpriteRenderer>().color = newColor;
        }
    }
}
