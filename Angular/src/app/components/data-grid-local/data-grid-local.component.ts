import { Component, ChangeDetectionStrategy } from '@angular/core';
import { DxDataGridModule, type DxDataGridTypes } from 'devextreme-angular/ui/data-grid';
import { categories, products, simpleProducts, Category } from '../../data';
import { DataSourceOptions } from 'devextreme/data/data_source';

@Component({
  selector: 'app-data-grid-local',
  imports: [DxDataGridModule],
  templateUrl: './data-grid-local.component.html',
  changeDetection: ChangeDetectionStrategy.Eager,
})
export class DataGridLocalComponent {
  categories = categories;

  filterOperations = ['contains', 'endswith', '=', 'startswith'];

  calculateProductsFilterExpression = this.getFilterExpressionFunction(true);

  calculateSimpleProductsFilterExpression = this.getFilterExpressionFunction(false);

  headerFilterProductsDataSource: DataSourceOptions = {
    store: { type: 'array', data: products },
    map: (product: { id: number; name: string }) => ({
      text: product.name,
      value: product.name,
    }),
  };

  headerFilterSimpleProductsDataSource: DataSourceOptions = {
    store: { type: 'array', data: simpleProducts },
    map: (product: string) => ({
      text: product,
      value: product,
    }),
  };

  applyOperation(arg1: string, arg2: string, op: string | null): boolean {
    const normalizedArg1 = arg1.toLowerCase();
    const normalizedArg2 = arg2.toLowerCase();
    if (op === '=') return normalizedArg1 === normalizedArg2;
    if (op === 'contains') return normalizedArg1.includes(normalizedArg2);
    if (op === 'startswith') return normalizedArg1.startsWith(normalizedArg2);
    if (op === 'endswith') return normalizedArg1.endsWith(normalizedArg2);
    return false;
  }

  getFilterExpressionFunction(extractDisplayValues: boolean) {
    const that = this;
    return function (
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
          return !!values?.find((v) => that.applyOperation(v, filterValue, selectedFilterOperation));
        };
        return [selector, '=', true];
      }
      return this.defaultCalculateFilterExpression!.apply(this, [filterValue, selectedFilterOperation, target]) as string | any[] | (() => any);
    };
  }

  calculateProductNames(rowData: Category): string {
    const productNames = rowData.Products.map((productId) => {
      const product = products.find((p) => p.id === productId);
      return product ? product.name : null;
    });
    return productNames.join(', ');
  }
}
