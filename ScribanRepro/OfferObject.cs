using Scriban;
using Scriban.Parsing;
using Scriban.Runtime;

namespace ScribanRepro;

public class OfferObject : ScriptObject
{
    private readonly Offer? _offer;

    public OfferObject(Offer offer)
    {
        _offer = offer;
    }

    public override bool TryGetValue(TemplateContext context, SourceSpan span, string member, out object? value)
    {
        switch (member)
        {
            case "something":
                value = _offer?.Something;
                return true;
        }
        
        return base.TryGetValue(context, span, member, out value);
    }
}