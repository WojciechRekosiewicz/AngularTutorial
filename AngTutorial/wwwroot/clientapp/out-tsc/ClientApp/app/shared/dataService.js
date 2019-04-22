import * as tslib_1 from "tslib";
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Order, OrderItem } from './order';
//import * as OrderNS from './order';
var DataService = /** @class */ (function () {
    function DataService(http) {
        this.http = http;
        this.order = new Order();
        this.products = [];
    }
    DataService.prototype.loadProducts = function () {
        var _this = this;
        return this.http.get("/api/products")
            .pipe(map(function (data) {
            _this.products = data;
            return true;
        }));
    };
    ;
    DataService.prototype.addToOrder = function (newProduct) {
        var item = new OrderItem();
        item.productId = newProduct.id;
        item.productTitle = newProduct.title;
        item.productCategory = newProduct.category;
        item.productArtId = newProduct.artId;
        item.productLength = newProduct.length;
        item.unitPrice = newProduct.price;
        item.quantity = 1;
        this.order.items.push(item);
    };
    DataService = tslib_1.__decorate([
        Injectable(),
        tslib_1.__metadata("design:paramtypes", [HttpClient])
    ], DataService);
    return DataService;
}());
export { DataService };
//# sourceMappingURL=dataService.js.map