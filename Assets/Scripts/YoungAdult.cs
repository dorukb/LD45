using System;
using System.Collections.Generic;
using UnityEngine;

public class YoungAdult
{
    private Person person;
    public Dictionary<string, Action> actions;

    public YoungAdult(Person p)
    {
        person = p;
        actions = new Dictionary<string, Action>
        {
            {"Try Professional sports", ContinueSports},
            {"Netflix and chill with your date",NetflixAndChill},
            {"Read articles about the nature of life", Scholar},
            {"Join game jams", GameJam},
            {"Party!!", Party},
            {"Get Married", GetMarried}
        };

    }
    bool alreadyDated = false;
    bool studiedBefore = false;
    bool joinedJam = false;
    bool readArticle = false;

    public void GameJam()
    {
        if (joinedJam)
        {
            if(person.creativity > 5)
            {
                person.actionFeedback = "People loved your game!! you might consider doing this for life!";
                person.fitness--;
                person.creativity++;
                person.academicProwess++;
                person.social++;
            }
            else
            {
                person.actionFeedback = "You are trying your best but not getting much recognition. Try to be more creative :(";
                person.creativity++;
                person.social++;
            }
            person.gameJamCount++;
        }
        else
        {
            joinedJam = true;
            if (person.creativity > 2 && person.intellect > 3)
            {
                person.actionFeedback = "Your first game jam was a success! You had no idea about game development but still pull sth off.";
                person.creativity += 2;
                person.social++;
            }
            else
            {
                person.actionFeedback = "You lacked creativity a bit, but still A for effor!";
                person.creativity++;
                person.intellect++;
            }
        }
        person.gameJamCount++;

    }
    public void ContinueSports()
    {
        if(person.fitness > 4)
        {
            person.actionFeedback = "You are on your way to becoming a professional sports guy! Keep it going";
            person.fitness++;
            person.social++;
            person.academicProwess--;
        }
        else
        {
            person.actionFeedback = "You failed to join a professional team. Maybe you should have worked more on your sports skills earlier";
        }
       
    }
    public void NetflixAndChill()
    {
        if(person.relationshipExp > 2)
        {
            bool hasFailed = UnityEngine.Random.Range(1, 11) < 4;
            if (hasFailed)
            {
                person.actionFeedback = "Your date fell asleep, wrong choice of show obviously";
                person.relationshipExp++;
            }
            else
            {
                person.actionFeedback = "You are such a lovely couple! You might even consider long-term :*";
                person.relationshipExp += 2;
                person.social++;
                person.creativity++;
            }
           
        }
        else
        {
            person.actionFeedback = "You do not remember what the show was about but it was an enjoyable evening nonetheless :)";
            person.social += 2;
            person.relationshipExp += 2;

        }

    }
    public void Scholar()
    {
        if (readArticle)
        {
            person.actionFeedback = "You loved the bat story but wanted something more concrete. Now you are reading an article about cement mixes and considering civil engineering:p";
            person.social++;

        }
        else
        {
            readArticle = true;
            person.actionFeedback = "You read an article about How its like to be a Bat. You understand nothing but still enjoy. You're weird";
        }
        person.academicProwess += 2;
        person.creativity++;
        person.intellect++;
        person.social -= 2;
        person.fitness--;
    }
    public void Party()
    {
        if(person.social > 7)
        {
            person.actionFeedback = "You really know how to party!! People were in line to talk to you!";
            person.academicProwess--;
            person.social++;
            person.relationshipExp++;
        }
        else if(person.social > 3)
        {

            person.actionFeedback = "You are not famililar with the environment but still try to fit in. You meet some new people!";
            person.social += 2;
            person.academicProwess--;
        }
        else
        {
            person.actionFeedback = "You realize this was a mistake and return to your books...";
            person.social++;
            person.intellect++;
        }
    }

    private bool isRejected = false;
    public void GetMarried()
    {
        if (isRejected)
        {
            person.actionFeedback = "You are not in a mood to meet with anybody let alone marrying!! You play computer games instead. Good for you.";
            person.creativity++;
            person.intellect++;
            person.social--;
        }
        if (person.relationshipExp > 4)
        {
            person.actionFeedback = "You decided the marry your netflix partner!! congratz to you guys";
            person.social--;
            person.creativity++;
            person.academicProwess--;
            person.relationshipExp += 2;
            person.isMarried = true;
        }
        else if (person.relationshipExp > 2)
        {

            person.actionFeedback = "Well this is not a one-way street. Your significant other rejected you and now you are in shatters";
            person.social -= 2;
            person.creativity--;
            person.academicProwess--;
            person.relationshipExp += 2;
            person.health--;
            isRejected = true;
        }
        else
        {
            person.actionFeedback = "HAHAH you wishhh! You Wake up.";
            person.creativity++;
            person.social++;
        }
    }
    public void RemoveOptions()
    {
        if (person.intellect < 3)
        {
            actions.Remove("Read articles about the nature of life");
        }
        if (person.social < 3)
        {
            actions.Remove("Netflix and chill with your date");
        }
        if(person.fitness < 3 || person.isDisabled)
        {
            actions.Remove("Try Professional sports");
        }
    }
    public Dictionary<string, Action> GetPossibleActions()
    {
        RemoveOptions();
        return actions;
    }


}
