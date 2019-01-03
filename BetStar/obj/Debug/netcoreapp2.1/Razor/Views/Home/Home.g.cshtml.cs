#pragma checksum "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a5324e89bd127296ff338f82dac0f3edf73d37f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Home), @"mvc.1.0.view", @"/Views/Home/Home.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Home.cshtml", typeof(AspNetCore.Views_Home_Home))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a5324e89bd127296ff338f82dac0f3edf73d37f", @"/Views/Home/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2149b94a21086996da1fc0604a2be112b52498d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BetStar.ViewModels.MatchViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
  
	ViewData["Title"] = "Home";
	var roleId = Convert.ToInt32(User.Claims.Where(claim => claim.Type == "RoleId").Select(claim => claim.Value).SingleOrDefault());

	if (roleId == 1)
	{
		Layout = "~/Views/Shared/_Layout.cshtml";
	}
	if (roleId == 2)
	{
		Layout = "~/Views/Shared/_AdminLayout.cshtml";
	}


#line default
#line hidden
            BeginContext(365, 321, true);
            WriteLiteral(@"


<div class=""matchtable"" id=""matchtable"">



	<div class=""homeTableHead"">

		<div class=""matchinfo""></div>
		<div class=""matchinfo""></div>
		<div id=""itemhome"">1</div>
		<div id=""itemhome"">X</div>
		<div id=""itemhome"">2</div>
		<div class=""matchinfo""></div>
		<div class=""matchinfo""></div>

	</div>

");
            EndContext();
#line 36 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
     foreach (var item in Model.AllMatches)
	{
		

#line default
#line hidden
#line 38 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
         if (item.Available)
		{
			


#line default
#line hidden
            BeginContext(768, 53, true);
            WriteLiteral("\t\t<div class=\"matchrow\">\r\n\r\n\t\t<div class=\"matchinfo\">");
            EndContext();
            BeginContext(822, 13, false);
#line 44 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
                          Write(item.DateTime);

#line default
#line hidden
            EndContext();
            BeginContext(835, 35, true);
            WriteLiteral("</div>\r\n\r\n\t\t<div class=\"matchinfo\">");
            EndContext();
            BeginContext(871, 13, false);
#line 46 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
                          Write(item.HomeTeam);

#line default
#line hidden
            EndContext();
            BeginContext(884, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(888, 13, false);
#line 46 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
                                           Write(item.AwayTeam);

#line default
#line hidden
            EndContext();
            BeginContext(901, 10, true);
            WriteLiteral("</div>\r\n\r\n");
            EndContext();
#line 48 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
         if (@item.BettingOptions.Find(i => i.Choice == "1").Odd > 1)
		{

#line default
#line hidden
            BeginContext(981, 20, true);
            WriteLiteral("\t\t\t<div class=\"item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1001, "\"", 1070, 3);
            WriteAttributeValue("", 1011, "Betslip(", 1011, 8, true);
#line 50 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
WriteAttributeValue("", 1019, item.BettingOptions.Find(i => i.Choice == "1").Id, 1019, 50, false);

#line default
#line hidden
            WriteAttributeValue("", 1069, ")", 1069, 1, true);
            EndWriteAttribute();
            BeginContext(1071, 15, true);
            WriteLiteral(" id=\"itemhome\">");
            EndContext();
            BeginContext(1087, 50, false);
#line 50 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
                                                                                                             Write(item.BettingOptions.Find(i => i.Choice == "1").Odd);

#line default
#line hidden
            EndContext();
            BeginContext(1137, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 51 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
		}
		else
		{

#line default
#line hidden
            BeginContext(1163, 49, true);
            WriteLiteral("\t\t\t<div class=\"item\" id=\"itemhome\">locked</div>\r\n");
            EndContext();
#line 55 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
		}

#line default
#line hidden
            BeginContext(1217, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 57 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
         if (@item.BettingOptions.Find(i => i.Choice == "X").Odd > 1)
		{

#line default
#line hidden
            BeginContext(1289, 20, true);
            WriteLiteral("\t\t\t<div class=\"item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1309, "\"", 1378, 3);
            WriteAttributeValue("", 1319, "Betslip(", 1319, 8, true);
#line 59 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
WriteAttributeValue("", 1327, item.BettingOptions.Find(i => i.Choice == "X").Id, 1327, 50, false);

#line default
#line hidden
            WriteAttributeValue("", 1377, ")", 1377, 1, true);
            EndWriteAttribute();
            BeginContext(1379, 15, true);
            WriteLiteral(" id=\"itemhome\">");
            EndContext();
            BeginContext(1395, 50, false);
#line 59 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
                                                                                                             Write(item.BettingOptions.Find(i => i.Choice == "X").Odd);

#line default
#line hidden
            EndContext();
            BeginContext(1445, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 60 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
		}
		else
		{

#line default
#line hidden
            BeginContext(1471, 49, true);
            WriteLiteral("\t\t\t<div class=\"item\" id=\"itemhome\">locked</div>\r\n");
            EndContext();
#line 64 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
		}

#line default
#line hidden
            BeginContext(1525, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 66 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
         if (@item.BettingOptions.Find(i => i.Choice == "2").Odd > 1)
		{

#line default
#line hidden
            BeginContext(1597, 20, true);
            WriteLiteral("\t\t\t<div class=\"item\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1617, "\"", 1686, 3);
            WriteAttributeValue("", 1627, "Betslip(", 1627, 8, true);
#line 68 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
WriteAttributeValue("", 1635, item.BettingOptions.Find(i => i.Choice == "2").Id, 1635, 50, false);

#line default
#line hidden
            WriteAttributeValue("", 1685, ")", 1685, 1, true);
            EndWriteAttribute();
            BeginContext(1687, 15, true);
            WriteLiteral(" id=\"itemhome\">");
            EndContext();
            BeginContext(1703, 50, false);
#line 68 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
                                                                                                             Write(item.BettingOptions.Find(i => i.Choice == "2").Odd);

#line default
#line hidden
            EndContext();
            BeginContext(1753, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 69 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
		}
		else
		{

#line default
#line hidden
            BeginContext(1779, 49, true);
            WriteLiteral("\t\t\t<div class=\"item\" id=\"itemhome\">locked</div>\r\n");
            EndContext();
#line 73 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
		}

#line default
#line hidden
            BeginContext(1833, 25, true);
            WriteLiteral("\t\t<div class=\"matchinfo\">");
            EndContext();
            BeginContext(1859, 70, false);
#line 74 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
                          Write(Html.ActionLink("Meer", "MatchDetails", "Match", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1929, 35, true);
            WriteLiteral("</div>\r\n\r\n\t\t<div class=\"matchinfo\">");
            EndContext();
            BeginContext(1965, 65, false);
#line 76 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
                          Write(Html.ActionLink("Graphs", "Stats", "Match", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(2030, 20, true);
            WriteLiteral("</div>\r\n\r\n\t\t</div>\r\n");
            EndContext();
#line 79 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
		}

#line default
#line hidden
#line 79 "C:\Users\trist\OneDrive\Documenten\GitHub\BetStar\BetStar\Views\Home\Home.cshtml"
         

	}

#line default
#line hidden
            BeginContext(2061, 1194, true);
            WriteLiteral(@"
	<div id=""betslipdiv"">

	</div>

</div>


<style>

	#betslipdiv {
		color:white;
		background-color:pink;
	}

	/*#matchtable {
		color:black;
		background-color:white;
	}*/

	#itemhome {
		display:inline-block;
		width:10%;
		text-align:center;
	}

	.matchinfo {
		display:inline-block;
		width:16%;
	}

	.homeTableHead {
		color: white;
	}



	

</style>

<script>

	function GetData() {

		var stringids = """";
		var nr = document.getElementsByClassName('rowid');
		for (var i = 0; i < nr.length; i++) {
			stringids = stringids + document.getElementsByClassName('rowid')[i].innerHTML + ',';
		}
		return stringids;
	}

	function Betslip(id) {

		$.ajax({
			url: ""/Match/ChangeBetslip"",
			type: ""GET"",
			data: { id: id, idstring: GetData() }
		})
			.done(function (partialViewResult) {
				$(""#betslipdiv"").html(partialViewResult);
			});


	}
	
	//function Betslip(bo) {
	//	alert('aangeroepen')
	//	$.ajax({
	//		url: ""/Match/ChangeBetslip"",
	//");
            WriteLiteral("\t\ttype: \"GET\",\r\n\t//\t\tdata: { id: bo }\r\n\t//\t})\r\n\t//\t\t.done(function (partialViewResult) {\r\n\t//\t\t\t$(\"#betslipdiv\").html(partialViewResult);\r\n\t//\t\t});\r\n\t//}\r\n\t\t\r\n\r\n</script>");
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
