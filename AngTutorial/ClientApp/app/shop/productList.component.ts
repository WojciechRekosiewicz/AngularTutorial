import { Component } from "@angular/core";


@Component({
    selector: "product-list",
    templateUrl: "productList.component.html",
    styleUrls: []
})
export class ProductList {
    public products = [{
        title: "First Product",
        price: 399.99
      },{
        title: "Second Product",
        price: 99.99
      },{
        title: "Third Product",
        price: 919.99
      }, {
        title: "Fourth Product",
        price: 911.00
        }];
}