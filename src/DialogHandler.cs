using ii.Espen.Model;
using ii.Espen.Processor;

namespace ii.Espen
{
    public class DialogHandler
    {
        private TextRoot text;
        private DialogRoot dialog;
        private IProcessor processor;

        public void Go(TextRoot text, DialogRoot dialog, IProcessor processor)
        {
            this.text = text;
            this.dialog = dialog;
            this.processor = processor;
          
            processor.Start(dialog.Availability, dialog.Description, dialog.DisplayName, dialog.Id);
            foreach (var state in dialog.StateMachine.States)
            {
                ProcessState(state);
            }
            processor.End();
        }

        private void ProcessState(State state)
        {
            processor.StartState(state.Name, state.Type);

            if (state.Outputs != null)
            {
                foreach (var o in state.Outputs)
                {
                    var speakerName = string.Empty;
                    if (o.SpeakerId > 0)
                    {
                        speakerName = dialog.AdditionalSpeakerCompositIds[o.SpeakerId];
                    }
                    processor.StartOutput(o.SpeakerId, speakerName);

                    if (o.Condition != null)
                    {
                        if (o.Condition.Type == "BGModel.GenericLogic.Conditions.GroupCondition" && o.Condition.ChildConditions != null && o.Condition.ChildConditions.Length > 0)
                        {
                            processor.StartChildCondition();
                            foreach (var childCondition in o.Condition.ChildConditions)
                            {
                                processor.AddChildCondition(childCondition);
                            }
                            processor.EndChildCondition();
                        }
                        else
                        {
                            processor.AddCondition(o.Condition);
                        }
                    }

                    var tts = text.values.Where(w => w.k == o.TextToSay.Text).SingleOrDefault();
                    if (tts != null)
                    {
                        processor.AddTextToSay(tts.v, o.TextToSay.VoiceLine?.Path);
                    }

                    if (o.Operations != null)
                    {
                        processor.StartOperation();
                        foreach (var operation in o.Operations)
                        {
                            processor.AddOperation(operation);
                        }
                        processor.EndOperation();
                    }

                    if (state.Transitions != null)
                    {
                        var transition = state.Transitions[o.TransitionIndex];
                        if (!String.IsNullOrEmpty(transition.NextState.StateName))
                        {
                            processor.AddTransition(transition);
                        }
                    }

                    processor.EndOutput();
                }
            }

            if (state.Outputs == null && state.Transitions != null)
            {
                processor.StartOutputTransition();
                foreach (var transiton in state.Transitions)
                {
                    processor.AddTransition(transiton);
                }
                processor.EndOutputTransition();
            }

            if (state.ExitOperations != null)
            {
                processor.StartExitOperation();
                foreach (var exitOperation in state.ExitOperations)
                {
                    processor.AddExitOperation(exitOperation);
                }
                processor.EndExitOperation();
            }

            processor.EndState();
        }
    }
}