using System;
using System.Collections.Generic;
using System.Text;
using ListView.ViewModels;
using Xamarin.Forms;

namespace ListView.Templates
{
    public class NewsHeaderDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the normal template.
        /// </summary>
        /// <value>The normal template.</value>
        public DataTemplate ReadNewsTemplate { get; set; }
        /// <summary>
        /// Gets or sets the saved organization template.
        /// </summary>
        /// <value>The saved organization template.</value>
        public DataTemplate UnReadNewsTemplate { get; set; }

        /// <summary>
        /// The developer overrides this method to return a valid data template for the specified <paramref name="item" />. This method is called by <see cref="M:Xamarin.Forms.DataTemplateSelector.SelectTemplate" />.
        /// </summary>
        /// <param name="item">The data for which to return a template.</param>
        /// <param name="container">An optional container object in which the developer may have opted to store <see cref="T:Xamarin.Forms.DataTemplateSelector" /> objects.</param>
        /// <returns>A developer-defined <see cref="T:Xamarin.Forms.DataTemplate" /> that can be used to display <paramref name="item" />.</returns>
        /// <remarks>This method causes <see cref="M:Xamarin.Forms.DataTemplateSelector.SelectTemplate" /> to throw an exception if it returns an instance of <see cref="T:Xamarin.Forms.DataTemplateSelector" />.</remarks>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((NewsPageViewModel.NewsItems)item).IsRead == true ? ReadNewsTemplate : UnReadNewsTemplate;
        }
    }
}
