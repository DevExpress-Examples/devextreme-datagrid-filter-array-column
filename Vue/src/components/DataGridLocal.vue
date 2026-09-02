<script setup lang="ts">
import DxDataGrid, {
  DxColumn,
  DxFilterRow,
  DxHeaderFilter,
  type DxDataGridTypes,
} from 'devextreme-vue/data-grid';
import type { DataSourceOptions } from 'devextreme-vue/common/data';
import { categories, products, simpleProducts, type Category } from '../data';

function applyOperation(arg1: string, arg2: string, op: string | null): boolean {
  const normalizedArg1 = arg1.toLowerCase();
  const normalizedArg2 = arg2.toLowerCase();
  if (op === '=') return normalizedArg1 === normalizedArg2;
  if (op === 'contains') return normalizedArg1.includes(normalizedArg2);
  if (op === 'startswith') return normalizedArg1.startsWith(normalizedArg2);
  if (op === 'endswith') return normalizedArg1.endsWith(normalizedArg2);
  return false;
}

function getFilterExpressionFunction(extractDisplayValues: boolean) {
  return function(
    this: DxDataGridTypes.Column,
    filterValue: any,
    selectedFilterOperation: string | null,
    target: string,
  ): string | any[] | (() => any) {
    if (filterValue) {
      const selector = (data: Category) => {
        const values = extractDisplayValues
          ? (this.calculateDisplayValue as (rowData: Category) => string)(data)
            .toLowerCase()
            .split(', ')
          : (this.calculateCellValue as (rowData: Category) => string[])(data);
        return !!values?.find((v) => applyOperation(v, filterValue, selectedFilterOperation));
      };
      return [selector, '=', true];
    }
    return this.defaultCalculateFilterExpression!.apply(
      this,
      [filterValue, selectedFilterOperation, target],
    ) as string | any[] | (() => any);
  };
}

function calculateProductNames(rowData: Category): string {
  const productNames = rowData.Products.map((productId) => {
    const product = products.find((p) => p.id === productId);
    return product ? product.name : null;
  });
  return productNames.join(', ');
}

const filterOperations = ['contains', 'endswith', '=', 'startswith'];

const calculateProductsFilterExpression = getFilterExpressionFunction(true);
const calculateSimpleProductsFilterExpression = getFilterExpressionFunction(false);

const headerFilterProductsDataSource: DataSourceOptions = {
  store: { type: 'array', data: products },
  map: (product: { id: number; name: string }) => ({
    text: product.name,
    value: product.name,
  }),
};

const headerFilterSimpleProductsDataSource: DataSourceOptions = {
  store: { type: 'array', data: simpleProducts },
  map: (product: string) => ({
    text: product,
    value: product,
  }),
};
</script>

<template>
  <DxDataGrid
    id="data-grid-local"
    :show-borders="true"
    :data-source="categories"
  >
    <DxFilterRow :visible="true"/>
    <DxHeaderFilter :visible="true"/>
    <DxColumn
      data-field="CategoryName"
      :width="200"
      :allow-filtering="false"
    />
    <DxColumn
      data-field="Products"
      caption="Object Products"
      data-type="string"
      :filter-operations="filterOperations"
      :calculate-filter-expression="calculateProductsFilterExpression"
      :calculate-display-value="calculateProductNames"
    >
      <DxHeaderFilter :data-source="headerFilterProductsDataSource"/>
    </DxColumn>
    <DxColumn
      data-field="SimpleProducts"
      caption="String Products"
      data-type="string"
      :filter-operations="filterOperations"
      :calculate-filter-expression="calculateSimpleProductsFilterExpression"
    >
      <DxHeaderFilter :data-source="headerFilterSimpleProductsDataSource"/>
    </DxColumn>
  </DxDataGrid>
</template>
