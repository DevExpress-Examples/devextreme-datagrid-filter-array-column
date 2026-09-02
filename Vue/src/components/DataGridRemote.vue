<script setup lang="ts">
import DxDataGrid, {
  DxColumn,
  DxFilterRow,
  DxHeaderFilter,
  DxPaging,
} from 'devextreme-vue/data-grid';
import { createStore } from 'devextreme-aspnet-data-nojquery';
import type { DataSourceOptions } from 'devextreme-vue/common/data';

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

function calculateProductNames(rowData: RemoteCategory): string {
  return rowData.Products.map((product) => product.ProductName).join(', ');
}

const dataSource = {
  store: createStore({
    key: 'CategoryId',
    loadUrl: `${url}GetCategories`,
  }),
};

const headerFilterDataSource: DataSourceOptions = {
  store: createStore({ loadUrl: `${url}GetProducts` }),
  map: (item: RemoteProduct) => ({
    text: item.ProductName,
    value: item.ProductName,
  }),
};

const filterOperations = ['contains', 'endswith', '=', 'startswith'];
</script>

<template>
  <DxDataGrid
    id="data-grid-remote"
    :show-borders="true"
    :data-source="dataSource"
    :remote-operations="true"
  >
    <DxPaging :page-size="10"/>
    <DxFilterRow :visible="true"/>
    <DxHeaderFilter :visible="true"/>
    <DxColumn
      data-field="CategoryName"
      :width="200"
      :allow-filtering="false"
    />
    <DxColumn
      data-field="Products"
      :filter-operations="filterOperations"
      :calculate-cell-value="calculateProductNames"
      :allow-sorting="false"
    >
      <DxHeaderFilter :data-source="headerFilterDataSource"/>
    </DxColumn>
  </DxDataGrid>
</template>
