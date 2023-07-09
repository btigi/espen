using ii.Espen.Model;
using System.Text;

namespace ii.Espen.Processor
{
    internal class HtmlProcessor : IProcessor
    {
        private readonly StringBuilder sb;
        private string id;

        public HtmlProcessor()
        {
            sb = new StringBuilder();
        }

        public void Start(string availability, string description, string displayName, string id)
        {
            this.id = id;

            sb.Clear();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>");
            sb.AppendLine($"{id}");
            sb.AppendLine("</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("section.state {");
            sb.AppendLine("  background-color: #c0c0c0;");
            sb.AppendLine("  padding: 25px;");
            sb.AppendLine("  border-radius: 5px;");
            sb.AppendLine("  margin: 15px;");
            sb.AppendLine("}");
            sb.AppendLine("section.output {");
            sb.AppendLine("  background-color: #a0a0a0;");
            sb.AppendLine("  padding: 25px;");
            sb.AppendLine("  border-radius: 5px;");
            sb.AppendLine("  margin: 15px;");
            sb.AppendLine("  margin-left: 25px;");
            sb.AppendLine("}");
            sb.AppendLine("section.operation {");
            sb.AppendLine("  background-color: #e0e0e0;");
            sb.AppendLine("  padding: 25px;");
            sb.AppendLine("  border-radius: 5px;");
            sb.AppendLine("  margin: 15px;");
            sb.AppendLine("  margin-left: 25px;");
            sb.AppendLine("}");
            sb.AppendLine("section.condition {");
            sb.AppendLine("  background-color: #e0e0e0;");
            sb.AppendLine("  padding: 25px;");
            sb.AppendLine("  border-radius: 5px;");
            sb.AppendLine("  margin: 15px;");
            sb.AppendLine("  margin-left: 25px;");
            sb.AppendLine("}");
            sb.AppendLine("section.exitoperation{");
            sb.AppendLine("  background-color: #e0e0e0;");
            sb.AppendLine("  padding: 25px;");
            sb.AppendLine("  border-radius: 5px;");
            sb.AppendLine("  margin: 15px;");
            sb.AppendLine("  margin-left: 25px;");
            sb.AppendLine("}");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");


            sb.AppendLine($"Id: {id}<br>");
            sb.AppendLine($"DisplayName: {displayName}<br>");
            sb.AppendLine($"Availability: {availability}<br>");
            sb.AppendLine($"Description: {description}<br>");
        }

        public void StartState(string stateName, string stateType)
        {
            sb.AppendLine($"<section class=\"state\">");
            sb.AppendLine($"<p id=\"state-{stateName}\">");
            sb.AppendLine($"[STATE] {stateName}<br>");
            sb.AppendLine($"[TYPE] {stateType}");
            sb.AppendLine($"</p>");
        }

        public void StartOutput(int SpeakerId, string speakerName)
        {
            sb.AppendLine($"<section class=\"output\">");
            sb.AppendLine($"<p>[OUTPUT] Speaker: {SpeakerId} {speakerName}</p>");
        }

        public void StartChildCondition()
        {
            sb.AppendLine($"<section class=\"condition\">");
        }

        public void AddChildCondition(Childcondition childCondition)
        {
            sb.AppendLine($"<p>    [CONDITION] {childCondition.Type}</p>");
            sb.AppendLine($"<p>      Scope: {childCondition.Scope} [{childCondition.ScopeId}]</p>");
            sb.AppendLine($"<p>      Variable: {childCondition.VariableId}</p>");
            sb.AppendLine($"<p>      CheckValue: {childCondition.CheckValue}</p>");
            sb.AppendLine($"<p>      Modifier.Type: {childCondition.Modifier?.Type}</p>");
        }

        public void EndChildCondition()
        {
            sb.AppendLine($"</section>");
        }

        public void AddCondition(Condition condition)
        {
            sb.AppendLine($"  [CONDITION - CHILD] {condition.Type}");

            sb.AppendLine($"<section class=\"condition\">");
            sb.AppendLine($"<p>  [CONDITION] {condition.Type}</p>");
            sb.AppendLine($"<p>    Scope: {condition.Scope} [{condition.ScopeId}]</p>");
            sb.AppendLine($"<p>    VariableId: {condition.VariableId}</p>");
            sb.AppendLine($"<p>    CheckValue: {condition.CheckValue}</p>");
            if (condition.Creature != null)
            {
                sb.AppendLine($"<p>    Creature: {condition.Creature.Id} {(condition.Creature.Type)}</p>");
            }
            sb.AppendLine($"</section>");
        }

        public void AddTransition(Transition transition)
        {
            sb.AppendLine($"<p>  [NEXTSTATE] <a href=\"#state-{transition.NextState.StateName}\">{transition.NextState.StateName}</a></p>");
        }

        public void AddTextToSay(string text, string voiceLine)
        {
            sb.AppendLine($"<p>  [TEXTTOSAY] {text} [VOICELINE] {voiceLine}</p>");
        }

        public void StartOperation()
        {

        }

        public void AddOperation(Operation operation)
        {
            sb.AppendLine($"<section class=\"operation\">");
            sb.AppendLine($"<p>  [OPERATION] {operation.Type}</p>");
            sb.AppendLine($"<p>    ScopeId: {operation.ScopeId}</p>");
            sb.AppendLine($"<p>    Text: {operation.Text}</p>");
            sb.AppendLine($"<p>    Amount: {operation.Amount}</p>");
            sb.AppendLine($"<p>    RawValue: {operation.RawValue}</p>");
            sb.AppendLine($"<p>    Text: {operation.Text}</p>");
            sb.AppendLine($"<p>    TODO: {operation.TODO}</p>");
            sb.AppendLine($"<p>    VariableId: {operation.VariableId}</p>");
            sb.AppendLine($"<p>    VariableScope: {operation.VariableScope}</p>");
            sb.AppendLine($"</section>");
        }

        public void EndOperation()
        {

        }

        public void EndOutput()
        {
            sb.AppendLine($"</section>");
        }

        public void StartExitOperation()
        {
            //
        }

        public void AddExitOperation(Exitoperation exitOperation)
        {
            sb.AppendLine($"<section class=\"exitoperation\">");
            sb.AppendLine($"<p>  [EXITOPERATION] {exitOperation.Type}</p>");
            sb.AppendLine($"<p>    CreatedVariableType: {exitOperation.CreatedVariableType}</p>");
            sb.AppendLine($"<p>    CustomFadeInDuration: {exitOperation.CustomFadeInDuration}</p>");
            sb.AppendLine($"<p>    CustomFadeOutDuration: {exitOperation.CustomFadeOutDuration}</p>");
            sb.AppendLine($"<p>    OnFadeOutOperations: {exitOperation.OnFadeOutOperations}</p>");
            sb.AppendLine($"<p>    RawValue: {exitOperation.RawValue}</p>");
            sb.AppendLine($"<p>    ScopeId: {exitOperation.ScopeId}</p>");
            sb.AppendLine($"<p>    TargetArea: {exitOperation.TargetArea}</p>");
            sb.AppendLine($"<p>    VariableId: {exitOperation.VariableId}</p>");
            sb.AppendLine($"<p>    VariableScope: {exitOperation.VariableScope}</p>");
            sb.AppendLine($"</section>");
        }


        public void EndExitOperation()
        {
            //
        }

        public void StartOutputTransition()
        {
            //
        }

        public void AddOutputTransition(Transition transition)
        {
            sb.AppendLine($"<p>  [NEXTSTATE] {transition.NextState.StateName}</p>");
        }

        public void EndOutputTransition()
        {
            //
        }

        public void EndState()
        {
            sb.AppendLine($"</section>");
        }
        public void End()
        {
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
            File.WriteAllText($"{id}.html", sb.ToString());
        }
    }
}