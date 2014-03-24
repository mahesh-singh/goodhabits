using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GoodHabits.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> html, Expression<Func<TModel, TEnum>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            var enumType = Nullable.GetUnderlyingType(metadata.ModelType) ?? metadata.ModelType;

            var enumValues = Enum.GetValues(enumType).Cast<object>();

            var items = from enumValue in enumValues
                        select new SelectListItem
                        {
                            Text = enumValue.GetType().Name,
                            Value = ((int)enumValue).ToString(),
                            Selected = enumValue.Equals(metadata.Model)
                        };


            return html.DropDownListFor(expression, items, string.Empty, null);
        }

          
        public static IEnumerable<SelectListItem> GetSelectListItems(int selectedValue)
        {
            var enumValues = Enum.GetValues(typeof(GoodHabits.Models.Status)).Cast<object>();

            GoodHabits.Models.Status selectedEnumValue = (GoodHabits.Models.Status)selectedValue;

            var items = from enumValue in enumValues
                        select new SelectListItem
                        {
                            Text = Enum.GetName(typeof(GoodHabits.Models.Status), enumValue),
                            Value = ((int)enumValue).ToString(),
                            Selected = enumValue.Equals(selectedEnumValue)
                        };
            return items;
        }

    }
}