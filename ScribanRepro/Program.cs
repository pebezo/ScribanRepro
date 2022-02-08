namespace ScribanRepro;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("-----");
        
        var repository = new RenderRepository();
        
        // This works in 1.2.2, but not in 5.0. The 'snippet' function assumes that 'o' is defined outside and tries to use it,
        // but in v5 the 'o' variable doesn't bubble down to the function...
        Console.WriteLine(repository.Render("{{ for o in offers }} {{ snippet }} = {{ o.something }} | {{ end }} "));
        
        Console.WriteLine("-----");
    }
}