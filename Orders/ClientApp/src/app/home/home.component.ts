import { Component, OnInit, ViewChild, Inject } from "@angular/core";
import { MatPaginator, MatSort, MatTableDataSource } from "@angular/material";
import { DataService } from "../services/data.service";
import { Order } from "../models/order";
import { OrderLine } from "../models/orderLine";
import { ActivatedRoute, ParamMap } from "@angular/router";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ["name", "quantity", "price", "total"];

  dataSource: MatTableDataSource<OrderLine>;
  order: Order;
  orderStatus: string;
  orderNumber: string;
  orderDate: Date;
  orderTotal: number;
  orderLines: OrderLine[];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild((MatSort) as any) sort: MatSort;

  constructor(private readonly dataService: DataService, private readonly route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.paramMap.subscribe((params: ParamMap) => {
      const id = params.get("id");
      this.dataService.getOrder(+id).subscribe(result => {
        this.order = result;
        this.dataSource = new MatTableDataSource(this.order.lines);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
        error => {
          console.log("getOrder() error: ", error);
        });
    });
  }

  getTotalQty() {
    if (this.order) {
      return this.order.lines.map(t => t.quantity).reduce((acc, value) => acc + value, 0);
    }
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
