using ii.Espen.Model;

namespace ii.Espen.Processor
{
    internal class ConsoleProcessor : IProcessor
    {
        public void Start(string availability, string description, string displayName, string id)
        {
            //
        }

        public void StartState(string stateName, string stateType)
        {
            Console.WriteLine($"[STATE] {stateName} [TYPE] {stateType}");
        }

        public void AddTransition(Transition transition)
        {
            Console.WriteLine($"  [NEXTSTATE] {transition.NextState.StateName}");
        }

        public void AddExitOperation(Exitoperation exitOperation)
        {
            Console.WriteLine($"  [EXITOPERATION] {exitOperation.Type}");
            Console.WriteLine($"    CreatedVariableType: {exitOperation.CreatedVariableType}");
            Console.WriteLine($"    CustomFadeInDuration: {exitOperation.CustomFadeInDuration}");
            Console.WriteLine($"    CustomFadeOutDuration: {exitOperation.CustomFadeOutDuration}");
            Console.WriteLine($"    OnFadeOutOperations: {exitOperation.OnFadeOutOperations}");
            Console.WriteLine($"    RawValue: {exitOperation.RawValue}");
            Console.WriteLine($"    ScopeId: {exitOperation.ScopeId}");
            Console.WriteLine($"    TargetArea: {exitOperation.TargetArea}");
            Console.WriteLine($"    VariableId: {exitOperation.VariableId}");
            Console.WriteLine($"    VariableScope: {exitOperation.VariableScope}");
        }

        public void StartOutput(int SpeakerId, string speakerName)
        {
            Console.WriteLine($"[OUTPUT] Speaker: {SpeakerId} {speakerName}");
        }

        public void AddTextToSay(string text, string voiceLine)
        {
            Console.WriteLine($"  [TEXTTOSAY] {text} [VOICELINE] {voiceLine}");
        }

        public void AddOperation(Operation operation)
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

        public void AddOutputTransition(Transition transition)
        {
            Console.WriteLine($"  [NEXTSTATE] {transition.NextState.StateName}");
        }

        public void AddChildCondition(Childcondition childCondition)
        {
            Console.WriteLine($"    [CONDITION] {childCondition.Type}");
            Console.WriteLine($"      Scope: {childCondition.Scope} [{childCondition.ScopeId}]");
            Console.WriteLine($"      Variable: {childCondition.VariableId}");
            Console.WriteLine($"      CheckValue: {childCondition.CheckValue}");
            Console.WriteLine($"      Modifier.Type: {childCondition.Modifier?.Type}");
        }

        public void AddCondition(Condition condition)
        {
            //Console.WriteLine($"  [CONDITION - CHILD] {o.Condition.Type}");

            Console.WriteLine($"  [CONDITION] {condition.Type}");
            Console.WriteLine($"    Scope: {condition.Scope} [{condition.ScopeId}]");
            Console.WriteLine($"    VariableId: {condition.VariableId}");
            Console.WriteLine($"    CheckValue: {condition.CheckValue}");
            if (condition.Creature != null)
            {
                Console.WriteLine($"    Creature: {condition.Creature.Id} {(condition.Creature.Type)} ");
            }
        }

        public void EndState()
        {
            //
        }

        public void EndOutput()
        {
            //
        }

        public void StartChildCondition()
        {
            //
        }

        public void EndChildCondition()
        {
            //
        }

        public void StartOperation()
        {
            //
        }

        public void EndOperation()
        {
            //
        }

        public void StartExitOperation()
        {
            //
        }

        public void EndExitOperation()
        {
            //
        }

        public void StartOutputTransition()
        {
            //
        }

        public void EndOutputTransition()
        {
            //
        }

        public void End()
        {
            //
        }
    }
}