using DevExtreme.AspNet.Data.Helpers;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable

[assembly: InternalsVisibleTo("ServerApp.Tests")]

namespace ServerApp
{
  public static class FilterByCollectionPropertyHelper
  {
    public class FilterInfo
    {
      public Type CollectionItemType { get; set; }
      public Type CollectionType { get; internal set; }
      public string CollectionPropertyName { get; set; }
      public string CollectionItemPropertyName { get; set; }
    }

    static Dictionary<string, FilterInfo> filterInfos = new Dictionary<string, FilterInfo>();

    static MethodInfo GetFilteringPredicate(string filterOperation) {
      // selects a method overload that accepts a string as a parameter
      Func<string, MethodInfo> infoByName = (name) =>
        typeof(string).GetMethod(name, new Type[] { typeof(string) });

      switch (filterOperation) {
        case "contains": return infoByName("Contains");
        case "=": return infoByName("Equals");
        case "startswith": return infoByName("StartsWith");
        case "endswith": return infoByName("EndsWith");
        default: throw new ArgumentException("This operation is not supported: " + filterOperation);
      }
    }

    static FilterByCollectionPropertyHelper() {
      DevExtreme.AspNet.Data.Helpers.CustomFilterCompilers.RegisterBinaryExpressionCompiler(compilerFunc => {
        var key = $"{compilerFunc.DataItemExpression.Type.FullName}|{compilerFunc.AccessorText}";
        if (!filterInfos.TryGetValue(key, out var info)) return null;

        var collectionItemParameter = Expression.Parameter(info.CollectionItemType);
        Expression collectionItem = collectionItemParameter;
        if (!string.IsNullOrEmpty(info.CollectionItemPropertyName)) {
          collectionItem = Expression.Property(collectionItemParameter, info.CollectionItemPropertyName);
        }
        // represents (collectionItem) => collectionItem.PropertyName.FilteringMethod("searchText")
        var innerLambda = Expression.Lambda(
          GetStringCollectionItemExpression(collectionItem, compilerFunc),
          collectionItemParameter
         );

        // represents call to Enumerable.Any(collection, innerLambda)
        return Expression.Call(
            typeof(Enumerable),
            "Any",
            new[] { info.CollectionItemType },
            Expression.Property(compilerFunc.DataItemExpression, info.CollectionPropertyName),
            innerLambda
        );
      });
    }

    static Expression GetStringCollectionItemExpression(Expression collectionItem, IBinaryExpressionInfo compilerFunc) {
      var lowerCollectionItem = Expression.Call(
        collectionItem,
        typeof(string).GetMethod("ToLower", Type.EmptyTypes)
      );

      var lowerSearchValue = Expression.Constant(
          compilerFunc.Value?.ToString().ToLower() ?? "",
          typeof(string));

      return Expression.Call(
              lowerCollectionItem,
              GetFilteringPredicate(compilerFunc.Operation),
              lowerSearchValue
            );
    }

    public static void RegisterFor<TDataItem, TCollectionItem>(
      Expression<Func<TDataItem, IEnumerable<TCollectionItem>>> collectionPropertyAccessor,
      Expression<Func<TCollectionItem, string>> collectionItemPropertyAccessor = null
    ) {
      var collectionPropertyName = ((MemberExpression)collectionPropertyAccessor.Body).Member.Name;
      var collectionItemPropertyName = collectionItemPropertyAccessor != null ?
          ((MemberExpression)collectionItemPropertyAccessor.Body).Member.Name
          : null;

      var key = $"{typeof(TDataItem).FullName}|{collectionPropertyName}";

      if (!filterInfos.ContainsKey(key)) {
        filterInfos.Add(key, new FilterInfo() {
          CollectionType = typeof(TDataItem),
          CollectionItemType = typeof(TCollectionItem),
          CollectionPropertyName = collectionPropertyName,
          CollectionItemPropertyName = collectionItemPropertyName
        });
      }
    }

    // Test-only hook: clears registered filter info so tests can start from a clean, predictable state.
    internal static void ResetForTests() {
      filterInfos.Clear();
    }
  }

  public static class FilterByCollectionPropertyExtensions
  {
    public static IQueryable<TDataItem> RegisterFilterFor<TDataItem, TCollectionItem>(this IQueryable<TDataItem> collection, Expression<Func<TDataItem, IEnumerable<TCollectionItem>>> collectionPropertyAccessor, Expression<Func<TCollectionItem, string>> collectionItemPropertyAccessor = null) {
      FilterByCollectionPropertyHelper.RegisterFor(collectionPropertyAccessor, collectionItemPropertyAccessor);
      return collection;
    }
  }
}
