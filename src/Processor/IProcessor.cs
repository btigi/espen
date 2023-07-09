using ii.Espen.Model;

namespace ii.Espen.Processor
{
    public interface IProcessor
    {
        public void Start(string availability, string description, string displayName, string id);
        void End();

        public void StartState(string stateName, string stateType);
        void EndState();
        public void StartOutput(int SpeakerId, string speakerName);
        void EndOutput();

        public void StartChildCondition();
        void AddChildCondition(Childcondition childCondition);
        public void EndChildCondition();

        public void StartOperation();
        void AddOperation(Operation operation);
        public void EndOperation();

        public void StartExitOperation();
        public void AddExitOperation(Exitoperation exitOperation);
        public void EndExitOperation();

        public void StartOutputTransition();
        public void AddOutputTransition(Transition transition);
        public void EndOutputTransition();

        public void AddTransition(Transition transition);
        void AddTextToSay(string text, string voiceLine);
        void AddCondition(Condition condition);
    }
}