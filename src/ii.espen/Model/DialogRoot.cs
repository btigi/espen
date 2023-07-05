
namespace ii.Espen.Model
{

    public class DialogRoot
    {
        public string[] AdditionalSpeakerCompositIds { get; set; }
        public string Availability { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public Statemachine StateMachine { get; set; }
        public string Type { get; set; }
    }

    public class Statemachine
    {
        public string InitialState { get; set; }
        public State[] States { get; set; }
        public string Type { get; set; }
    }

    public class State
    {
        public string Name { get; set; }
        public Output[] Outputs { get; set; }
        public Transition[] Transitions { get; set; }
        public string Type { get; set; }
        public Exitoperation[] ExitOperations { get; set; }
    }

    public class Output
    {
        public Operation[] Operations { get; set; }
        public Texttosay TextToSay { get; set; }
        public int TransitionIndex { get; set; }
        public string Type { get; set; }
        public Condition Condition { get; set; }
        public int SpeakerId { get; set; }
        public Availabilitycondition AvailabilityCondition { get; set; }
    }

    public class Texttosay
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public Voiceline VoiceLine { get; set; }
    }

    public class Voiceline
    {
        public string Path { get; set; }
        public string Type { get; set; }
    }

    public class Condition
    {
        public Creature Creature { get; set; }
        public string Type { get; set; }
        public string CheckValue { get; set; }
        public string OperatorType { get; set; }
        public string Scope { get; set; }
        public string ScopeId { get; set; }
        public string VariableId { get; set; }
        public Childcondition[] ChildConditions { get; set; }
    }

    public class Creature
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    public class Childcondition
    {
        public object CheckValue { get; set; }
        public string Scope { get; set; }
        public string ScopeId { get; set; }
        public string Type { get; set; }
        public string VariableId { get; set; }
        public Creature1 Creature { get; set; }
        public Modifier Modifier { get; set; }
    }

    public class Creature1
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    public class Modifier
    {
        public string ModifierOperation { get; set; }
        public string Scope { get; set; }
        public string ScopeId { get; set; }
        public string Type { get; set; }
        public string VariableId { get; set; }
    }

    public class Availabilitycondition
    {
        public string Attribute { get; set; }
        public object CheckValue { get; set; }
        public string ScopeId { get; set; }
        public string Type { get; set; }
        public string VariableId { get; set; }
        public string Scope { get; set; }
    }

    public class Operation
    {
        public string CreatedVariableType { get; set; }        
        public string Text { get; set; }
        public string Type { get; set; }
        public string RawValue { get; set; }
        public string ScopeId { get; set; }
        public string VariableId { get; set; }
        public string VariableScope { get; set; }
        public float? Amount { get; set; }
        public bool? TODO { get; set; }
    }

    public class Transition
    {
        public Nextstate NextState { get; set; }
        public string Type { get; set; }
    }

    public class Nextstate
    {
        public string StateName { get; set; }
        public string Type { get; set; }
    }

    public class Exitoperation
    {
        public float CustomFadeInDuration { get; set; }
        public float CustomFadeOutDuration { get; set; }
        public Onfadeoutoperation[] OnFadeOutOperations { get; set; }
        public Targetarea TargetArea { get; set; }
        public string Type { get; set; }
        public string CreatedVariableType { get; set; }
        public string RawValue { get; set; }
        public string ScopeId { get; set; }
        public string VariableId { get; set; }
        public string VariableScope { get; set; }
    }

    public class Targetarea
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    public class Onfadeoutoperation
    {
        public string CreatedVariableType { get; set; }
        public string RawValue { get; set; }
        public string ScopeId { get; set; }
        public string Type { get; set; }
        public string VariableId { get; set; }
        public string VariableScope { get; set; }
    }

}
