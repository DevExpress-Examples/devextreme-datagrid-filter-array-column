import DataGrid, { Column, FilterRow, HeaderFilter, type DataGridTypes } from 'devextreme-react/data-grid';
import { createStore } from 'devextreme-aspnet-data-nojquery';

interface RemoteProduct {
  ProductID: number;
  ProductName: string;
}

interface RemoteCategory {
  CategoryId: number;
  CategoryName: string;
  Products: RemoteProduct[];
}

function calculateProductNames(rowData: RemoteCategory): string {
  return rowData.Products.map((product) => product.ProductName).join(', ');
}

const url = 'https://localhost:5006/api/InMemoryData/';
// const url = 'https://localhost:5006/api/DbData/';

const dataSource = {
  store: createStore({
    key: 'CategoryId',
    loadUrl: `${url}GetCategories`,
  }),
}

const pagingSettings = {
  pageSize: 10,
};

const headerFilterSettings : DataGridTypes.ColumnHeaderFilter = {
   dataSource: {
    store: createStore({ loadUrl: `${url}GetProducts` }),
    map: (item: RemoteProduct) => ({
      text: item.ProductName,
      value: item.ProductName,
    }),
  }
};

const filterOperations = ['contains', 'endswith', '=', 'startswith'];

function DataGridRemote(): JSX.Element {
  return (
    <DataGrid
      id="data-grid-remote"
      showBorders
      dataSource={dataSource}
      paging={pagingSettings}
      remoteOperations
    >
      <FilterRow visible />
      <HeaderFilter visible />
      <Column dataField="CategoryName" width={200} allowFiltering={false} />
      <Column
        dataField="Products"
        filterOperations={filterOperations}
        calculateCellValue={calculateProductNames}
        headerFilter={headerFilterSettings}
        allowSorting={false}
      />
    </DataGrid>
  );
}

export default DataGridRemote;
