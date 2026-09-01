const localDataGridApi = function() {
    function mapProduct(item) {
        return { text: item.Name, value: item.Name };
    }

    function mapSimpleProduct(item) {
        return { text: item, value: item };
    }

    function calculateProductNames(rowData) {
        const productNames = rowData.Products.map(productId => {
            const product = localProducts.find((p) => p.Id === productId);
            return product ? product.Name : null;
        });
        return productNames.join(", ");
    }

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
                        : column.calculateCellValue(data);
                    return values && !!values.find(v => applyOperation(v, filterValue, selectedFilterOperation));
                };
                return [selector, "=", true];
            }
            return this.defaultCalculateFilterExpression.apply(this, arguments);
        };
    }

    const calculateFilterExpressionByDisplayValue = getFilterExpressionFunction(true);
    const calculateFilterExpressionByCellValue = getFilterExpressionFunction(false);

    return {
        mapProduct,
        mapSimpleProduct,
        calculateProductNames,
        calculateFilterExpressionByDisplayValue,
        calculateFilterExpressionByCellValue
    };
}();
