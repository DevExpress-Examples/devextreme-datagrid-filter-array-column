import { Component } from '@angular/core';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';
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

const url = 'https://localhost:5006/api/InMemoryData/';
// const url = 'https://localhost:5006/api/DbData/';

@Component({
  selector: 'app-data-grid-remote',
  imports: [DxDataGridModule],
  templateUrl: './data-grid-remote.component.html',
})
export class DataGridRemoteComponent {
  filterOperations = ['contains', 'endswith', '=', 'startswith'];

  dataSource = {
    store: createStore({
      key: 'CategoryId',
      loadUrl: `${url}GetCategories`,
    }),
  };

  headerFilterDataSource = {
    store: createStore({ loadUrl: `${url}GetProducts` }),
    map: (item: RemoteProduct) => ({
      text: item.ProductName,
      value: item.ProductName,
    }),
  };

  calculateProductNames(rowData: RemoteCategory): string {
    return rowData.Products.map((product) => product.ProductName).join(', ');
  }
}
