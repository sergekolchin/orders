import { Component, OnInit, ViewChild, Inject } from "@angular/core";
import { MatPaginator, MatSort, MatTableDataSource, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { DataService } from "../services/data.service";
import { Order } from "../models/order";
import { OrderLine } from  "../models/orderLine";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html"
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ["name", "quantity", "price", "total"];

  dataSource: MatTableDataSource<OrderLine>;
  orders: Order[];
  order: Order;
  orderLines: OrderLine[];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild((MatSort) as any) sort: MatSort;

  constructor(public dialog: MatDialog, private readonly dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.getOrder(1).subscribe(result => {
      this.order = result;
      this.orderLines = result.lines;
      this.dataSource = new MatTableDataSource(this.orderLines);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }, error => {
      console.log("getOrder() error: ", error);
    });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
