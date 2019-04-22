import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Product } from './product';
import { Order, OrderItem } from './order';
//import * as OrderNS from './order';


@Injectable()
export class DataService {

    constructor(private http: HttpClient) {

    }

    public order: Order = new Order();

    public products: Product[] = [];

    loadProducts(): Observable<boolean> {
        return this.http.get("/api/products")
            .pipe(
            map((data: any[]) => {
                this.products = data;
                return true;
            }));
    };



    public addToOrder(newProduct: Product) {

     

        var item: OrderItem = new OrderItem();

        item.productId = newProduct.id;
        item.productTitle = newProduct.title;
        item.productCategory = newProduct.category;
        item.productArtId = newProduct.artId;
        item.productLength = newProduct.length;
        item.unitPrice = newProduct.price;
        item.quantity = 1;

        this.order.items.push(item);
    }
}