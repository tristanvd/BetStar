#pragma checksum "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "568c6b29f4ac7236ed407a85de06a561da829fb7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Match_SearchResults), @"mvc.1.0.view", @"/Views/Match/SearchResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Match/SearchResults.cshtml", typeof(AspNetCore.Views_Match_SearchResults))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\_ViewImports.cshtml"
using BetStar;

#line default
#line hidden
#line 2 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\_ViewImports.cshtml"
using BetStar.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"568c6b29f4ac7236ed407a85de06a561da829fb7", @"/Views/Match/SearchResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2149b94a21086996da1fc0604a2be112b52498d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Match_SearchResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BetStar.ViewModels.MatchViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
  
	ViewData["Title"] = "SearchResults";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(132, 300, true);
            WriteLiteral(@"
<h2>SearchResults</h2>

<div class=""matchtable"" id=""matchtable"">



	<div class=""row"">

		<div class=""matchinfo""></div>
		<div class=""matchinfo""></div>
		<div id=""itemhome"">1</div>
		<div id=""itemhome"">X</div>
		<div id=""itemhome"">2</div>
		<div class=""matchinfo""></div>

	</div>

");
            EndContext();
#line 24 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
     foreach (var item in Model.AllMatches)
	{
		

#line default
#line hidden
#line 26 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
         if (item.Available)
		{

#line default
#line hidden
            BeginContext(507, 7, true);
            WriteLiteral("\t\t\t<h4>");
            EndContext();
            BeginContext(515, 7, false);
#line 28 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
           Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(522, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
            BeginContext(531, 26, true);
            WriteLiteral("\t\t\t<div class=\"matchinfo\">");
            EndContext();
            BeginContext(558, 13, false);
#line 30 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
                              Write(item.DateTime);

#line default
#line hidden
            EndContext();
            BeginContext(571, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
            BeginContext(581, 26, true);
            WriteLiteral("\t\t\t<div class=\"matchinfo\">");
            EndContext();
            BeginContext(608, 13, false);
#line 32 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
                              Write(item.HomeTeam);

#line default
#line hidden
            EndContext();
            BeginContext(621, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(625, 13, false);
#line 32 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
                                               Write(item.AwayTeam);

#line default
#line hidden
            EndContext();
            BeginContext(638, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
            BeginContext(648, 20, true);
            WriteLiteral("\t\t\t<div class=\"item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 668, "\"", 695, 3);
            WriteAttributeValue("", 678, "Betslip(", 678, 8, true);
#line 34 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
WriteAttributeValue("", 686, item.Id, 686, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 694, ")", 694, 1, true);
            EndWriteAttribute();
            BeginContext(696, 15, true);
            WriteLiteral(" id=\"itemhome\">");
            EndContext();
            BeginContext(712, 50, false);
#line 34 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
                                                                   Write(item.BettingOptions.Find(i => i.Choice == "1").Odd);

#line default
#line hidden
            EndContext();
            BeginContext(762, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
            BeginContext(772, 20, true);
            WriteLiteral("\t\t\t<div class=\"item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 792, "\"", 819, 3);
            WriteAttributeValue("", 802, "Betslip(", 802, 8, true);
#line 36 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
WriteAttributeValue("", 810, item.Id, 810, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 818, ")", 818, 1, true);
            EndWriteAttribute();
            BeginContext(820, 15, true);
            WriteLiteral(" id=\"itemhome\">");
            EndContext();
            BeginContext(836, 50, false);
#line 36 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
                                                                   Write(item.BettingOptions.Find(i => i.Choice == "X").Odd);

#line default
#line hidden
            EndContext();
            BeginContext(886, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
            BeginContext(896, 20, true);
            WriteLiteral("\t\t\t<div class=\"item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 916, "\"", 943, 3);
            WriteAttributeValue("", 926, "Betslip(", 926, 8, true);
#line 38 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
WriteAttributeValue("", 934, item.Id, 934, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 942, ")", 942, 1, true);
            EndWriteAttribute();
            BeginContext(944, 15, true);
            WriteLiteral(" id=\"itemhome\">");
            EndContext();
            BeginContext(960, 50, false);
#line 38 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
                                                                   Write(item.BettingOptions.Find(i => i.Choice == "2").Odd);

#line default
#line hidden
            EndContext();
            BeginContext(1010, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
            BeginContext(1020, 26, true);
            WriteLiteral("\t\t\t<div class=\"matchinfo\">");
            EndContext();
            BeginContext(1047, 70, false);
#line 40 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
                              Write(Html.ActionLink("Meer", "MatchDetails", "Match", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1117, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 41 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"

		}

#line default
#line hidden
#line 42 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Match\SearchResults.cshtml"
         

	}

#line default
#line hidden
            BeginContext(1138, 616, true);
            WriteLiteral(@"
	<div id=""betslipdiv"">

	</div>

</div>


<style>

	#betslipdiv {
		color: white;
		background-color: pink;
	}

	#matchtable {
		color: black;
		background-color: white;
	}

	#itemhome {
		display: inline-block;
		width: 10%;
		text-align: center;
	}

	.matchinfo {
		display: inline-block;
		width: 20%;
	}
</style>

<script>


	function Betslip(bo) {
		alert('aangeroepen')
		$.ajax({
			url: ""/Match/ChangeBetslip"",
			type: ""GET"",
			data: { id: bo }
		})
			.done(function (partialViewResult) {
				$(""#betslipdiv"").html(partialViewResult);
			});
	}


</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BetStar.ViewModels.MatchViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
