const remoteDataGridApi = function () {
    function calculateRemoteProductNames(rowData) {
        return rowData.Products.map(product => product.ProductName).join(", ");
    }

    function mapRemoteProduct(item) {
        return {
            text: item.ProductName,
            value: item.ProductName
        };
    }

    return {
        calculateRemoteProductNames,
        mapRemoteProduct
    };
}();
