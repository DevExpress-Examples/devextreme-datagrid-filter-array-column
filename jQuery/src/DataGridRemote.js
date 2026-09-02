$(() => {
  const url = "https://localhost:5006/api/InMemoryData/";
  //const url = "https://localhost:5006/api/DbData/";

  $('#data-grid-remote').dxDataGrid({
    dataSource: {
      store: DevExpress.data.AspNet.createStore({
        key: "CategoryId",
        loadUrl: url + "GetCategories"
      })
    },
    columns: [{
      dataField: "CategoryName",
      width: 200,
      allowFiltering: false
    }, {
      dataField: "Products",
      allowSorting: false,
      filterOperations: ["contains", "endswith", "=", "startswith"],
      calculateCellValue: function(rowData) {
        return rowData.Products.map(product => product.ProductName).join(", ");
      },
      headerFilter: {
        dataSource: {
          store: DevExpress.data.AspNet.createStore({
            loadUrl: url + "GetProducts"
          }),
          map: (item) => {
            return {
              text: item.ProductName,
              value: item.ProductName
            };
          }
        }
      }
    }],
    showBorders: true,
    paging: { pageSize: 10 },
    filterRow: { visible: true },
    headerFilter: { visible: true },
    remoteOperations: true
  });
});
