using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;

namespace ScribanRepro;

public class OfferList : ScriptObject, IScriptCustomFunction
{
    public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments,
        ScriptBlockStatement blockStatement)
    {
        // This would come from cache/storage, but for this example we hardcode some values
        var items = new List<Offer>
        {
            new() { Something = "Abc" },
            new() { Something = "Def" }
        };

        var result = new List<OfferObject>();
        
        foreach (var item in items)
        {
            result.Add(new OfferObject(item));
        }

        return result;
    }

    // Required by version 5.0.0 (comment out for previous version)
    
    public ValueTask<object> InvokeAsync(TemplateContext context, ScriptNode callerContext, ScriptArray arguments,
        ScriptBlockStatement blockStatement)
    {
        throw new NotImplementedException();
    }

    public ScriptParameterInfo GetParameterInfo(int index)
    {
        throw new ArgumentOutOfRangeException(nameof(index));
    }
    public int RequiredParameterCount => 0;
    public int ParameterCount => 0;
    public ScriptVarParamKind VarParamKind => ScriptVarParamKind.Direct;
    public Type ReturnType => typeof(List<Offer>);
}