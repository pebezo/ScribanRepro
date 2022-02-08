using Scriban;
using Scriban.Runtime;

namespace ScribanRepro;

public class RenderRepository
{
    public string Render(string content)
    {
        var template = Template.Parse(content);

        if (template.HasErrors)
        {
            throw new Exception("Parse errors");
        }

        var context = new RenderContext(null);

        context.PushGlobal(BuildObjectsAndFunctions());

        return template.Render(context);
    }
    
    internal string Render(string content, RenderContext contextSource)
    { 
        var template = Template.Parse(content);

        var context = new RenderContext(contextSource);

        return template.Render(context);
    }

    private ScriptObject BuildObjectsAndFunctions()
    {
        return new ScriptObject
        {
            { "offers", new OfferList() },
            { "snippet", new SnippetFunction(this) }
        };
    }
}