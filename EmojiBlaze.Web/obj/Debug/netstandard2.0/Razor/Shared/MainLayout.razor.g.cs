#pragma checksum "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "046d952c35528c1cc4754600cef5d944bba23c06"
// <auto-generated/>
#pragma warning disable 1591
namespace EmojiBlaze.Web.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 5 "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\_Imports.razor"
using EmojiBlaze.Web;

#line default
#line hidden
#line 6 "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\_Imports.razor"
using EmojiBlaze.Web.Shared;

#line default
#line hidden
    public class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.AddContent(0, 
#line 3 "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\Shared\MainLayout.razor"
 Store.Initialize()

#line default
#line hidden
            );
            builder.AddMarkupContent(1, "\r\n\r\n");
            builder.OpenElement(2, "div");
            builder.AddAttribute(3, "class", "main");
            builder.AddMarkupContent(4, "\r\n    ");
            builder.OpenElement(5, "div");
            builder.AddAttribute(6, "class", "content px-4");
            builder.AddMarkupContent(7, "\r\n        ");
            builder.AddContent(8, 
#line 7 "C:\Users\edpip\Projects\EmojiBlaze\EmojiBlaze.Web\Shared\MainLayout.razor"
         Body

#line default
#line hidden
            );
            builder.AddMarkupContent(9, "\r\n    ");
            builder.CloseElement();
            builder.AddMarkupContent(10, "\r\n");
            builder.CloseElement();
            builder.AddContent(11, "d");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazor.Fluxor.IStore Store { get; set; }
    }
}
#pragma warning restore 1591
