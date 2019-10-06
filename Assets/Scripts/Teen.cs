using System;
using System.Collections.Generic;
using UnityEngine;

public class Teen
{
    private Person person;
    public Dictionary<string, Action> actions;

    public Teen(Person p)
    {
        person = p;
        actions = new Dictionary<string, Action>
        {
            {"Smoke some cigars dude", Smoke},
            {"Go on a date!!",Date},
            {"Read books and surf reddit", BooksAndReddit},
            {"Join the school sports team", DoSports},
            {"Do risky shit", DoRiskyShit},
            {"Study :)", Study}
        };
        
    }
    bool alreadyDated = false;
    bool studiedBefore = false;

    public void DoSports()
    {
        person.actionFeedback = "You are on the school basketball team now, going to training 2 days a week!";
        Debug.Log("You are on the school basketball team now, going to training 2 days a week!");
        person.fitness += 2;
        person.health++;
        person.social++;
        person.academicProwess--;
    }
    public void Smoke()
    {
        person.actionFeedback = "You smoked a full package of Malboros in 2 hours!! wtf dude take it easy";
        Debug.Log("You smoked a full package of Malboros in 2 hours!! wtf dude take it easy");
        person.social++;
        person.health--;
    }
    public void BooksAndReddit()
    {
        person.actionFeedback = "You start reading some classics in your spare time and surf reddit after school";
        Debug.Log("You start reading some classics in your spare time and surf reddit after school");
        person.intellect += 2;
        person.creativity++;
        person.social--;
        person.academicProwess++;
    }
    public void Date()
    {
        if (!alreadyDated)
        {
            person.actionFeedback = "You are going on your very first date! congratz... better not screw! *wink wink*";
            Debug.Log("You are going on your very first date! congratz... better not screw! *wink wink*");
            person.social += 2;
            person.fitness++;
            person.academicProwess--;
        }
        else
        {
            person.actionFeedback = "She turned out to be quite a match!you guys have fun.>.";
            Debug.Log("She turned out to be quite a match! you guys have fun.>.");
            person.social += 3;
            person.fitness++;
            person.creativity++;
        }
        
    }
    public void DoRiskyShit()
    {
        person.didRiskyShit = true;
        if (person.isDisabled)
        {
            person.actionFeedback = "You haven't learned your lesson! You try to jump across roofs with your only functioning leg. Sooo coool right :?";
            person.social++;
            person.fitness++;
            person.annoyance++;
        }
        else
        {
            person.actionFeedback = "You think life is not as exciting as it should be. You decide to drunk drive a shitty bike:))";
            Debug.Log("You think life is not as exciting as it should be. You decide to drunk drive a shitty bike:))");
            person.social += 2;
            person.annoyance++;
            person.academicProwess--;
            person.isDisabled = UnityEngine.Random.Range(1, 11) < 4;
            if (person.isDisabled)
            {
                person.actionFeedback = "You think life is not as exciting as it should be. You decide to drunk drive a shitty bike:))@You crashed a van in red light!!@Can't say this this wasn't expected tho... Your left leg is permanently damaged...:/ was it worth it ? ";
                person.actionFeedback = person.actionFeedback.Replace("@", "" + System.Environment.NewLine);
                
                Debug.Log("You crashed a van in red light!! Can`t say this this wasn`t expected...   Your left leg is permanently disabled...:/ was it worth it?");
                person.health--;
            }
        }
       
    }
    public void Study()
    {
        if (studiedBefore)
        {
            person.actionFeedback = "You are getting better and better! but you start to lose friends:(";
            Debug.Log("You are getting better and better! but you start to lose friends:(");
            person.fitness--;
            person.social -=2;
            person.intellect++;
            person.academicProwess += 2;
        }
        else
        {
            studiedBefore = true;
            person.actionFeedback = "You decide to focus on your studies.";
            Debug.Log("You decide to focus on your studies.");
            person.fitness--;
            person.creativity--;
            person.social--;

            person.intellect++;
            person.academicProwess += 2;
        }
       
    }
    public void RemoveOptions()
    {
        if(person.intellect < 2)
        {
            actions.Remove("Read Books");
        }
        if(person.social < 2)
        {
            actions.Remove("Go on a date!!");
        }
    }
    public Dictionary<string, Action> GetPossibleActions()
    {
        RemoveOptions();
        return actions;
    }
}
