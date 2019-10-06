using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class God : MonoBehaviour
{
    
    public enum Phases
    {
        Infancy,
        Childhood,
        Teen,
        YoungAdult,
        Working,
        Old,
        Dead
    };
    public GameObject optionsParent;
    public TextMeshProUGUI phaseText;
    public TextMeshProUGUI summaryText;
    public Button nextPhaseButton;


    private int[] turnsForEachPhase = { 5, 5, 5, 5, 9, 4, 1 };

    Dictionary<string, Action> options;
    Phases currPhase;
    private int currTurn;
    private Person you;
    public Color[] bgColors;

    public void Start()
    {
        you = FindObjectOfType<Person>();
        //initial setup of params
        currPhase = Phases.Infancy;
        currTurn = 1;

        //initial setup of scene
        SetupPhaseText(currPhase);
        options = SetupNewPhase(currPhase);
        ShowOptions(options);
    }


    public void AdvanceSimulation()
    {

        optionsParent.gameObject.SetActive(true);
        you.ShowFeedbackText();

        if (currPhase != Phases.Old)
        {
            //find out what the new phase should be
            if(currTurn >= turnsForEachPhase[(int)currPhase])
            {
                you.ClearFeedbackText();

                //clear summary
                summaryText.transform.parent.gameObject.SetActive(false);
                nextPhaseButton.gameObject.SetActive(false);

                if(currPhase == Phases.YoungAdult)
                {
                    EndGame();
                    return;
                }
                //go on to next phase.
                currPhase++;
                Camera.main.backgroundColor = bgColors[(int)currPhase];
                currTurn = 1;
                //setup that new phase
                options = SetupNewPhase(currPhase);
                SetupPhaseText(currPhase);

                if (options == null)
                {
                    print("options are null, not yet implemented phase");
                    return;
                }
                //update displays.
                ShowOptions(options);

            }
            else
            {
                Debug.Log("End of turn: " + currTurn);
                currTurn++;
                if(currTurn >= turnsForEachPhase[(int)currPhase])
                {
                    ShowSummary();
                }
            }
            
        }
        else
        {
            // transfer to die and finish the game.
            print("you died. game ended");
            optionsParent.gameObject.SetActive(false);
        }
    }

    public void EndGame()
    {
        you.ClearFeedbackText();
        optionsParent.gameObject.SetActive(false);

        //change with restart button.
        nextPhaseButton.gameObject.SetActive(true);
        nextPhaseButton.GetComponentInChildren<TextMeshProUGUI>().text = "Advance";

        nextPhaseButton.onClick.RemoveAllListeners();
        nextPhaseButton.onClick.AddListener(() => { Finish(); });

        you.ClearFeedbackText();
        summaryText.transform.parent.gameObject.SetActive(true);

        you.EndGameSummary();
    }
    public void Finish()
    {
        currPhase++;
        Camera.main.backgroundColor = bgColors[(int)currPhase];
        you.Finish();
        phaseText.text = "Dust";
        phaseText.color = Color.black;

        nextPhaseButton.GetComponentInChildren<TextMeshProUGUI>().text = "Restart";

        nextPhaseButton.onClick.RemoveAllListeners();
        nextPhaseButton.onClick.AddListener(() => { Restart(); });
        
    }
    public void Restart()
    {
        LevelManager levelMn = FindObjectOfType<LevelManager>();
        levelMn.LoadScene("Start");
    }
    public void ShowSummary()
    {
        optionsParent.gameObject.SetActive(false);
        nextPhaseButton.gameObject.SetActive(true);
        you.ClearFeedbackText();
        summaryText.transform.parent.gameObject.SetActive(true);
        you.GiveSummary(currPhase);
    }
    public Dictionary<string, Action> SetupNewPhase(Phases phase)
    {
        Debug.Log(phase + " being setup now");
        Dictionary<string, Action> options = null;

        switch (phase)
        {
            case Phases.Infancy:
                options = SetupInfancy();
                break;
            case Phases.Childhood:
                options = SetupChildhood();
                break;
            case Phases.Teen:
                options = SetupTeen();
                break;
            case Phases.YoungAdult:
                options = SetupYoungAdult();
                break;
            default:
                break;
        }
        return options;
    }


    public void SetupPhaseText(Phases currPhase)
    {
        switch (currPhase)
        {
            case Phases.Infancy:
                phaseText.text = "Infancy";
                break;
            case Phases.Childhood:
                phaseText.text = "Childhood";
                phaseText.color = Color.green;
                break;
            case Phases.Teen:
                phaseText.text = "Teen";
                phaseText.color = Color.blue;
                break;
            case Phases.YoungAdult:
                phaseText.text = "Adult";
                phaseText.color = Color.black;
                break;
            default:
                break;
        }
    }
    public void ShowOptions(Dictionary<string, Action> options)
    {
        //int randOpt = UnityEngine.Random.Range(0, options.Count);

        int buttonCount = optionsParent.transform.childCount;


        Button optionDisplay;
        int index = 0;
        foreach (KeyValuePair<string, Action> entry in options)
        {

            if (index >= buttonCount || index >= options.Count) break;

            optionDisplay = optionsParent.transform.GetChild(index).GetComponent<Button>();

            //set the button text here
            optionDisplay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(entry.Key);

            //ensure no delegate left from previous phases.
            optionDisplay.onClick.RemoveAllListeners();
            //add delegate here
            optionDisplay.onClick.AddListener(() => { entry.Value.Invoke(); });
            optionDisplay.onClick.AddListener(() => { AdvanceSimulation();  });
            index++;
        }

    }

    public Dictionary<string, Action> SetupYoungAdult()
    {
        Debug.Log("Set up infancy phase");
        YoungAdult ph = new YoungAdult(you);
        Dictionary<string, Action> options = ph.GetPossibleActions();
        return options;

    }
    public Dictionary<string, Action> SetupInfancy()
    {
        Debug.Log("Set up infancy phase");
        Infancy infancy = new Infancy(you);
        Dictionary<string, Action> options = infancy.GetPossibleActions();
        return options;

    }
    public Dictionary<string, Action> SetupChildhood()
    {
        Debug.Log("Set up childhood phase");
        Childhood childhood = new Childhood(you);
        Dictionary<string, Action> options = childhood.GetPossibleActions();
        return options;

    }
    public Dictionary<string, Action> SetupTeen()
    {
        Debug.Log("Set up teen phase");
        Teen teen = new Teen(you);
        Dictionary<string, Action> options = teen.GetPossibleActions();
        return options;

    }
    // notes //

    // each phase should be a class itself, containing all the FLAGS and vars that HELP DECIDE what ACTIONS are available.
    // actions are functions.
    // phase will have possible actions array of functions to call.
}
