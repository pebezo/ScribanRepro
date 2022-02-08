using Scriban;
using Scriban.Runtime;
using Scriban.Syntax;

namespace ScribanRepro;

public class SnippetFunction : ScriptObject, IScriptCustomFunction
{
    private readonly RenderRepository _renderRepository;

    public SnippetFunction(RenderRepository renderRepository)
    {
        _renderRepository = renderRepository;
    }

    public object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments,
        ScriptBlockStatement blockStatement)
    {
        return _renderRepository.Render("[ from inside the snippet {{ o.something }} ]", (RenderContext)context);
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
    public Type ReturnType => typeof(string);
}