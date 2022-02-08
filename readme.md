This is sample project that tries to reproduce an issue that came up while upgrading Scriban from version 1.2.2 to 5.0

Version 1.2.2

1) Change the .csproj file to use version 1.2.2
2) Comment out v5 specific code in SnippetFunction and OfferList
3) Running it allows the `snippet` function to "see" the `o` variable

Same thing but with version 5.0

1) Change the .csproj file to use version 5.0
2) Uncomment the v5 specific code in SnippetFunction and OfferList
3) Running it we get `<input>(1,32) : error : Cannot get the member o.something for a null object.`