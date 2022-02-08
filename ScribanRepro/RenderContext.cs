using Scriban;

namespace ScribanRepro;

public class RenderContext : TemplateContext
{
    public RenderContext(RenderContext? source)
    {
        if (source is not null)
        {
            PushGlobal(source.CurrentGlobal);
        }
    }
}