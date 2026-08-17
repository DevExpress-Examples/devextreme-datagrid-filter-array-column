$(() => {
  //const url = "https://localhost:7189/api/InMemoryData/";
  const url = "https://localhost:7189/api/DbData/";

  $('#data-grid-remote').dxDataGrid({
    dataSource: {
      store: DevExpress.data.AspNet.createStore({
        key: "CategoryId",
        loadUrl: url + "GetCategories"
      }),
      langParams: {
        collatorOptions: {
          sensitivity: "case" // required only for api/InMemoryData
        }
      }
    },
    columns: [{
      dataField: "CategoryName",
      width: 200,
      allowFiltering: false
    }, {
      dataField: "Description",
      width: 400,
      allowFiltering: false
    }, {
      dataField: "Products",
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
