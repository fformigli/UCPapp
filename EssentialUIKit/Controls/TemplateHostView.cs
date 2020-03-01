using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    [Preserve(AllMembers = true)]
    public class TemplateHostView : View
    {
        public static Page Template { get; set; }
    }
}