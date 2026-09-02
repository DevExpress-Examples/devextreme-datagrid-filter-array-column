<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/1333202658/26.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1333768)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# DevExtreme DataGrid - Filter Collection Column

This example demonstrates how to filter DataGrid by a column bound to a collection of objects or strings.

![Example image](images/preview-image.png)

The example implements the following cases:
1) DataGrid is bound to local data. A data record field contains an array of strings.
2) DataGrid is bound to local data. A data record field contains an array of objects with string fields.
3) DataGrid is bound to remote data and [DataGrid.RemoteOperations](https://js.devexpress.com/Documentation/ApiReference/UI_Widgets/dxDataGrid/Configuration/remoteOperations/) are enabled. The server returns records with an array field including objects with a string field.

The Server App is the ASP.NET Core application and used for the 3rd case. It includes two controllers:
1) InMemoryDataController. Used for quick testing. Operates with in-memory arrays created in the server app.
2) DbDataController. Uses Northwind EFCore context bound to local MSSQL Northwind data base. Used to test the real database interaction.

The local data sample utilizes the [Column.CalculateFilterExpression](https://js.devexpress.com/Documentation/ApiReference/UI_Components/dxDataGrid/Configuration/columns/#calculateFilterExpression) callback to implement the custom filtering logic. This callback adds a custom comparison fuction (selector) to the filtering expression and the DataGrid evaluates it for every record:
```js
function calculateFilterExpression(filterValue, selectedFilterOperation, target) {
    const column = this;
    if (filterValue) {
        const selector = (data) => {
            ...
        };
        return [selector, "=", true];
    }
    return this.defaultCalculateFilterExpression.apply(this, arguments);
}
```

The client part in the remote data sample does nothing special but sends a regular filter expression like `["Products", "contains", "Chai"]`. The server app uses the **DevExtreme.AspNet.Data** server-side API: **BinaryExpressionCompiler**. The example uses it to register a custom compiler function that accepts a filter expression and converts it to the required LINQ expression for the server data source. See the [FilterByCollectionPropertyHelper.cs](ServerApp/ServerApp/FilterByCollectionPropertyHelper.cs) file for implementation details.

## Files to Review

- **Server App**
    - [FilterByCollectionPropertyHelper.cs](ServerApp/ServerApp/FilterByCollectionPropertyHelper.cs)
    - [InMemoryDataController.cs](ServerApp/ServerApp/Controllers/InMemoryDataController.cs)
    - [DbDataController.cs](ServerApp/ServerApp/Controllers/DbDataController.cs.cs)
- **Angular**
    - [data-grid-local.component.html](Angular/src/app/components/data-grid-local/data-grid-local.component.html)
    - [data-grid-remote.component.html](Angular/src/app/components/data-grid-remote/data-grid-remote.component.html)
- **React**
    - [data-grid-local.tsx](React/src/components/data-grid-local.tsx)
    - [data-grid-remote.tsx](React/src/components/data-grid-remote.tsx)
- **Vue**
    - [DataGridLocal.vue](Vue/src/components/DataGridLocal.vue)
    - [DataGridRemote.vue](Vue/src/components/DataGridRemote.vue.vue)
- **jQuery**
    - [DataGridLocal.js](jQuery/src/DataGridLocal.js)
    - [DataGridRemote.js](jQuery/src/DataGridRemote.js.js)
- **ASP.NET Core**    
    - [DataGridLocal.cshtml](ASP.NET%20Core/Views/Home/_DataGridLocal.cshtml.cshtml)
    - [dataGridLocal.js](ASP.NET%20Core/wwwroot/js/dataGridLocal.js)
    - [DataGridRemote.cshtml](ASP.NET%20Core/Views/Home/_DataGridRemote.cshtml.cshtml)
    - [dataGridRemote.js](ASP.NET%20Core/wwwroot/js/dataGridRemote.js)
    - [FilterByCollectionPropertyHelper.cs](ASP.NET%20Core/FilterByCollectionPropertyHelper.cs)
    - [InMemoryDataController.cs](ASP.NET%20Core/Controllers/InMemoryDataController.cs.cs)
    - [DbDataController.cs](ASP.NET%20Core/Controllers/DbDataController.cs)

## Documentation

- [Filtering Columns Bound to Collection](https://js.devexpress.com/Documentation/Guide/UI_Components/DataGrid/Filtering_and_Searching/#API/Filtering_Columns_Bound_to_Collection)

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=devextreme-datagrid-filter-array-column&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=devextreme-datagrid-filter-array-column&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
