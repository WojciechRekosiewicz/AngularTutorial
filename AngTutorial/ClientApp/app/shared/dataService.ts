﻿import { HttpClient } from '@angular/common/http';
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
      }

    public AddToOrder(product: Product) {


        let item: OrderItem = this.order.items.find(i => i.productId == product.id);

        if (item) {

            item.quantity++;
        }
        else {
            item = new OrderItem();
            item.productId = product.id;
            item.productTitle = product.title;
            item.productCategory = product.category;
            item.productArtId = product.artId;
            item.productLength = product.length;
            item.unitPrice = product.price;
            item.quantity = 1;

            this.order.items.push(item);
        }
    }
}