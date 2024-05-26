using Microsoft.AspNetCore.Components;

namespace EventRegistration.UI.Shared.Banner
{
    public partial class Banner
    {
        [Parameter]
        public string BannerTitle { get; set; }

        [Parameter]
        public string BannerDescription { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}
