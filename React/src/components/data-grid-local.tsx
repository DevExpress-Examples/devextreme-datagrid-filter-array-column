import DataGrid, {
  Column,
  FilterRow,
  HeaderFilter,
  type DataGridTypes,
} from 'devextreme-react/data-grid';
import {
  categories,
  products,
  simpleProducts,
  type Category,
} from '../data';

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
  return function (
    this: DataGridTypes.Column,
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
    return this.defaultCalculateFilterExpression!.apply(this, [filterValue, selectedFilterOperation, target]) as string | any[] | (() => any);
  };
}

function calculateProductNames(rowData: Category): string {
  const productNames = rowData.Products.map((productId) => {
    const product = products.find((p) => p.id === productId);
    return product ? product.name : null;
  });
  return productNames.join(', ');
}

const headerFilterSettingsProducts : DataGridTypes.ColumnHeaderFilter = {
  dataSource: {
    store: { type: 'array', data: products },
    map: (product: { id: number; name: string }) => ({
      text: product.name,
      value: product.name,
    }),
  },
};

const headerFilterSettingsSimpleProducts : DataGridTypes.ColumnHeaderFilter = {
  dataSource: {
    store: { type: 'array', data: simpleProducts },
    map: (product: string) => ({
      text: product,
      value: product,
    }),
  },
};

const filterOperations = ['contains', 'endswith', '=', 'startswith'];

function DataGridLocal(): JSX.Element {
  return (
    <DataGrid id="data-grid-local" showBorders dataSource={categories}>
      <FilterRow visible />
      <HeaderFilter visible />
      <Column dataField="CategoryName" width={200} allowFiltering={false} />
      <Column
        dataField="Products"
        caption="Object Products"
        dataType="string"
        filterOperations={filterOperations}
        calculateFilterExpression={getFilterExpressionFunction(true)}
        calculateDisplayValue={calculateProductNames}
        headerFilter={headerFilterSettingsProducts}
      />
      <Column
        dataField="SimpleProducts"
        caption="String Products"
        dataType="string"
        filterOperations={filterOperations}
        calculateFilterExpression={getFilterExpressionFunction(false)}
        headerFilter={headerFilterSettingsSimpleProducts}
      />
    </DataGrid>
  );
}

export default DataGridLocal;
