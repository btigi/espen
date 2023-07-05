﻿using ii.Espen.Model;
using Newtonsoft.Json;

var dialogContent = File.ReadAllText(@"D:\data\BlackGeyser\dialogs\Meetings_Alumu_in_GoD.dia");
var dialog = JsonConvert.DeserializeObject<DialogRoot>(dialogContent);

var dialogPath = $@"D:\data\BlackGeyser\languages\en\DIA_{dialog.Id}.txt";
var textContent = File.ReadAllText(dialogPath);
var text = JsonConvert.DeserializeObject<TextRoot>(textContent);

var dialogHandler = new DialogHandler();
dialogHandler.Go(text, dialog);


public class DialogHandler
{
    private TextRoot text;
    private DialogRoot dialog;
    private int depth = 0;

    public void Go(TextRoot text, DialogRoot dialog)
    {
        this.text = text;
        this.dialog = dialog;

        //var state = dialog.StateMachine.States[Convert.ToInt32(dialog.StateMachine.InitialState)];
        foreach (var state in dialog.StateMachine.States)
        {
            OutputState(state);
        }
    }


    private void OutputState(State state)
    {
        Console.WriteLine();
        depth++;

        if (depth > 100)
            return;

        //TODO: AvailabilityConditions

        Console.WriteLine($"[STATE] {state.Name} [TYPE] {state.Type}");
        if (state.Outputs != null)
        {
            foreach (var o in state.Outputs)
            {
                Console.WriteLine($"[OUTPUT] Speaker: {o.SpeakerId}");
                if (o.SpeakerId > 0)
                {
                    Console.WriteLine($"  {dialog.AdditionalSpeakerCompositIds[o.SpeakerId]}");
                }
                if (o.Condition != null)
                {
                    if (o.Condition.Type == "BGModel.GenericLogic.Conditions.GroupCondition" && o.Condition.ChildConditions != null && o.Condition.ChildConditions.Length > 0)
                    {
                        Console.WriteLine($"  [CONDITION - CHILD] {o.Condition.Type}");
                        foreach (var childCondition in o.Condition.ChildConditions)
                        {
                            Console.WriteLine($"    [CONDITION] {childCondition.Type}");
                            Console.WriteLine($"      Scope: {childCondition.Scope} [{childCondition.ScopeId}]");
                            Console.WriteLine($"      Variable: {childCondition.VariableId}");
                            Console.WriteLine($"      CheckValue: {childCondition.CheckValue}");
                            Console.WriteLine($"      Modifier.Type: {childCondition.Modifier?.Type}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"  [CONDITION] {o.Condition.Type}");
                        Console.WriteLine($"    Scope: {o.Condition.Scope} [{o.Condition.ScopeId}]");
                        Console.WriteLine($"    VariableId: {o.Condition.VariableId}");
                        Console.WriteLine($"    CheckValue: {o.Condition.CheckValue}");
                        if (o.Condition.Creature != null)
                        {
                            Console.WriteLine($"    Creature: {o.Condition.Creature.Id} {(o.Condition.Creature.Type)} ");
                        }
                    }
                }

                var tts = text.values.Where(w => w.k == o.TextToSay.Text).SingleOrDefault();
                if (tts != null)
                {
                    Console.WriteLine($"  [TEXTTOSAY] {tts.v} [VOICELINE] {o.TextToSay.VoiceLine?.Path}");
                }

                if (state.Transitions != null)
                {
                    var transiton = state.Transitions[o.TransitionIndex];
                    if (!String.IsNullOrEmpty(transiton.NextState.StateName))
                    {
                        Console.WriteLine($"  [NEXTSTATE] {transiton.NextState.StateName}");
                    }
                }

                if (o.Operations != null)
                {
                    foreach (var operation in o.Operations)
                    {
                        Console.WriteLine($"  [OPERATION] {operation.Type}");
                        Console.WriteLine($"    ScopeId: {operation.ScopeId}");
                        Console.WriteLine($"    Text: {operation.Text}");
                        Console.WriteLine($"    Amount: {operation.Amount}");
                        Console.WriteLine($"    RawValue: {operation.RawValue}");
                        Console.WriteLine($"    Text: {operation.Text}");
                        Console.WriteLine($"    TODO: {operation.TODO}");
                        Console.WriteLine($"    VariableId: {operation.VariableId}");
                        Console.WriteLine($"    VariableScope: {operation.VariableScope}");
                    }
                }
            }
        }

        if (state.Outputs == null && state.Transitions != null)
        {
            foreach (var transiton in state.Transitions)
            {
                Console.WriteLine($"  [NEXTSTATE] {transiton.NextState.StateName}");
            }
        }

        //TODO: ExitOperations
        if (state.ExitOperations != null)
        {
            foreach (var exitOperation in state.ExitOperations)
            {
                Console.WriteLine($"  [EXITOPERATION] {exitOperation.Type}");
            }
        }
    }
}