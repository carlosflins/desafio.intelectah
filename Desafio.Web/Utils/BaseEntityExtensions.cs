using Desafio.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Desafio.Web.Utils
{
    public static class BaseEntityExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<T>
        (this IList<T> baseEntities) where T : BaseEntity
        {
            return ToSelectListItems((IEnumerator<BaseEntity>)
                       baseEntities.GetEnumerator());
        }

        public static IEnumerable<SelectListItem> ToSelectListItems
            (this IEnumerator<BaseEntity> baseEntities)
        {
            var items = new HashSet<SelectListItem>();

            while (baseEntities.MoveNext())
            {
                var item = new SelectListItem();
                var entity = baseEntities.Current;

                item.Value = entity.Id.ToString();
                item.Text = entity.ToString();

                items.Add(item);
            }

            return items;
        }
    }
}
