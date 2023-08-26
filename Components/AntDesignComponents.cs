using AntDesign;
using Microsoft.AspNetCore.Components;

namespace MyAntDesignApp.Components
{
    public class AntDesignComponents
    {
        public static RenderFragment CreateIcon(string iconType, string iconTheme = "", string iconStyle = "")
        {
            RenderFragment icon = builder =>
            {
                builder.OpenComponent<Icon>(0);
                builder.AddAttribute(1, "Type", iconType);
                builder.AddAttribute(2, "Theme", iconTheme);
                builder.AddAttribute(3, "Style", iconStyle);
                builder.CloseComponent();
            };

            return icon;
        }
    }
}
