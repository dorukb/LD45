using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infancy : Phase
{

    //no pre-requisites for this phase. can choose any action.
    private Person person;
    public Dictionary<string, Action> actions;

 
    public Infancy(Person p)
    {
        person = p;
        actions = new Dictionary<string, Action>
        {
            {"Cry",Cry},
            {"Sleep",Sleep},
            {"Puke",Puke },
            {"Poop",Poop },
            {"Crawl", Crawl}
        };
    }
    
    public void Cry()
    {
        person.actionFeedback = "You feel the weight of existence over your tiny shoulders... Cry, cry lil baby !";
        Debug.Log("Crying");
        person.annoyance++;
    }
    public void Sleep()
    {
        person.actionFeedback = "zZz zZZz zz";
        Debug.Log("Sleeping");
        person.laziness++;
    }
    public void Puke()
    {
        person.actionFeedback = "You puked all over your mother, who still HAt.. LOVES you!";
        Debug.Log("Puking");
        person.annoyance++;
    }
    public void Poop()
    {
        person.actionFeedback = "You should really learn your way to the bathroom...";
        Debug.Log("Poop");
    }
    public void Crawl()
    {
        person.actionFeedback = "You move towards your father, who does not care since the football match on TV is so exciting :((";
        Debug.Log("Crawling");
        person.fitness++;
    }

    public Dictionary<string, Action> GetPossibleActions()
    {
        return actions;
    }
}
