using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models
{
    [Preserve(AllMembers = true)]
    public class Category
    {
        #region Constructor

        public Category(string name, string icon, string description, string pageName)
        {
            this.Name = name;
            this.Icon = icon;
            this.Description = description;
            this.PageName = pageName;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public string PageName { get; set; }

        #endregion
    }
}