$(() => {
  $('#data-grid-local').dxDataGrid({
    showBorders: true,
    headerFilter: { visible: true },
    filterRow: { visible: true },
    dataSource: categories,
    columns: [
      { dataField: "CategoryName", width: 200, allowFiltering: false },
      {
        dataField: 'Products',
        caption: "Object Products",
        dataType: "string",
        headerFilter: {
          dataSource: {
            store:{
              type: "array",
              data: products,
            },
            map: (product) => {
              return {
                text: product.name,
                value: product.name
              };
            }
          }
        },
        filterOperations: ["contains", "endswith", "=", "startswith"],
        calculateFilterExpression: getFilterExpressionFunction(true),
        calculateDisplayValue: function(rowData) {
          let productNames = rowData.Products.map(productId => {
            let product = products.find(p => p.id === productId);
            return product ? product.name : null;
          });
          return productNames.join(", ");
        }
      },
      {
        dataField: 'SimpleProducts',
        caption: "String Products",
        dataType: "string",
        headerFilter: {
          dataSource: {
            store:{
              type: "array",
              data: simpleProducts,
            },
            map: (product) => {
              return {
                text: product,
                value: product
              };
            }
          }
        },
        filterOperations: ["contains", "endswith", "=", "startswith"],
        calculateFilterExpression: getFilterExpressionFunction(false),
      }
    ]
  });

  function getFilterExpressionFunction(extractDisplayValues) {
    return function(filterValue, selectedFilterOperation, target) {
      const column = this;
      if (filterValue) {
        const selector = (data) => {
          const applyOperation = (arg1, arg2, op) => {
            const normalizedArg1 = arg1.toLowerCase();
            const normalizedArg2 = arg2.toLowerCase();
            if (op === "=") return normalizedArg1 === normalizedArg2;
            if (op === "contains") return normalizedArg1.includes(normalizedArg2);
            if (op === "startswith") return normalizedArg1.startsWith(normalizedArg2);
            if (op === "endswith") return normalizedArg1.endsWith(normalizedArg2);
            return false;
          };
          const values = extractDisplayValues
            ? column.calculateDisplayValue(data).toLowerCase().split(", ")
            :  column.calculateCellValue(data);
          return values && !!values.find(v => applyOperation(v, filterValue, selectedFilterOperation));
        };
        return [selector, "=", true];
      }
      return this.defaultCalculateFilterExpression.apply(this, arguments);
    }
  }
});
