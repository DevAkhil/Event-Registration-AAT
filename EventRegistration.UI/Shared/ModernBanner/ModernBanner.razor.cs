using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.UI.Shared.ModernBanner
{
    public partial class ModernBanner
    {
        [Parameter]
        public string Heading { get; set; } = string.Empty;
        [Parameter]
        public string? SubHeading { get; set; } = null;
        [Parameter] 
        public RenderFragment ChildContent { get; set; }




    }
}
