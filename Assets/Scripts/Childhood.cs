using System;
using System.Collections.Generic;
using UnityEngine;

public class Childhood
{
    private Person person;
    public Dictionary<string, Action> actions;

    public Childhood(Person p)
    {
        person = p;
        actions = new Dictionary<string, Action>
        {
            {"Do sports",DoSports},
            {"Play with Legos!",PlayLego},
            {"Read books", ReadBooks},
            {"Junk food & TV !!", JunkFoodAndTV},
            {"Study :)", Study}
        };
    }

    bool playedLego = false;
    public void DoSports()
    {
        person.actionFeedback = "Playing soccer with friends... ahh wish you were the owner of the ball:/";
        Debug.Log("Doing sports");
        person.fitness += 2;
        person.social++;
    }
    public void PlayLego()
    {
        if (playedLego)
        {
            person.actionFeedback = "You built a whole town this time!! impressing young human being";
            person.creativity++;
        }
        else
        { 
            playedLego = true;
            person.actionFeedback = "You build the same shitty house over and over again. but its fine, you're 5 :)";
            Debug.Log("You build the same shitty house over and over again. but its fine, you're 5 :)");
            person.intellect++;
            person.creativity++;
        }
    }
    public void ReadBooks()
    {
        person.actionFeedback = "Dragons, hunters, magic!! so exciting... you wish you were able to actually READ but for now just listen to MAMA";
        Debug.Log("Dragons, hunters, magic!! so exciting... you wish you were able to actually READ but for now just listen to MAMA");
        person.intellect += 2;
        person.creativity++;
    }
    public void JunkFoodAndTV()
    {
        person.actionFeedback = "You watch stupid cartoons on TV all day while eating lot of garbage! Way to go:)";
        Debug.Log("You watch stupid cartoons on TV all day while eating lot of garbage! Way to go:)");
        person.health -= 1;
        person.eatenJunk++;
        person.laziness++;
    }
    public void Study()
    {
        person.actionFeedback = "Suffering has begun.Do your homeworks and say goodbye to free time";
        Debug.Log("Suffering has begun. Do your homeworks and say goodbye to free time");
        person.fitness--;
        person.creativity--;

        person.intellect++;
        person.academicProwess++;
    }

    public Dictionary<string, Action> GetPossibleActions()
    {
        return actions;
    }
}
