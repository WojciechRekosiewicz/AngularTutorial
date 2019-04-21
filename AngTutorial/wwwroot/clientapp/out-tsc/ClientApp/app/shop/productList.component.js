import * as tslib_1 from "tslib";
import { Component } from "@angular/core";
var ProductList = /** @class */ (function () {
    function ProductList() {
        this.products = [{
                title: "First Product",
                price: 399.99
            }, {
                title: "Second Product",
                price: 99.99
            }, {
                title: "Third Product",
                price: 919.99
            }, {
                title: "Fourth Product",
                price: 911.00
            }];
    }
    ProductList = tslib_1.__decorate([
        Component({
            selector: "product-list",
            templateUrl: "productList.component.html",
            styleUrls: []
        })
    ], ProductList);
    return ProductList;
}());
export { ProductList };
//# sourceMappingURL=productList.component.js.map