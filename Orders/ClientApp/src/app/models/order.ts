import { OrderLine } from "./orderLine";

export class Order {
  constructor(
    public id: number,
    public number: string,
    public date: Date,
    public orderStatus: string,
    public total: number,
    public lines: OrderLine[]
    ) { }
}
