import { OrderLine } from "./orderLine";

export interface Order {
    id: number;
    number: string;
    date: Date;
    status: string;
    total: number;
    lines: OrderLine[];
}
