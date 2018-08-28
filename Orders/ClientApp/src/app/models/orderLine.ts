export class OrderLine {
  constructor(
    public id: number,
    public name: string,
    public price: number,
    public quantity: number,
    public total: number
  ) { }
}
