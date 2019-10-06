using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Person : MonoBehaviour
{

    //person has traits/stats that change with the actions taken.
    public string givenName;

    //infancy traits START
    public int annoyance = 1;
    public int laziness = 0;
    public int fitness = 0;
    //infancy traits END

    // CHILDHOOD traits
    public int eatenJunk = 0;
    public int social = 0;
    public int intellect = 0;
    public int creativity = 1;
    public int health = 5;
    public int academicProwess = 0;
    // childhood traits end

    // TEEN traits
    public bool isDisabled = false;
    public bool didRiskyShit = false;
    // TEEN traits

    // young adult
    public int relationshipExp = 1;
    public bool isMarried;
    public int gameJamCount = 0;
    //young adult

    //display text//
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI summaryText;
    public string actionFeedback;

    List<string> summary;

    private void Start()
    {
        //randomize this afterwards. players cant choose name!!
        givenName = "Doruk";
        actionFeedback = feedbackText.text;
        summary = new List<string>();
    }


    public void GiveSummary(God.Phases phase)
    {

        summary.Clear();

        switch (phase)
        {
            case God.Phases.Infancy:
                SummarizeInfancy();
                break;
            case God.Phases.Childhood:
                SummarizeChildhood();
                Debug.LogFormat("Current stats: annoyance:{0}, fitness: {1}, laziness: {2}", annoyance, fitness, laziness);
                Debug.LogFormat("Current stats: social:{0}, intellect: {1}, creativity: {2}, academicProwess: {3}, health: {4}", social, intellect, creativity, academicProwess, health);
                break;
            case God.Phases.Teen:
                SummarizeTeen();
                Debug.LogFormat("Current stats: social:{0}, intellect: {1}, creativity: {2}, academicProwess: {3}, health: {4}", social, intellect, creativity, academicProwess, health);
                if (isDisabled) { Debug.Log("person is disabled cuz of doing risky shit..."); }
                break;
            case God.Phases.YoungAdult:
                Debug.LogFormat("Current stats: social:{0}, intellect: {1}, creativity: {2}, academicProwess: {3}, health: {4}", social, intellect, creativity, academicProwess, health);
                break;
            default:
                break;
        }
    }

    public void SummarizeTeen()
    {
        if(social > 4)
        {
            summary.Add("Wowowow casanova, you spent your whole time dating. take it easy, you still have years for these :D");
        }
        if(intellect > 2 && creativity > 2)
        {
            summary.Add("Wow, you valued different things than most teens, You might consider a creative job in the future!");
        }
        if(didRiskyShit)
        {
            summary.Add("Life was too boring for you so you decided to try stupid things.");
            if (isDisabled)
            {
                summary.Add("You paid the price for that tho, that leg is not getting any better.its sad :(");
            }
            else
            {
                summary.Add("You managed to get away with your stupidity! hope this does not encourage you to do more.");
            }
        }
        if(academicProwess > 1)
        {
            summary.Add("Might consider attending a university.");
        }
        summaryText.text = "";
        foreach (string line in summary)
        {
            summaryText.text += line;
        }
    }
    public void SummarizeChildhood()
    {
        if(fitness > 2)
        {
            summary.Add("Wow! such a sportive kid you were.");
        }
        if(intellect > 2)
        {
            summary.Add("You enjoyed reading stories about different universes. good for you!");
        }
        if(laziness > 2)
        {
            summary.Add("Really. Really? is this how you spend your childhood... ok no one's judging.");
        }
        if (academicProwess > 0)
        {
            summary.Add("Studying this early might not be the best idea my Dear. There is lot more to life than just study. OR is there :?)");
        }
        summaryText.text = "";
        foreach (string line in summary)
        {
            summaryText.text += line;
        }
    }
    public void SummarizeInfancy()
    {
        if (annoyance > 3)
        {
            summary.Add("You were an annoying little thingy but still adorable.");
        }
        else { summary.Add("You were such an adorable little kid."); }

        if (fitness > 1) { summary.Add("You were the first to run! also first to fall... but thats another story"); }
        else { summary.Add("Come onn crawling is funn. why dont you try ?"); }

        summaryText.text = "";
        foreach (string line in summary)
        {
            summaryText.text += line;
        }
    }
    public void ShowFeedbackText()
    {
        feedbackText.text = actionFeedback;
    }
    public void ClearFeedbackText()
    {
        feedbackText.text = "";
    }

    public void EndGameSummary()
    {
        summary.Clear();
        FitnessSummary();
        IntellectSummary();
        CreativitySummary();
        SocialSummary();
        
        summaryText.text = "";
        foreach (string line in summary)
        {
            summaryText.text += line;
        }

    }

    public void Finish()
    {
        summary.Clear();
        summary.Add("...Then you died, like every beautiful or ugly thing, death does not discriminate. Nothing you could choose could make the outcome any different... One could argue nothing ever matters or alternatively could care about the journey rather than the destination! In the end, its up to you :)");
        summaryText.text = "";
        foreach (string line in summary)
        {
            summaryText.text += line;
        }
    }
    public void SocialSummary()
    {
        if(social > 6)
        {
            summary.Add(" You were quite the social person. Had many friends and spent some quality time with them.");
            if (isMarried)
            {
                summary.Add(" Even managed to get married! You and your partner shared a fulfilling life");
            }
        }
    }
    public void CreativitySummary()
    {
        if (creativity > 3)
        {
            summary.Add(" You were a creative human being. Drew many art pieces and designed some not-so-shitty games.");
            if (gameJamCount > 0)
            {
                summary.Add(" Even joined game jams! you were cool.");
            }
        }
        else if (gameJamCount > 0)
        {
            summary.Add(" You did not do much creative work but joined a game jam, thats something...");
        }
    }
    public void IntellectSummary()
    {
        if(intellect > 5)
        {
            if(academicProwess > 4)
            {
                summary.Add(" Wow, you loved learning & reading throughout your life and eventually became a professor in your local university!");
            }
            else
            {
                summary.Add(" You read your share of books but was not that interested in academic studies.");
            }
        }
        else
        {
            string txt =  " You were not interested in books or studies much";
            if (fitness > 4)
            {
                txt += ", you preferred sports!";
            }
            else if(social > 5)
            {
                txt += ", you preferred parties and social occasions more";
            }
            summary.Add(txt);
            
        }
    }

    public void FitnessSummary()
    {
        if (fitness > 7)
        {
            string fitnesstxt = "You were truly in love with sports, tried many of them over the years";
            if (eatenJunk < 2) { fitnesstxt += " and also had a healthy diet!"; }
            summary.Add(fitnesstxt);
        }
        else if (fitness > 3)
        {
            string fitnesstxt = "You tried some sports but I guess other things interested you more.";
            summary.Add(fitnesstxt);
        }
        else
        {
            if (isDisabled)
            {
                summary.Add("Drunk driving cost you more than just sports...");
            }
            else
            {
                summary.Add("You weren't into sports much, wish you atleast tried Yoga!");
            }
        }
    }


}
