import { Component, OnInit } from "@angular/core";
import { Order } from "./models/order";
import { DataService } from "./services/data.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent implements OnInit {
  orders: Order[];

  constructor(private readonly dataService: DataService, private readonly router: Router) { }

  ngOnInit(): void {
    this.dataService.getOrders().subscribe(result => {
      this.orders = result;
      this.router.navigate([`orders/${this.orders[0].id}`]);
    },
      error => {
        console.log("getOrder() error: ", error);
      });
  }

  title = "Orders";
}
