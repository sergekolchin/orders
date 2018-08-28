import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs/Rx";
import { APP_BASE_HREF } from "@angular/common";
import { Order } from "../models/order";

@Injectable({ providedIn: "root" })
export class DataService {
  ordersUrl: string;

  constructor(private readonly http: HttpClient, @Inject(APP_BASE_HREF) private baseHref: string) {
    this.ordersUrl = this.baseHref + "api/orders";
  }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.ordersUrl);
  }

  getOrder(id: number): Observable<Order> {
    return this.http.get<Order>(`${this.ordersUrl}/${id}`);
  }
}
